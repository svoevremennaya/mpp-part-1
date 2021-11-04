using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogBuffer
{
    class Program
    {
        public static LogBuffer logBuffer = new LogBuffer(20, "log.txt", 2000);

        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
            {
                logBuffer.Add(new Message(Message.MessageType.Information, $"{i}"));
                Thread.Sleep(200);
            }

            for (int i = 0; i < 10; i++)
            {
                logBuffer.Add(new Message(Message.MessageType.Error, $"{i}"));
                Thread.Sleep(200);
            }
            Console.ReadLine();
        }
    }
}
