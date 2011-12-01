using System;
using System.Collections.Generic;
using Arash.Restaurant.Model;

namespace Arash.Core
{
    public interface ICoffeeshopManager
    {
        Coffeeshop MakeInstance();

        void Add(Coffeeshop entity);

        void Edit(Coffeeshop entity);

        void Remove(Coffeeshop entity);

        int GetCount(Func<Coffeeshop, bool> predicate = null);

        Coffeeshop Get(Func<Coffeeshop, bool> predicate = null);

        IEnumerable<Coffeeshop> GetAll(Func<Coffeeshop, bool> predicate = null, int start = 0, int count = 6);
    }
}
