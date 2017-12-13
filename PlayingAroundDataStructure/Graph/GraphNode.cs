using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{

    class GraphNode
    {
        public int Value { get; set; }
        public GraphNode Next { get; set; }

        public GraphNode(int value, GraphNode next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
