using System;
using System.Collections.Generic;
using Arash.Membership.Model;

namespace Arash.Core
{
    public interface IJobManager
    {
        Job MakeInstance();

        void Add(Job entity);

        void Edit(Job entity);

        void Remove(Job entity);

        int GetCount(Func<Job, bool> predicate = null);

        Job Get(Func<Job, bool> predicate = null);

        IEnumerable<Job> GetAll(Func<Job, bool> predicate = null, int start = 0, int count = 6);
    }
}
