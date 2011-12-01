using System;
using System.Collections.Generic;
using Arash.Membership.Model;

namespace Arash.Core
{
    public interface IRoleManager
    {
        Role MakeInstance();

        void Add(Role entity);

        void Edit(Role entity);

        void Remove(Role entity);

        int GetCount(Func<Role, bool> predicate = null);

        Role Get(Func<Role, bool> predicate = null);

        IEnumerable<Role> GetAll(Func<Role, bool> predicate = null, int start = 0, int count = 6);
    }
}
