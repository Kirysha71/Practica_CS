using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class CircularBufferManager<T>
    {
        private readonly MyCircularBuffer<T> _buffer;

        public CircularBufferManager(int capacity)
        {
            _buffer = new MyCircularBuffer<T>(capacity);
        }

        public void AddItem(T item)
        {
            _buffer.Add(item);
        }

        public T GetOldest()
        {
            return _buffer.Remove();
        }

        public T GetNewest()
        {
            return _buffer.Peek();
        }

        public int Count => _buffer.Count;
    }
}
