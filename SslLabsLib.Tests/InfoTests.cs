using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SslLabsLib.Tests
{
    [TestClass]
    public class InfoTests
    {
        [TestMethod]
        public void InfoTest()
        {
            SslLabsClient client = new SslLabsClient();

            Info info = client.GetInfo();
            Assert.IsNotNull(info);
        }
    }
}
