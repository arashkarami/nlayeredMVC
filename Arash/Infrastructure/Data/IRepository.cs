using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arash.Infrastructure.Data
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Create New Instance
        /// </summary>
        T NewEntityInstance();

        /// <summary>
        /// Inserts an item
        /// </summary>
        void Add(T item);

        /// <summary>
        /// Deletes an item
        /// </summary>
        void Remove(T item);

        /// <summary>
        /// Get an item matching to prediate
        /// </summary>
        T Get(Func<T, bool> predicate);

        /// <summary>
        /// Get Count of items matching to predicate
        /// </summary>
        int GetCount(Func<T, bool> predicate);

        /// <summary>
        /// Get IEnumerable object matching to predicate
        /// </summary>
        IEnumerable<T> GetAll(Func<T, bool> predicate);

        /// <summary>
        /// Get IEnumerable object matching to predicate,start index and count
        /// </summary>
        IEnumerable<T> GetAll(Func<T, bool> predicate, int start, int count);

        /// <summary>
        /// Saves the pending changes back into the DataContext.
        /// </summary>
        void Save();
    }
}