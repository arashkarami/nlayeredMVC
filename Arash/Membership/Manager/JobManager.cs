using System;
using System.Collections.Generic;
using Arash.Membership.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class JobManager : IJobManager
    {
        private IRepository<Job> _repository;

        public JobManager(IRepository<Job> repository)
        {
            _repository = repository;
        }

        public Job MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(Job entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(Job entity)
        {
            _repository.Save();
        }

        public void Remove(Job entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<Job, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public Job Get(Func<Job, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<Job> GetAll(Func<Job, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
