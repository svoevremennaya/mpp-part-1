using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolCopyFiles
{
    public class TaskQueue
    {
        public List<Thread> pool = new List<Thread>();
        public List<bool> workingThreads = new List<bool>();
        public Queue<string> taskQueue = new Queue<string>();
        public int copiedFiles;
        public string destPath;
        private object obj = new object();

        public TaskQueue(int threadNumber, string dest)
        {
            this.destPath = dest;
            this.copiedFiles = 0;

            for (int i = 0; i < threadNumber; i++)
            {
                Thread thread = new Thread(ExecuteTask);
                thread.Name = Convert.ToString(i);
                thread.IsBackground = true;
                pool.Add(thread);
                workingThreads.Add(false);
                thread.Start();
            }
        }

        public void EnqueueTask(string file)
        {
            taskQueue.Enqueue(file);
        }

        public void ExecuteTask()
        {

            workingThreads[Convert.ToInt32(Thread.CurrentThread.Name)] = true;
            while (Thread.CurrentThread.IsBackground)
            {
                lock (obj)
                {
                    if (taskQueue.Count > 0)
                    {
                        string path = taskQueue.Dequeue();

                        if (path != null)
                        {
                            CopyFile(path);
                        }
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
            }
            workingThreads[Convert.ToInt32(Thread.CurrentThread.Name)] = false;
        }

        public void CopyFile(string srcPath)
        {
            FileInfo file = new FileInfo(srcPath);
            file.CopyTo(Path.Combine(destPath, file.Name));
            lock (obj)
            {
                copiedFiles++;
            }

            Console.WriteLine($"{srcPath} copied");
        }

        public void AbortThreads()
        {
            foreach (var thread in pool)
            {
                thread.IsBackground = false;
            }
        }
    }
}
