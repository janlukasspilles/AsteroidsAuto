using AsteroidsControllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace AsteroidsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UdpClient client = new UdpClient("127.0.0.1", 1979))
            {
                byte[] bytes = client.ReceiveAsync().Result.Buffer;
                for (int i = 0; i < bytes.Length; i++)
                {

                }
            }
        }
    }
}
