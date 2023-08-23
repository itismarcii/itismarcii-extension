using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Pattern
{
    public class Observer<T>
    {
        private readonly List<IObserver<T>> Observers = new List<IObserver<T>>();
    
        public void Subscribe(in IObserver<T> observer)
        {
            Observers.Add(observer);
        }

        public void Unsubscribe(in IObserver<T> observer)
        {
            Observers.Remove(observer);
        }

        public void UnsubscribeAll() => Observers.Clear();

        public void Call(in T variable)
        {
            foreach (var observer in Observers)
            {
                observer.OnCall(variable);
            }
        }
    }
    
    public class Observer<T, TU>
    {
        private readonly List<IObserver<T, TU>> Observers = new List<IObserver<T, TU>>();
    
        public void Subscribe(in IObserver<T, TU> observer)
        {
            Observers.Add(observer);
        }

        public void Unsubscribe(in IObserver<T, TU> observer)
        {
            Observers.Remove(observer);
        }
        
        public void UnsubscribeAll() => Observers.Clear();

        public void Call(in T var0, in TU var1)
        {
            foreach (var observer in Observers)
            {
                observer.OnCall(var0, var1);
            }
        }
    }
    
    public class Observer<T, TU, TV>
    {
        private readonly List<IObserver<T, TU, TV>> Observers = new List<IObserver<T, TU, TV>>();
    
        public void Subscribe(in IObserver<T, TU, TV> observer)
        {
            Observers.Add(observer);
        }

        public void Unsubscribe(in IObserver<T, TU, TV> observer)
        {
            Observers.Remove(observer);
        }
        
        public void UnsubscribeAll() => Observers.Clear();

        public void Call(in T var0, in TU var1, in TV var2)
        {
            foreach (var observer in Observers)
            {
                observer.OnCall(var0, var1, var2);
            }
        }
    }
}
