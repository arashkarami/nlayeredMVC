using System;
using System.Collections.Generic;
using Arash.Core.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class EntityTypeManager : IEntityTypeManager
    {
        private IRepository<EntityType> _repository;

        public EntityTypeManager(IRepository<EntityType> repository)
        {
            _repository = repository;
        }

        public EntityType MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(EntityType entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(EntityType entity)
        {
            _repository.Save();
        }

        public void Remove(EntityType entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<EntityType, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public EntityType Get(Func<EntityType, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<EntityType> GetAll(Func<EntityType, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }

        public EntityType GetOrAdd(string name)
        {
            var entity = _repository.Get(p => p.Name == name);

            if (entity != null)
                return entity;

            var newEntity = _repository.NewEntityInstance();
            newEntity.Name = name;
            _repository.Add(newEntity);
            _repository.Save();

            return newEntity;
        }
    }
}
