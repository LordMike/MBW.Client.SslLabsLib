using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SslLabsLib;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SslLabsClient client = new SslLabsClient();

            client.GetInfo();
        }
    }
}
