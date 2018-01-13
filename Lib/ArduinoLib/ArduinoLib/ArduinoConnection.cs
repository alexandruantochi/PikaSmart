using System;


namespace ArduinoLib
{
    static class ArduinoConnection
    {
        static IConnection Build()
        {
            return new ArduinoConn_1();
        }

        static IConnection Build(String port)
        {
            return new ArduinoConn_1(port);
        }

        static IConnection Build(int type)
        {
            throw new NotImplementedException();
        }
    }
}
