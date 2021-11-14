using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback[] delegates = { DoWork, DoWork, DoWork, DoWork, DoWork, DoWork };

            Parallel.WaitAll(delegates);
            Console.ReadLine();
        }

        static void DoWork(object obj)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(200);
        }
    }
}
