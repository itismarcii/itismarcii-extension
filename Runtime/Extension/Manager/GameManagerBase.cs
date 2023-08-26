using UnityEngine;

namespace itismarciiExtansion.Runtime.Manager
{
    public abstract class GameManagerBase : MonoBehaviour
    {
        protected static GameManagerBase _Instance;
        
        protected static byte ComponentBit = 0;
        
        private void Awake()
        {
            if (_Instance) Destroy(gameObject);
            else
            {
                _Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            OnAwake();
        }

        public static bool HasComponent(in byte n) => (ComponentBit & (1 << n)) != 0;

        public virtual void OnAwake() {}

        public abstract void AddComponent<T>(in T component) where T : IGameManagerComponent;
        public abstract void RemoveComponent<T>(in T component) where T : IGameManagerComponent;
        public abstract void RemoveComponent(in byte bit);

    }
}
