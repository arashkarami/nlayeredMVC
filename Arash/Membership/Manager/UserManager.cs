using System;
using System.Collections.Generic;
using Arash.Membership.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class UserManager : IUserManager
    {
        private IRepository<User> _repository;

        public UserManager(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(User entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(User entity)
        {
            _repository.Save();
        }

        public void Remove(User entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<User, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public User Get(Func<User, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<User> GetAll(Func<User, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
