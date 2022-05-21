using System;
using System.Linq;
using System.Text;

namespace Test1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int Lnum = 0;
            int number = 1001;
            Random random = new Random();
            while (number > 0)
            {
                Lnum = number;
                number = random.Next(0, Lnum);
                Console.WriteLine(number);
            }
            // Console.WriteLine(number);
        }

    }
}
