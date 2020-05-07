namespace MiniORM
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;

        private readonly List<T> added;

        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities =>
            this.allEntities.AsReadOnly();

        public IReadOnlyCollection<T> Added =>
            this.added.AsReadOnly();

        public IReadOnlyCollection<T> Removed =>
            this.removed.AsReadOnly();

        public void Add(T item) => this.added.Add(item);

        public void Remove(T item)
        {
            this.removed.Add(item);

            var entityToDelete = this.GetEntityToDelete(item);

            this.allEntities.Remove(entityToDelete);
        }

        public void ClearAdded()
        {
            this.added.Clear();
        }

        public void ClearRemoved()
        {
            this.removed.Clear();
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbset)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity)
                    .ToArray();

                var entity = dbset.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                    .SequenceEqual(primaryKeyValues));

                bool isModified = IsModified(proxyEntity, entity);

                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private T GetEntityToDelete(T item)
        {
            PropertyInfo[] primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            IEnumerable<object> itemPrimaryKeyValues = GetPrimaryKeyValues(primaryKeys, item);

            T itemToDelete = this.AllEntities
                .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                .SequenceEqual(itemPrimaryKeyValues));

            return itemToDelete;
        }

        private static bool IsModified(T proxyEntity, T realEntity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProperties = monitoredProperties
                .Where(pi => !Equals(pi.GetValue(realEntity), pi.GetValue(proxyEntity)))
                .ToArray();

            bool isModified = modifiedProperties.Any();

            return isModified;
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (var realEntity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(realEntity);
                    property.SetValue(clonedEntity, value);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }
    }
}