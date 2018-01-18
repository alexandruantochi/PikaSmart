using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Specialized;


namespace ArduinoLib
{

    internal class ArduinoConn_1 : IConnection
    {
        private readonly SerialPort _serialPort;

        public int TimeOut { get; private set; } = 5000;

        public ArduinoConn_1()
        {
            logSize = 90;

            var port = SerialPort.GetPortNames()[0];

            _serialPort = new SerialPort(port)
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            Log("Default log size set to " + logSize.ToString() + " lines.");
            Log("Created default connection with Port = " + port + ", BaudRade = 9600, Parity = 0, StopBits = 1, DataBits = 8, Handshake = 0");

            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        public ArduinoConn_1(String port)
        {
            logSize = 90;
            if (port == "")
            {
                port = SerialPort.GetPortNames()[0];
            }

            _serialPort = new SerialPort(port)
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            Log("Default log size set to " + logSize.ToString() + " lines.");
            Log("Created default connection with Port = " + port + ", BaudRade = 9600, Parity = 0, StopBits = 1, DataBits = 8, Handshake = 0");
        }

        private ArduinoConn_1(StringDictionary options)
        {
            throw new NotImplementedException();
        }


        override public void Write(string data)
        {

            try
            {
                _serialPort.Open();
            }
            catch (IOException)
            {
                Log("IOException thrown, not data read.");
            }

            try
            {
                _serialPort.WriteLine(data);
                _serialPort.Close();
                Log("Wrote: " + data);
            }

            catch (TimeoutException)
            {
                Log("Write operation failed due to timeout (" + TimeOut.ToString() + "ms).");
                _serialPort.Close();
            }

        }

        override public string Read()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }

            try
            {
              
                _serialPort.Open();
                var _result = _serialPort.ReadLine();
                _serialPort.Close();
                Log("Read: " + _result);
                return _result;
            }
            catch (TimeoutException)
            {
                Log("Read operation failed due to timeout (" + TimeOut.ToString() + "ms).");
            }
            finally
            {
                _serialPort.Close();
            }

            Log("Unknown reading error.");
            return "";
        }

        public void Timeout(int timeout)
        {
            TimeOut = timeout;
            _serialPort.ReadTimeout = TimeOut;
            _serialPort.WriteTimeout = TimeOut;
        }

        override public void Dispose()
        {
            _serialPort.Dispose();
        }

    }
}
