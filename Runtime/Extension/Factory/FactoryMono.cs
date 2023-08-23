using System.Collections.Generic;
using UnityEngine;

namespace itismarciiExtansion.Runtime.Factory
{
    public abstract class FactoryMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _Object;
        protected readonly List<T> FactoryObjects = new List<T>();
        
        public T Initiate(in bool asParent = true)
        {
            var obj = asParent ? 
                Instantiate(_Object, transform) : 
                Instantiate(_Object);

            OnInitiate(obj);
            FactoryObjects.Add(obj);
            return obj;
        }
        
        public T Initiate(in Vector3 position, in Quaternion rotation, in bool asParent = true)
        {
            var obj = asParent ? 
                Instantiate(_Object, position, rotation, transform) : 
                Instantiate(_Object, position, rotation);

            OnInitiate(obj);
            FactoryObjects.Add(obj);
            return obj;
        }

        public void RemoveObject(in T obj)
        {
            FactoryObjects.Remove(obj);
            OnDestroyClass();
            Destroy(obj);
        }

        protected virtual T OnInitiate(in T obj) => obj;
        protected virtual void OnDestroyClass() {}
    }
}
