using System;


namespace ArduinoLib
{
   

    public static class ArduinoConnection
    {

        private static readonly IConnection conn = null;

        public static IConnection Build()
        {
            if (conn == null)
            {
                return new ArduinoConn_1();
            }

            return conn;
        }

        public static IConnection Build(String port)
        {
            if (conn == null)
            {
                return new ArduinoConn_1();
            }

            return conn;
        }

        public static IConnection Build(int type)
        {
            throw new NotImplementedException();
        }
    }
}
