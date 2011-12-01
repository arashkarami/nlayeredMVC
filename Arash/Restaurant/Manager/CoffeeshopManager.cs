using System;
using System.Collections.Generic;
using Arash.Restaurant.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class CoffeeshopManager : ICoffeeshopManager
    {
        private IRepository<Coffeeshop> _repository;

        public CoffeeshopManager(IRepository<Coffeeshop> repository)
        {
            _repository = repository;
        }

        public Coffeeshop MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(Coffeeshop entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(Coffeeshop entity)
        {
            _repository.Save();
        }

        public void Remove(Coffeeshop entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<Coffeeshop, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public Coffeeshop Get(Func<Coffeeshop, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<Coffeeshop> GetAll(Func<Coffeeshop, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
