using System;

namespace HeightBinaryTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int value)
        {
            data = value;
        }
    }

    /// <summary>
    /// https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree/problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const int totalNodes = 7;
            int[] nodesValues = new int[totalNodes] { 3, 5, 2, 1, 4, 6, 7 };
            
            Node root = new Node(nodesValues[0]);

            for(int i = 1; i < totalNodes; i++)
            {
                Insert(root, nodesValues[i]);
            }

            int height = GetTreeHeight(root);

            Console.WriteLine("Height of the Binary Tree: "+ height);
        }

        public static int GetTreeHeight(Node root)
        {
            if(root == null)
            {
                return -1;
            }

            int left = GetTreeHeight(root.left);
            int right = GetTreeHeight(root.right);

            return Math.Max(left, right) + 1;
        }

        public static Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = Insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = Insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }
    }
}
