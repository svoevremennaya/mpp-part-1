using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    public class TaskQueue
    {
        public List<Thread> pool = new List<Thread>();
        public Queue<TaskDelegate> taskQueue = new Queue<TaskDelegate>();

        public TaskQueue(int threadNumber)
        {
            for (int i = 0; i < threadNumber; i++)
            {
                Thread thread = new Thread(ExecuteTask);
                thread.Name = Convert.ToString(i + 1);
                thread.IsBackground = true;
                pool.Add(thread);
                thread.Start();
            }
        }

        public void EnqueueTask(TaskDelegate taskDelegate)
        {
            taskQueue.Enqueue(taskDelegate);
        }

        public void ExecuteTask()
        {
            while (Thread.CurrentThread.IsBackground)
            {
                if (taskQueue.Count > 0)
                {
                    TaskDelegate task = taskQueue.Dequeue();
                    if (task != null)
                    {
                        task();
                    }
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
        }
    }
}
