using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Extra
{
    public class Filo<T>
    {
        private readonly List<T> _List = new List<T>();
        public int Count => _List.Count;
        
        public void Push(in T item) => _List.Add(item);
        public T Pop()
        {
            var item = _List[0];
            _List.RemoveAt(0);
            return item;
        }
    }
}
