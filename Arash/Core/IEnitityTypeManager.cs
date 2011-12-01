using System;
using System.Collections.Generic;
using Arash.Core.Model;


namespace Arash.Core
{
    public interface IEntityTypeManager
    {
        EntityType MakeInstance();

        void Add(EntityType entity);

        void Edit(EntityType entity);

        void Remove(EntityType entity);

        int GetCount(Func<EntityType, bool> predicate = null);

        EntityType Get(Func<EntityType, bool> predicate = null);

        EntityType GetOrAdd(string name);

        IEnumerable<EntityType> GetAll(Func<EntityType, bool> predicate = null, int start = 0, int count = 6);
    }
}
