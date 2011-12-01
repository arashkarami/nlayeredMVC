using System;
using System.Collections.Generic;
using Arash.Core.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class EntityBaseManager : IEntityBaseManager
    {
        private IRepository<EntityBase> _repository;

        public EntityBaseManager(IRepository<EntityBase> repository)
        {
            _repository = repository;
        }

        public EntityBase MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(EntityBase entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(EntityBase entity)
        {
            _repository.Save();
        }

        public void Remove(EntityBase entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<EntityBase, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public EntityBase Get(Func<EntityBase, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<EntityBase> GetAll(Func<EntityBase, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
