using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DFSSearch
    {
        public AdjecyList[] array;
        public int Size { get; set; }

        public DFSSearch(int size)
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

                Stack<int> st = new Stack<int>();

                st.Push(start);
                while(st.Count() > 0)
                {
                    int n = st.Pop();
                    st.Push(n);
                    visited[n] = true;

                    GraphNode head = array[n].Head;
                    bool isDone = true;
                    while (head != null)
                    {
                        if (!visited[head.Value])
                        {
                            st.Push(head.Value);
                            visited[head.Value] = true;
                            isDone = false;
                            break;
                        }
                        else
                        {
                            head = head.Next;
                        }
                    }

                    if (isDone)
                    {
                        int o = st.Pop();
                        list.Add(o.ToString());
                    }
                }

            return list;
        }
    }
}
