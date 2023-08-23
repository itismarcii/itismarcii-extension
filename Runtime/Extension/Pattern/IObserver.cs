namespace itismarciiExtansion.Runtime.Pattern
{
    public interface IObserver<T>
    {
        public void OnCall(in T variable);
    }
    
    public interface IObserver<T, TU>
    {
        public void OnCall(in T variable0, in TU variable1);
    }
    
    public interface IObserver<T, TU, TV>
    {
        public void OnCall(in T var0, in TU var1, in TV var2);
    }
}
