using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringyThings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseStringWithLinq("hello World"));
            Console.WriteLine("==============================");
            Console.WriteLine(ReverseStringWithLoop("hello World"));
            Console.WriteLine(HasUniqueChars("hello"));
            Console.WriteLine(HasUniqueChars("toast"));
            Console.WriteLine(HasUniqueChars("Louise"));

            Console.ReadLine();
        }

        static string ReverseStringWithLinq(string s)
        {
            var test = s.Reverse();
            return new string(test.ToArray());
        }

        static string ReverseStringWithLoop(string s)
        {
            var chars = s.ToArray<char>();
            var result = "";
            for( int i = s.Length - 1; i >= 0; i--)
            {
                result = result + chars[i];
            }
            return result;
        }

        //How to make sure a string is balanced with regard bracket types
        //use a stack

        static bool HasUniqueChars(string s)
        {
            bool[] charSet = new bool[256];
            for (int i = 0; i < s.Length; i++)
            {
                int val = s[i];
                if (charSet[val]) return false;
                charSet[val] = true;
            }
            return true;
        }
    }
}
