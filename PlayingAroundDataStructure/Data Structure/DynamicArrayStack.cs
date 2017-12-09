using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class DynamicArrayStack<T>
    {
        DynamicArray<T> stack;        
        int Size = 0;
        int Top;

        public DynamicArrayStack(int size)
        {
            this.Size = size;
            stack = new DynamicArray<T>();
            Top = -1;
        }

        public bool IsFull()
        {
            return Top == Size - 1;
        }

        public bool IsEmpty()
        {
            return Top == -1;
        }

        public StackError Push(object value)
        {
            if (IsFull())
            {
                return StackError.StackOverFlow;
            }

            Top++;
            stack.Put(value);
            return StackError.Success;
        }

        public int GetSize()
        {
            return stack.GetSize();
        }
        public T Pop()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            T item = (T)stack[Top];
            Top--;
            return item;
        }
    }
}
