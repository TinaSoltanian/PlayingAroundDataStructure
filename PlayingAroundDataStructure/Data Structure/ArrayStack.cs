using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    //this are Big O for Double linked list    
    // search => O(n)
    // access => O(n) we have to search through items to find it
    // Insert => O(1) because we are adding on top
    // Delete => O(1) and removing last inserted 

    enum StackError {
        Success,
        StackOverFlow,
        StackUnderFlow
    }
    class ArrayStack<T>
    {
        object[] stack;
        int Size = 0;
        int Top;

        public ArrayStack(int size)
        {
            this.Size = size;
            stack = new object[size];
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
            stack[Top] = value;
            return StackError.Success;
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
