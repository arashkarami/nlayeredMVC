using System;
using System.Collections.Generic;
using Arash.Core.Model;

namespace Arash.Core
{
    public interface IEntityBaseManager
    {
        EntityBase MakeInstance();

        void Add(EntityBase entity);

        void Edit(EntityBase entity);

        void Remove(EntityBase entity);

        int GetCount(Func<EntityBase, bool> predicate = null);

        EntityBase Get(Func<EntityBase, bool> predicate = null);

        IEnumerable<EntityBase> GetAll(Func<EntityBase, bool> predicate = null, int start = 0, int count = 6);
    }
}
