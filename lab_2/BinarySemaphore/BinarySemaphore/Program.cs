using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinarySemaphore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread = new Thread(ShowMutex);
            thread.Start();
            Console.ReadLine();

            OSHandle oshandle = new OSHandle(1024);
            Console.WriteLine(oshandle.Handle);
            oshandle.Dispose();
            Console.ReadLine();
        }

        public static void ShowMutex()
        {
            Mutex mutex = new Mutex();
            try
            {
                mutex.Lock();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }
            finally
            {
                mutex.Unlock();
            }
        }
    }
}
