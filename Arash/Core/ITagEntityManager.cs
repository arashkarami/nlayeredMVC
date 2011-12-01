using System;
using System.Collections.Generic;
using Arash.Core.Model;

namespace Arash.Core
{
    public interface ITagEntityManager
    {
        TagEntity MakeInstance();

        void Add(TagEntity entity);

        void Edit(TagEntity entity);

        void Remove(TagEntity entity);

        int GetCount(Func<TagEntity, bool> predicate = null);

        TagEntity Get(Func<TagEntity, bool> predicate = null);

        IEnumerable<TagEntity> GetAll(Func<TagEntity, bool> predicate = null, int start = 0, int count = 6);
    }
}
