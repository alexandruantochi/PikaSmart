using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;


namespace ArduinoLib
{

    public class ArduConn
    {
        private static ArduConn _instance;
        private static Dictionary<string, object> _options;
        private static SerialPort _serialPort;

        private ArduConn(ArduOptions arduOptions)
        {
            _options = arduOptions.Options;
            _serialPort = GetSerialPort();
        }

        public static ArduConn InitConnection(ArduOptions options)
        {
            return _instance ?? (_instance = new ArduConn(options));
        }

        public static void SetOption(ArduOptions arduOptions)
        {
            _options = arduOptions.Options;

        }


        public static string GetData()
        {
            string result;
            var messageValues = new[] { "id", "1000", "200", "0" };

            if (_options.ContainsKey("mockData") && _options.ContainsKey("returnData"))
            {
                if (Convert.ToBoolean(_options["mockData"]))
                {
                    return Convert.ToString(_options["returnData"]);
                }
            }

            if (!_options.ContainsKey("sensorId"))
            {
                throw new ArgumentException("Must provide sensor ID.");
            }

            messageValues[0] = Convert.ToString(_options["sensorId"]);


            if (_options.ContainsKey("sampleTime"))
            {
                messageValues[1] = Convert.ToString(_options["sampleTime"]);
            }

            if (_options.ContainsKey("samplingRate"))
            {
                messageValues[2] = Convert.ToString(_options["samplingRate"]);
            }

            if (_options.ContainsKey("priority"))
            {
                if (Convert.ToBoolean(_options["priority"]))
                {
                    messageValues[3] = Convert.ToString(_options["priority"]);
                }
            }

            var messagBuilder = new StringBuilder();
            messagBuilder.AppendJoin(':', messageValues);


            try
            {

                _serialPort.Open();
            }
            catch (IOException)
            {
                Console.WriteLine("");
                return "error";
            }


            _serialPort.WriteLine(messagBuilder.ToString());

            Console.WriteLine("Sent {0} to board.", messagBuilder.ToString());

            _serialPort.ReadTimeout = Convert.ToInt32(messageValues[1]) + 1000;


            try
            {
                result = _serialPort.ReadLine();
            }
            catch (TimeoutException)
            {
                return "timeout";
            }

            _serialPort.Close();

            return result;

        }

        private static SerialPort GetSerialPort()
        {
            var port = SerialPort.GetPortNames()[0];
            var serialPort = new SerialPort(port)
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };


            return serialPort;
        }
    }
}
