using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubTree
{
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }

        public TreeNode(int value) : this(value, null, null, null)
        {
        }

        public TreeNode(int value, TreeNode left, TreeNode right, TreeNode parent)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Parent = parent;
        }
    }

    class FindSubTree
    {
        public TreeNode Root;

        public FindSubTree()
        {

        }

        public List<int> SplitTree(int value)
        {
            List<int> list = new List<int>();
            TreeNode splitNode = Search(value, Root);

            int first = Count(splitNode.Right);
            int second = Count(splitNode.Left);

            if (first > 0)
                list.Add(first);

            if (second > 0)
                list.Add(second);

            int rest = 0;
            while (splitNode.Parent != null)
            {
                rest++;
                TreeNode parent = splitNode.Parent;
                if (parent.Right == splitNode)
                {
                    rest += Count(parent.Left);
                }
                else if (parent.Left == splitNode)
                {
                    rest += Count(parent.Right);
                }

                splitNode = parent;
            }

            if (rest > 0)
                list.Add(rest);

            return list;
        }

        public int Count(TreeNode node)
        {
            int c = 1;

            if (node == null)
            {
                return 0;
            }
            else
            {
                c += Count(node.Right);
                c += Count(node.Left);
                return c;
            }
            
        }

        public void Add(int value)
        {
            DoAdd(value, Root);
        }

        public void DoAdd(int value, TreeNode startNode)
        {
            TreeNode node = new TreeNode(value);

            if (Root == null)
            {
                Root = node;
                return;
            }

            if (value > startNode.Value)
            {
                if (startNode.Right == null)
                {
                    node.Parent = startNode;
                    startNode.Right = node;
                    return;
                }

                DoAdd(value, startNode.Right);
            }
            else if (value < startNode.Value){

                if (startNode.Left == null)
                {
                    node.Parent = startNode;
                    startNode.Left = node;
                    return;
                }
                DoAdd(value, startNode.Left);
            }
        }

        public TreeNode Search(int value, TreeNode startNode)
        {
            if (Root == null)
                return null;

            if (value == startNode.Value)
            {
                return startNode;
            }
            if (value > startNode.Value)
            {
                return Search(value, startNode.Right);
            }
            else if (value < startNode.Value)
            {
                return Search(value, startNode.Left);
            }

            return null;
        }

        public void PrintTree(TreeNode node, List<string> result, int space)
        {
            if (node == null)
            {
                return;
            }

            space += 10;

            PrintTree(node.Right, result, space);

            string tmp = "";
            for (int i = 0; i < space; i++)
            {
                tmp += " ";
            }
            tmp += node.Value.ToString();

            result.Add(tmp);

            PrintTree(node.Left, result, space);
        }


    }
}
