using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T>
    {
        public int Size;
        public Object[] Data;

        public DynamicArray()
        {
            Size = 0;
            Data = new Object[1];
        }

        public int GetSize()
        {
            return Data.Length;
        }

        public T Get(int index)
        {
            if (Data[index] == null)
                return default(T);

            return (T)Data[index];
        }

        public T this[int index]
        {
            get
            {
                return Get(index);
            }
        }

        public void EnsureCapacity(int size)
        {
            int oldSize = GetSize();
            if (size > oldSize)
            {
                int newSize = oldSize * 2;
                if (newSize < size)
                    newSize = size;
                
                Array.Resize(ref Data, newSize);
            }

        }

        public void Put(Object item)
        {
            EnsureCapacity(Size + 1);
            Data[Size++] = item;
        }
    }
}
