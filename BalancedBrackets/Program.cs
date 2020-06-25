using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedBrackets
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/balanced-brackets/problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "{[()]}";
            string s2 = "{[(])}";
            string s3 = "{{[[(())]]}}";

            Console.WriteLine("Is Balanced? " + isBalanced(s1));
            Console.WriteLine("Is Balanced? " + isBalanced(s2));
            Console.WriteLine("Is Balanced? " + isBalanced(s3));
        }

        static string isBalanced(string s)
        {
            string isBalanced = "NO";

            if (string.IsNullOrEmpty(s))
            {
                return isBalanced;
            }

            Dictionary<char, char> pairsBrackets = new Dictionary<char, char>();
            pairsBrackets.Add('(', ')');
            pairsBrackets.Add('{', '}');
            pairsBrackets.Add('[', ']');

            List<char> openBrackets = pairsBrackets.Keys.ToList();

            char[] bracketsToCheck = s.ToCharArray();

            Stack<char> allOpenBrackets = new Stack<char>();

            foreach(char itemToCheck in bracketsToCheck)
            {
                if (allOpenBrackets.Count == 0 && !openBrackets.Contains(itemToCheck))
                {
                    return isBalanced;
                }
                else
                {
                    if (openBrackets.Contains(itemToCheck))
                    {
                        allOpenBrackets.Push(itemToCheck);
                    }
                    else
                    {
                        char lastOpenBracket = allOpenBrackets.Pop();
                        if(pairsBrackets[lastOpenBracket] != itemToCheck)
                        {
                            return isBalanced;
                        }
                    }
                }
            }

            if(allOpenBrackets.Count == 0)
            {
                isBalanced = "YES";
            }

            return isBalanced;
        }
    }
}
