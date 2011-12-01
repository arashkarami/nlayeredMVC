using System;
using System.Collections.Generic;
using Arash.Membership.Model;

namespace Arash.Core
{
    public interface IMemberManager
    {
        Member MakeInstance();

        void Add(Member entity);

        void Edit(Member entity);

        void Remove(Member entity);

        int GetCount(Func<Member, bool> predicate = null);

        Member Get(Func<Member, bool> predicate = null);

        IEnumerable<Member> GetAll(Func<Member, bool> predicate = null, int start = 0, int count = 6);

        Member Authenticate(string username, string password);
    }
}
