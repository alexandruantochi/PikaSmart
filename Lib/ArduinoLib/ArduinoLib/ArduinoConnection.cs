using System;


namespace ArduinoLib
{
    public static class ArduinoConnection
    {
        private static IConnection conn = null;

        public static IConnection Build()
        {
            return new ArduinoConn_1();
        }

        public static IConnection Build(String port)
        {
            return new ArduinoConn_1(port);
        }

        public static IConnection Build(int type)
        {
            throw new NotImplementedException();
        }
    }
}
