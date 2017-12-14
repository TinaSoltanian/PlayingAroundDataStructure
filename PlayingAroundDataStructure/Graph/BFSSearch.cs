using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class BFSSearch
    {
        public AdjecyList[] array;
        public int Size { get; set; }

        public BFSSearch(int size)
        {
            this.Size = size;
            array = new AdjecyList[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = new AdjecyList();
                array[i].Head = null;
            }
        }

        public void Add(int source, int destination)
        {
            GraphNode node = new GraphNode(destination, null);

            node.Next = array[source].Head;
            array[source].Head = node;
        }

        public List<string> DFSExplore(int start)
        {
            List<string> list = new List<string>();
            bool[] visited = new bool[Size];

            for (int i = 0; i < Size; i++)
            {
                visited[i] = false;
            }

            Queue<int> st = new Queue<int>();

            st.Enqueue(start);
            while (st.Count() > 0)
            {
                int n = st.Dequeue();
                visited[n] = true;
                list.Add(n.ToString());
                GraphNode head = array[n].Head;
                while (head != null)
                {
                    if (!visited[head.Value])
                    {
                        st.Enqueue(head.Value);
                        visited[head.Value] = true;
                    }
                    else
                    {
                        head = head.Next;
                    }
                }
            }

            return list;
        }
    }
}

