using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structure
{
    //this are Big O for linked list    
    // search => O(n)
    // access => O(n) we have to search through items to find it
    // Insert => O(n) this is for worst case scenario so we have to search 
    //                through the whole items and figure out where to insert
    // Delete => O(n) same like insert

    class Node
    {
        public object Value;
        public Node Next;

        public Node(Object value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    class LinkedList<T>
    {
        Node Head;

        public LinkedList()
        {
            Head = null;
        }

        public void Add(Object value)
        {
            Node node = new Node(value, null);

            if (Head == null)
                Head = node;
            else
            {
                node.Next = Head;
                Head = node;
            }
        }

        //just first element
        public void Delete()
        {
            Head = Head.Next;
        }

        public List<string> ToStringList()
        {
            Node n = Head;
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
