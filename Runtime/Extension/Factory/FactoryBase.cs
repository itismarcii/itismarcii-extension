using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Factory
{
    public abstract class FactoryBase<T>
    {
        protected readonly List<T> FactoryObjects = new List<T>();

        public T Initiate()
        {
            var obj = Create();
            FactoryObjects.Add(obj);
            return obj;
        }

        public void RemoveObject(in T obj)
        {
            FactoryObjects.Remove(obj);
        }

        protected abstract T Create();
        protected virtual void OnDestroyClass() { }
    }
}
