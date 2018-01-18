using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ArduinoLib;

namespace LibTest
{
    class Program
    {

        public static void Main()
        {
            Console.WriteLine("Init");

            var conn = ArduinoConnection.Build();
            int sensorId = 0;
            conn.LogToConsole();
            conn.PrintLogToConsole();

            while (true)
            {
                sensorId = (sensorId + 1) % 4;
                Thread.Sleep(3000);
                conn.Write(sensorId.ToString());
                conn.Read();
                Thread.Sleep(3000);
                conn.Write("10");
                conn.Read();
            }



        }
    }
}
