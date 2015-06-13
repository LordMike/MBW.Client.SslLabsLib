using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SslLabsLib.Objects;

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

    [TestClass]
    public class StatusCodeTests
    {
        [TestMethod]
        public void StatusCodeTest()
        {
            SslLabsClient client = new SslLabsClient();

            StatusCodes codes = client.GetStatusCodes();
            Assert.IsNotNull(codes);
        }
    }
}
