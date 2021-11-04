using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogBuffer
{
    class LogBuffer
    {
        public List<Message> log = new List<Message>();
        public int messageLimit;
        private string path;
        private object lockObj = new object();
        private object lockWriteObj = new object();
        private Timer timer;

        public LogBuffer(int messageLimit, string path, int period)
        {
            this.messageLimit = messageLimit;
            this.path = path;
            TimerCallback tm = new TimerCallback(WriteToFile);
            this.timer = new Timer(tm, 0, 0, period);
        }

        public async void Add(Message item)
        {
            bool overflow = false;
            lock (lockObj)
            {
                log.Add(item);
                overflow = log.Count >= messageLimit;
            }

            if (overflow)
            {
                await Task.Run(() => WriteToFile(null));
            }
        }

        public void WriteToFile(object obj)
        {
            List<Message> buffer;
            lock(lockObj)
            {
                buffer = new List<Message>(log);
                log.Clear();
            }

            lock(lockWriteObj)
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    foreach (Message msg in buffer)
                    {
                        writer.WriteLine(msg.ToString());
                        Console.WriteLine(msg.ToString());
                    }
                }
            }
        }
    }
}
