using System.Collections.Generic;

namespace itismarciiExtansion.Runtime.Pattern
{
    public class FlyweightFactory<T, TU> where TU : FlyweightClassBase
    {
        private static readonly Dictionary<T, TU> Classes = new Dictionary<T, TU>();

        public static FlyweightClassBase GetClass(in T key, in TU obj)
        {
            if (Classes.TryGetValue(key, out var flyweight))
            {
                return flyweight;
            }
            
            Classes.Add(key, obj);
            return Classes[key];
        }
    }
}
