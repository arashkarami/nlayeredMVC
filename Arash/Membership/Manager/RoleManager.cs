using System;
using System.Collections.Generic;
using Arash.Membership.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class RoleManager : IRoleManager
    {
        private IRepository<Role> _repository;

        public RoleManager(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public Role MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(Role entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(Role entity)
        {
            _repository.Save();
        }

        public void Remove(Role entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<Role, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public Role Get(Func<Role, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<Role> GetAll(Func<Role, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
