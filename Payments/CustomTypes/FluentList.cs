using System.Collections.Generic;

namespace Payments
{
    public class FluentList<T> : List<T>
    {
        public new FluentList<T> Add(T obj)
        {
            base.Add(obj);
            return this;
        }

        public new FluentList<T> AddRange(IEnumerable<T> objs)
        {
            base.AddRange(objs);
            return this;
        }
    }
}
