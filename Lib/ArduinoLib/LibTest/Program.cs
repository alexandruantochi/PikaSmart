using System;
using System.Collections.Generic;
using ArduinoLib;


namespace LibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string result;
            /*
                        var options = new Dictionary<string, object>
                        {
                            ["sensorId"] = 1,
                            ["sampleTime"] = 2000,
                            ["samplingRate"] = 200,
                            ["priority"] = false
                        };

                        var opt = new ArduOptions(options);

                        var myPort = ArduConn.InitConnection(opt);

                      result = ArduConn.GetData();

                        foreach (var c in result.Split(':'))
                        {
                            Console.Write(c + " ");
                        }

                        Console.WriteLine();

                        System.Threading.Thread.Sleep(5000);

                        var new_opt = new Dictionary<string, object>()
                        {
                            ["sensorId"] = 2,
                            ["sampleTime"] = 5000,
                            ["samplingRate"] = 500,
                            ["priority"] = false
                        };




                        ArduConn.SetOption(new ArduOptions(new_opt));

                        result = ArduConn.GetData();

                        foreach (var c in result.Split(':'))
                        {
                            Console.Write(c + " ");
                        }

                        Console.WriteLine();

                        System.Threading.Thread.Sleep(5000);

            
                */



            var new_opt_2 = new Dictionary<string, object>()
            {
                ["mockData"] = "true",
                ["returnData"] = "200:testok:mockData:200"
            };

            ArduConn.SetOption(new ArduOptions(new_opt_2));
            result = ArduConn.GetData();

            foreach (var c in result.Split(':'))
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            Console.ReadLine();


        }
    }
}
