using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value, TreeNode right, TreeNode left)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
    class BinarySearchTree
    {
        public TreeNode Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }

        public void Add(TreeNode start, TreeNode newNode)
        {
            if (Root  == null)
            {
                Root = newNode;
                return;
            }

            if (newNode.Value > start.Value)
            {
                if (start.Right == null)
                {
                    start.Right = newNode;
                    //return;
                }
                Add(start.Right, newNode);
            }

            else if (newNode.Value < start.Value)
            {
                if (start.Left == null)
                {
                    start.Left = newNode;
                    //return;
                }
                Add(start.Left, newNode);
            }

            
        }

        public TreeNode Search(int value, TreeNode start)
        {
            if (start == null)
            {
                return null;
            }
            if (start.Value == value)
            {
                return start;
            }
            if (value > start.Value)
            {
                return Search(value, start.Right);
            }
            else if (value < start.Value)
            {
                return Search(value, start.Left);
            }

            return null;
        }

        public void Delete(int value)
        {
            Delete(value, Root);
        }

        private TreeNode Delete(int value, TreeNode start)
        {
            if (Root == null)
                return start;

            if (start.Value < value)
            {
                start.Right = Delete(value, start.Right);
            }
            else if (start.Value > value)
            {
                start.Left = Delete(value, start.Left);
            }

            else
            {

                if (start.Left == null)
                {
                    return start.Right;
                }
                else if (start.Right == null)
                {
                    return start.Left;
                }

                int min = MinimumNde(start.Right);
                start.Value = min;
                start.Right = Delete(start.Value, start.Right);
            }

            return start;
        }

        private int MinimumNde(TreeNode node)
        {
            int min = node.Value;
            while (node.Left != null)
            {
                min = node.Left.Value;
                node = node.Left;
            }

            return min;
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
