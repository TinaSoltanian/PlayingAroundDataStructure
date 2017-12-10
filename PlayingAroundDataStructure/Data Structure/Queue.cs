using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    enum QueueError
    {
        IsFull, IsEmpty, Success
    }
    class ArrayQueue<T>
    {

        object[] queue;
        int Front;
        int Rear;
        int Size;

        public ArrayQueue(int size)
        {
            queue = new object[size];
            Front = -1;
            Rear = -1;
            Size = size;
        }

        public bool IsFull()
        {
            return Rear == Size - 1;
        }

        public bool IsEmpty()
        {
            return (Front == -1 || Front>Rear);
        }

        public QueueError Queue(Object value)
        {
            if (IsFull())
            {
                return QueueError.IsFull;
            }

            if (IsEmpty())
            {
                Front++;
            }

            Rear++;
            queue[Rear] = value;
            return QueueError.Success;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            T value = (T)queue[Front];

            Front++;
            return value;
        }

    }
}
