using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 fb = new Class1();
            for(int i = 0; i<=1000; i++)
            {
                Console.WriteLine(fb.Fibonachi(i));
            }
            Console.WriteLine("----------------------------------");
            Class2 fb1 = new Class2("localhost");
            for (int i = 0; i <= 1000; i++)
            {
                Console.WriteLine(fb1.Fibonachi(i));
            }
            Console.ReadKey();
        }
    }
}
