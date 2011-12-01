using System;
using System.Collections.Generic;
using Arash.Core.Model;
using Paradiso.Infrastructure.Data;
using Arash.Infrastructure.Data;

namespace Arash.Core.Manager
{
    public class TagManager : ITagManager
    {
        private IRepository<Tag> _repository;

        public TagManager(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public Tag MakeInstance()
        {
            return _repository.NewEntityInstance();
        }

        public void Add(Tag entity)
        {
            _repository.Add(entity);
            _repository.Save();
        }

        public void Edit(Tag entity)
        {
            _repository.Save();
        }

        public void Remove(Tag entity)
        {
            _repository.Remove(entity);
            _repository.Save();
        }

        public int GetCount(Func<Tag, bool> predicate = null)
        {
            return predicate == null
                ? _repository.GetCount(p => true)
                : _repository.GetCount(predicate);
        }

        public Tag Get(Func<Tag, bool> predicate = null)
        {
            return predicate == null
                ? _repository.Get(p => true)
                : _repository.Get(predicate);
        }

        public IEnumerable<Tag> GetAll(Func<Tag, bool> predicate = null, int start = 0, int count = 6)
        {
            return predicate == null
                 ? _repository.GetAll(p => true)
                 : start == 0
                     ? _repository.GetAll(predicate)
                     : _repository.GetAll(predicate, start, count);
        }
    }
}
