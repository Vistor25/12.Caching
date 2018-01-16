using ClassLibrary1;
using NorthwindLibrary;
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
            FibonachiCaching fb = new FibonachiCaching();
            for(int i = 0; i<=1000; i++)
            {
                Console.WriteLine(fb.Fibonachi(i));
            }
            Console.WriteLine("----------------------------------");
            
            DBWorker.DBWorker<Region> worker = new DBWorker.DBWorker<Region>();
            
            var regions = worker.GetEntities();
            
            var otherRegions = worker.GetEntities();
        }
    }
}
