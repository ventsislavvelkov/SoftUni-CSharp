namespace MiniORM
{
    using System;
    using System.Linq;
    using System.Reflection;
    using MiniORM.Utilities;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetProperties = this.DiscoverDbSets();

            using (new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        // This method invokes dynamically Persist method
        public void SaveChanges()
        {
            // Take all dbSets
            object[] dbSets = this.dbSetProperties
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            // Validation of dbSets
            foreach (IEnumerable<object> dbSet in dbSets)
            {
                object[] invalidEntities = dbSet
                    .Where(entity => !IsObjectValid(entity))
                    .ToArray();

                if (invalidEntities.Any())
                {
                    throw new InvalidOperationException(String.Format(
                        ExceptionMessages.InvalidEntitiesFound, invalidEntities.Length, dbSet.GetType().Name));
                }
            }

            // Open connection to database and loop all dbSets
            using (new ConnectionManager(connection))
            {
                using var transaction = this.connection.StartTransaction();

                // Find the current dbSet and invoke the Persist method with handling exceptions
                foreach (IEnumerable dbSet in dbSets)
                {
                    Type dbSetType = dbSet
                        .GetType()
                        .GetGenericArguments()
                        .First();

                    MethodInfo persistMethod = typeof(DbContext)
                        .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                        .MakeGenericMethod(dbSetType);

                    try
                    {
                        persistMethod.Invoke(this, new object[] { dbSet });
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }
                    catch (InvalidOperationException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                // Commit the changes to database
                transaction.Commit();
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = GetTableName(typeof(TEntity));

            string[] columns = this.connection
                .FetchColumnNames(tableName)
                .ToArray();

            // Look for added entities in ChangeTracker Added collection and if there are any insert them in that collection (database)
            // Clears Change Tracker Added collection
            if (dbSet.ChangeTracker.Added.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
                dbSet.ChangeTracker.ClearAdded();
            }

            TEntity[] modifiedEntities = dbSet
                .ChangeTracker
                .GetModifiedEntities(dbSet)
                .ToArray();

            // Look for modified entities in ChangeTracker Modified entities and if there are any updates them (database)
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            // Look for removed entities in ChangeTracker Removed entities and if there are delete them (database)
            // Clears Change Tracker Removed collection
            if (dbSet.ChangeTracker.Removed.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
                dbSet.ChangeTracker.ClearRemoved();
            }
        }

        // This method invokes dynamically PopulateDbSet method
        private void InitializeDbSets()
        {
            // For each dbSet invoke PopulateDbSet generic method
            foreach (var dbSet in dbSetProperties)
            {
                Type dbSetType = dbSet.Key;
                PropertyInfo dbSetProperty = dbSet.Value;

                MethodInfo populateDbSetGeneric = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
            where TEntity : class, new()
        {
            // Take all entities and set dbSet properties with ReflectionHelper because dbSets do not have setters
            IEnumerable<TEntity> entities = LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(entities);

            ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        // This method invokes dynamically MapRelations method
        private void MapAllRelations()
        {
            // Invokes MapRelations dynamically for each dbSetProperty
            foreach (var dbSetProperty in dbSetProperties)
            {
                // Takes dbSetType and property value
                Type dbSetType = dbSetProperty.Key;
                object dbSet = dbSetProperty.Value.GetValue(this);

                MethodInfo mapRelationsGenericMethod = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                mapRelationsGenericMethod.Invoke(this, new[] { dbSet });
            }
        }

        // This method invokes dynamically MapCollection method
        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            MapNavigationProperties(dbSet);

            PropertyInfo[] collections = entityType
                .GetProperties()
                .Where(pi =>
                pi.PropertyType.IsGenericType &&
                pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                Type collectionType = collection
                    .PropertyType
                    .GenericTypeArguments
                    .First();

                MethodInfo mapCollectionType = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionType);

                mapCollectionType.Invoke(this, new object[] { dbSet, collectionType });
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            Type entityType = typeof(TEntity);

            PropertyInfo[] foreignKeys = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                string navigationPropertyName =
                    foreignKey.GetCustomAttribute<ForeignKeyAttribute>().Name;

                PropertyInfo navigationProperty = entityType
                    .GetProperty(navigationPropertyName);

                object navigationDbSet = this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);

                PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType
                    .GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var foreignKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currentNavigationProperty =>
                                navigationPrimaryKey
                                .GetValue(currentNavigationProperty)
                                .Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        // Hard method for implementing - TODO: PropertyInfo type might be Type because of the dynamically invoked method in MapRelations
        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, Type collectionProperty)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            Type entityType = typeof(TDbSet);
            Type collectionType = typeof(TCollection);

            // Get primary keys from collection type
            PropertyInfo[] primaryKeys = collectionType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            PropertyInfo primaryKey = primaryKeys.First();

            // Get foreign keys from entity type
            PropertyInfo foreignKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            // Check if there is many to many relationship
            bool isManyToMany = primaryKeys.Length >= 2;

            if (isManyToMany)
            {
                primaryKey = collectionType
                    .GetProperties()
                    .First(pi => collectionType
                                    .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                    .PropertyType == entityType);
            }

            var navigationDbSet = (DbSet<TCollection>)this.dbSetProperties[collectionType]
                .GetValue(this);

            foreach (var entity in dbSet)
            {
                object foreignKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet
                    .Where(navigationEntity => primaryKey.GetValue(navigationEntity).Equals(foreignKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
            }
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSets()
        {
            Dictionary<Type, PropertyInfo> dbSets = this
                .GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

            return dbSets;
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class
        {
            Type table = typeof(TEntity);

            string[] columns = GetEntityColumnNames(table);

            string tableName = GetTableName(table);

            TEntity[] fetchedRows = this.connection
                .FetchResultSet<TEntity>(tableName, columns)
                .ToArray();

            return fetchedRows;
        }

        private string GetTableName(Type tableType)
        {
            string tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType, typeof(TableAttribute)))?.Name;

            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private string[] GetEntityColumnNames(Type table)
        {
            string tableName = this.GetTableName(table);

            IEnumerable<string> dbColumns =
                this.connection
                .FetchColumnNames(tableName);

            string[] columns = table
                .GetProperties()
                .Where(pi => dbColumns.Contains(pi.Name) &&
                      !pi.HasAttribute<NotMappedAttribute>() &&
                      AllowedSqlTypes.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return columns;
        }

        // boilerplate
        private static bool IsObjectValid(object e)
        {
            var validationContext = new ValidationContext(e);
            var validationErrors = new List<ValidationResult>();

            var validationResult =
                Validator.TryValidateObject(e, validationContext, validationErrors, validateAllProperties: true);

            return validationResult;
        }
    }
}