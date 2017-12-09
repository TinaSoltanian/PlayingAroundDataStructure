using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    class LinkedListStack<T>
    {
        Node Top;

        public LinkedListStack()
        {
            Top = null;
        }

        public void Puch(Object value)
        {
            Node node = new Node(value, null);

            if (Top == null)
                Top = node;
            else
            {
                node.Next = Top;
                Top = node;
            }
        }

        //just first element
        public T Pop()
        {
            if (Top== null)
            {
                return default(T);
            }

            T value = (T)Top.Value;
            Top = Top.Next;
            return value;
        }
    }
   
}
