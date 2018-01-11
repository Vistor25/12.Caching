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
            Console.ReadKey();
        }
    }
}
