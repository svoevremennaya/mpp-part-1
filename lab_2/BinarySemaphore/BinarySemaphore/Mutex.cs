﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinarySemaphore
{
    public class Mutex
    {
        public static int currentThreadID = Thread.CurrentThread.ManagedThreadId;
        public int lockedThread = 0;
        public int unlockedThread = 0;

        public void Lock()
        {
            SpinWait spinner = new SpinWait();
            while (Interlocked.CompareExchange(ref lockedThread, currentThreadID, unlockedThread) != unlockedThread)
            {
                spinner.SpinOnce();
            }
        }

        public void Unlock()
        {
            if (Interlocked.CompareExchange(ref lockedThread, 0, currentThreadID) != currentThreadID)
            {
                return;
            }
        }
    }
}
