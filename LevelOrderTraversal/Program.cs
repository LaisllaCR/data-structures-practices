using System;
using System.Collections.Generic;

namespace LevelOrderTraversal
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
    /// https://www.hackerrank.com/challenges/tree-level-order-traversal/problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const int totalNodes = 6;
            int[] nodeValues = new int[totalNodes] { 1, 2, 5, 3, 6, 4 };
            Node root = new Node(nodeValues[0]);

            for(int i = 1; i < totalNodes; i++)
            {
                Insert(root, nodeValues[i]);
            }

            TraversalOrderWithBfs(root);
        }

        public static void TraversalOrderWithBfs(Node root)
        {
            if(root == null)
            {
                Console.WriteLine("No Tree.");
            }
            else
            {
                Queue<Node> queue = new Queue<Node>();

                queue.Enqueue(root);

                while(queue.Count > 0)
                {
                    for(int i = 0; i < queue.Count; i++)
                    {
                        Node current = queue.Dequeue();

                        Console.Write(current.data + " ");

                        if(current.left != null)
                        {
                            queue.Enqueue(current.left);
                        }

                        if (current.right != null)
                        {
                            queue.Enqueue(current.right);
                        }
                    }
                }
            }
        }

        public static Node Insert(Node root, int data)
        {
            if(root == null)
            {
                return new Node(data);
            }
            else
            {
                Node current = root;
                if(data <= current.data)
                {
                    current = Insert(root.left, data);
                    root.left = current;
                }
                else
                {
                    current = Insert(root.right, data);
                    root.right = current;
                }
                return root;
            }
        }
    }
}