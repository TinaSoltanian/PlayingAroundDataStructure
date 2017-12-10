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
    // Insert => O(n) this is for worst case scenario so we have to search 
    //                through the whole items and figure out where to insert
    // Delete => O(n) same like insert

    class NodeDouble
    {

        public object Value;
        public NodeDouble Next;
        public NodeDouble Previous;

        public NodeDouble(Object value, NodeDouble next, NodeDouble previous)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
    }

    class LinkedDoubleList<T>
    {
        NodeDouble Head;

        public LinkedDoubleList()
        {
            Head = null;
        }

        public void Add(Object value)
        {
            NodeDouble NodeDouble = new NodeDouble(value, null, null);

            if (Head == null)
                Head = NodeDouble;
            else
            {
                NodeDouble.Next = Head;
                Head.Previous = NodeDouble;
                Head = NodeDouble;
            }
        }

        //just first element
        public void Delete()
        {
            Head = Head.Next;
        }

        public List<string> ToStringList()
        {
            NodeDouble n = Head;
            List<string> result = new List<string>();
            while (n != null)
            {
                result.Add(n.Value.ToString());
                n = n.Next;
            }

            return result;
        }
    }
}
