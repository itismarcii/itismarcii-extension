using System;

namespace itismarciiExtansion.Runtime.Extra
{
    public class DoubleBuffer<T>
    {
        private Func<T, T> _CurrentExecution;
        private Func<T, T> _NextExecution;
        
        private T[] _CurrentBuffer;
        private T[] _NextBuffer;
        private readonly object _SwapLock = new object();

        public DoubleBuffer(in int size, in Func<T, T> execution)
        {
            _CurrentBuffer = new T[size];
            _NextBuffer = new T[size];
            
            _CurrentExecution = execution;
            _NextExecution = execution;
        }
        
        public DoubleBuffer(in T[] array, in Func<T, T> execution)
        {
            var buffer0 = new T[array.Length];
            var buffer1 = new T[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                buffer0[i] = array[i];
                buffer1[i] = array[i];
            }
            
            _CurrentBuffer = buffer0;
            _NextBuffer = buffer1;

            _CurrentExecution = execution;
            _NextExecution = execution;
        }

        private void Swap()
        {
            lock (_SwapLock)
            {
                (_CurrentBuffer, _NextBuffer) = (_NextBuffer, _CurrentBuffer);
                (_CurrentExecution, _NextExecution) = (_NextExecution, _CurrentExecution);
            }
        }

        public void UpdateBuffer()
        {
            for (var index = 0; index < _NextBuffer.Length; index++)
            {
                _NextBuffer[index] = _CurrentExecution.Invoke(_NextBuffer[index]);
            }

            Swap();
        }

        public void UpdateExecution(in Func<T, T> execution) => _NextExecution = execution;
        
        public T[] GetCurrentBuffer() => _CurrentBuffer;
    }
}
