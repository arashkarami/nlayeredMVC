using System;
using System.Collections.Generic;
using Arash.Core.Model;

namespace Arash.Core
{
    public interface ITagManager
    {
        Tag MakeInstance();

        void Add(Tag entity);

        void Edit(Tag entity);

        void Remove(Tag entity);

        int GetCount(Func<Tag, bool> predicate = null);

        Tag Get(Func<Tag, bool> predicate = null);

        IEnumerable<Tag> GetAll(Func<Tag, bool> predicate = null, int start = 0, int count = 6);
    }
}
