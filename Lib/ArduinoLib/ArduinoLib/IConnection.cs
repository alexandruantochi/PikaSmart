using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoLib
{
    public abstract class IConnection
    {

        protected Queue<String> log = new Queue<String>();
        protected int logSize;
        private bool logToConsole = false;

        public abstract void Write(string data);
        public abstract string Read();

        protected void Log(String message)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendJoin("", new List<String> { "[", DateTime.Now.ToString("HH:mm:ss"), "] ", message });

            if (log.Count > logSize)
            {
                log.Dequeue();
            }

            if (logToConsole)
            {
                Console.WriteLine(builder.ToString());
            }

            log.Enqueue(builder.ToString());
        }

        public void LogToConsole()
        {
            if (logToConsole)
            {
                logToConsole = false;
                return;
            }

            logToConsole = true;
        }

        public List<String> GetLog()
        {
            return new List<String>(log.ToArray());
        }

        public void PrintLogToConsole()
        {
            foreach (var line in log)
            {
                Console.WriteLine(line);
            }
        }

    }
}
