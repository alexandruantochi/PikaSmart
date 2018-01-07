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

            _serialPort = new SerialPort(SerialPort.GetPortNames()[0])
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            Log("Default log size set to " + logSize.ToString() + " lines.");
            Log("Created default connection with Port = first_found, BaudRade = 9600, Parity = 0, StopBits = 1, DataBits = 8, Handshake = 0");
        }

        public ArduinoConn_1(String portName)
        {
            logSize = 90;
            if (portName == "")
            {
                portName = SerialPort.GetPortNames()[0];
            }

            _serialPort = new SerialPort(portName)
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            Log("Default log size set to " + logSize.ToString() + " lines.");
            Log("Created default connection with Port = " + portName + ", BaudRade = 9600, Parity = 0, StopBits = 1, DataBits = 8, Handshake = 0");
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
            }

            catch (TimeoutException)
            {
                Log("Write operation failed due to timeout (" + TimeOut.ToString() + "ms).");
                _serialPort.Close();
            }

        }

        override public string Read()
        {
            try
            {
                _serialPort.Open();
            }
            catch (IOException)
            {
                Log("IOException thrown, not data read.");
                _serialPort.Close();
            }

            try
            {
                var _result = _serialPort.ReadLine();
                _serialPort.Close();
                return _result;
            }
            catch (TimeoutException)
            {
                Log("Read operation failed due to timeout (" + TimeOut.ToString() + "ms).");
                _serialPort.Close();
            }

            return "";
        }

        public void Timeout(int timeout)
        {
            TimeOut = timeout;
            _serialPort.ReadTimeout = TimeOut;
            _serialPort.WriteTimeout = TimeOut;
        }

    }
}
