namespace MiniORM
{
    using System;
    using System.Linq;
    using MiniORM.Utilities;
    using System.Collections;
    using System.Collections.Generic;

    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<TEntity>(entities);
        }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        public int Count => this.Entities.Count;

        // We implement this property, but don't use it!
        public bool IsReadOnly => this.Entities.IsReadOnly;

        public bool Contains(TEntity item) => this.Entities.Contains(item);

        public void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), String.Format(ExceptionMessages.ItemCannotBeNull));
            }

            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity);
            }
        }

        // We implement this method, but don't use it!
        public void CopyTo(TEntity[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);

        public bool Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), String.Format(ExceptionMessages.ItemCannotBeNull));
            }

            bool isRemoved = this.Entities.Remove(item);

            if (isRemoved)
            {
                this.ChangeTracker.Remove(item);
            }

            return isRemoved;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}