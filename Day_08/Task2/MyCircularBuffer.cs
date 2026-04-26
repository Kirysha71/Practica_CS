using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class MyCircularBuffer<T>
    {
        private readonly Queue<T> _buffer;
        private readonly int _capacity;

        public MyCircularBuffer(int capacity)
        {
            _capacity = capacity;
            _buffer = new Queue<T>();
        }

        public void Add(T item)
        {
            if(_buffer.Count >= _capacity)
            {
                _buffer.Dequeue();
            }
            _buffer.Enqueue(item);
        }

        public T Remove()
        {
            if (_buffer.Count == 0)
                throw new InvalidOperationException("Буфер пуст");

            return _buffer.Dequeue();
        }

        public T Peek()
        {
            if (_buffer.Count == 0)
                throw new InvalidOperationException("Буфер пуст");

            return _buffer.Peek();
        }

        public int Count => _buffer.Count;
    }
}
