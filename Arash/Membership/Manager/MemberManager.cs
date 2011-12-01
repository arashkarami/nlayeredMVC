using System;
using System.Collections.Generic;
using Arash.Membership.Model;
using Arash.Utility.Common;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class MemberManager : IMemberManager
    {
        private IRepository<Member> _repository;

        public MemberManager(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public Member MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(Member entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(Member entity)
        {
            _repository.Save();
        }

        public void Remove(Member entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<Member, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public Member Get(Func<Member, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<Member> GetAll(Func<Member, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }

        public Member Authenticate(string username, string password)
        {
            var entity = _repository.Get(p => p.Username == username);

            if (entity == null)
                return null;

            var passwordHash = PasswordGenerator.GetHashPassword(password);

            if (!string.Equals(passwordHash, password))
                return null;

            return entity;
        }
    }
}
