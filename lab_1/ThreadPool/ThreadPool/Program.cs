using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    public delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of threads: ");
            int numberThreads = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input the number of tasks: ");
            int numberTasks = Convert.ToInt32(Console.ReadLine());

            TaskQueue taskQueue = new TaskQueue(numberThreads);

            for (int i = 0; i < numberTasks; i++)
            {
                taskQueue.EnqueueTask(Print);

            }

            Console.ReadLine();
        }

        static public void Print()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} executes task");
        }
    }
}
