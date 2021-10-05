using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolCopyFiles
{
    public delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            string srcPath, destPath;

            if (args.Length != 2)
            {
                Console.Write("Input the source path: ");
                srcPath = Console.ReadLine();
                Console.Write("Input the destination path: ");
                destPath = Console.ReadLine();
            }
            else
            {
                srcPath = args[0];
                destPath = args[1];
            }

            TaskQueue taskQueue = new TaskQueue(500, destPath);
            string [] files = Directory.GetFiles(srcPath);

            foreach (var file in files)
            {
                taskQueue.EnqueueTask(file);
            }

            while (taskQueue.taskQueue.Count > 0) { };
            taskQueue.AbortThreads();
            while (taskQueue.workingThreads.Contains(true)) { };
            Console.WriteLine();
            Console.WriteLine($"Copied {taskQueue.copiedFiles} files");
            Console.ReadLine();
        }
    }
}
