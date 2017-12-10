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

    class DynamicArrayQueue<T>
    {
        DynamicArray<T> queue;
        int Front;
        int Rear;
        public DynamicArrayQueue()
        {
            queue = new DynamicArray<T>();
            Front = -1;
            Rear = -1;
        }

        public bool IsEmpty()
        {
            return (Front == -1 || Front > Rear);
        }

        public void Queue(Object value)
        {
            if (IsEmpty())
            {
                Front++;
            }

            Rear++;
            queue.Put(value);
        }

        public int GetSize()
        {
            return queue.GetSize();
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

    class DoubleLInkedListQueue<T>
    {
        LinkedDoubleList<T> queue;

        NodeDouble Front;
        NodeDouble Rear;

        public DoubleLInkedListQueue()
        {
            queue = new LinkedDoubleList<T>();
            Front = null;
            Rear = null;
        }

        public bool IsEmpty()
        {
            return (Rear == null || Front == null);
        }

        public void Queue(Object value)
        {
            NodeDouble node = new NodeDouble(value, null, null);

            if (IsEmpty())
            {
                Rear = node;
                Front = node;
            }

            Rear.Next = node;
            node.Previous = Rear;
            Rear = node;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            T value = (T)Front.Value;

            Front = Front.Next;
            if (Front != null)
              Front.Previous = null;
            return value;
        }
    }

}
