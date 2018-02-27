using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumberNotString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseInt(23));
            Console.WriteLine(ReverseInt(235));
            Console.WriteLine(ReverseInt(515));


            Console.ReadLine();

        }


        public static int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

    }
}
