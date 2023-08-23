namespace itismarciiExtansion.Runtime.Manager
{
    public interface IGameManagerComponentType<T> : IGameManagerComponent
    {
        public void Setup(in T variable);
    }
}
