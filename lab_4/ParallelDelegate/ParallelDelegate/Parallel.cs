using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDelegate
{
    class Parallel
    {
        public static void WaitAll(WaitCallback[] delegates)
        {
            foreach(var task in delegates)
            {
                ThreadPool.QueueUserWorkItem(task);
            }

            ThreadPool.GetMaxThreads(out int maxThreads, out int maxIO);
            bool done = false;
            while (!done)
            {
                ThreadPool.GetAvailableThreads(out int availableThreads, out int IO);
                if (maxThreads == availableThreads)
                {
                    done = true;
                }
                else {
                    Thread.Yield();
                }
            }
        }
    }
}
