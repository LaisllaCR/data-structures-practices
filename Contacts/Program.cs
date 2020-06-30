using System;

namespace Contacts
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/contacts/problem
    /// </summary>
    class Program
    {
        public class Node
        {
            public char value;
            public Node[] child = new Node[26];
            public int total;
            public bool isLeafNode;

            public Node(char val, bool leafNode, int count)
            {
                value = val;
                isLeafNode = leafNode;
                total = count;
            }
        }

        static Node root;

        static void Main(string[] args)
        {
            int n = 4;
            string[] operations = new string[n];
            operations[0] = "add hack";
            operations[1] = "add hackerrank";
            operations[2] = "find hac";
            operations[3] = "find hak";

            root = new Node(' ', false, 0);

            ProcessOperations(operations);
        }

        static void ProcessOperations(string[] operations)
        {
            if (operations.Length == 0)
            {
                return;
            }

            string operationTypeAdd = "add";
            string operationTypeFind = "find";
            foreach (string operation in operations)
            {
                string[] operationOperators = operation.Split(" ");
                string operationToPerform = operationOperators[0];
                string operationName = operationOperators[1];

                if (operationToPerform == operationTypeAdd)
                {
                    InsertContact(operationName);
                }else if(operationToPerform == operationTypeFind)
                {
                    Console.WriteLine(FindContact(operationName));
                }
            }
        }

        static void InsertContact(string newContact)
        {
            if (newContact.Length == 0)
            {
                return;
            }

            Node current = root;
            char[] newContactLetters = newContact.ToCharArray();
            char aStartPoint = 'a';
            foreach(char letter in newContactLetters)
            {
                Node newNode = current.child[letter - aStartPoint];

                if(newNode == null)
                {
                    current.child[letter - aStartPoint] = new Node(letter, false, 1);
                }
                else
                {
                    current.child[letter - aStartPoint].total = current.child[letter - aStartPoint].total + 1;
                }
                current = current.child[letter - aStartPoint];
            }
            current.isLeafNode = true;
        }

        static int FindContact(string nameToSearch)
        {
            int totalContactFound = 0;

            if(nameToSearch.Length == 0)
            {
                return totalContactFound;
            }

            Node current = root;
            char aStartPoint = 'a';

            foreach (char letter in nameToSearch)
            {
                if(!CheckContainLetter(current, letter))
                {
                    return totalContactFound;
                }
                else
                {
                    current = current.child[letter - aStartPoint];
                }
            }

            return current.total;
        }

        static bool CheckContainLetter(Node current, char letter)
        {
            for(int i = 0; i < 26; i++)
            {
                if(current.child[i] != null)
                {
                    if(current.child[i].value == letter)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}