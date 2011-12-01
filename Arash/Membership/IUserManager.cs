using System;
using System.Collections.Generic;
using Arash.Membership.Model;

namespace Arash.Core
{
    public interface IUserManager
    {
        User MakeInstance();

        void Add(User entity);

        void Edit(User entity);

        void Remove(User entity);

        int GetCount(Func<User, bool> predicate = null);

        User Get(Func<User, bool> predicate = null);

        IEnumerable<User> GetAll(Func<User, bool> predicate = null, int start = 0, int count = 6);
    }
}
