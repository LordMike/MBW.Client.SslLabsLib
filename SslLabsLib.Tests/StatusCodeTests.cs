using Microsoft.VisualStudio.TestTools.UnitTesting;
using SslLabsLib.Objects;

namespace SslLabsLib.Tests
{
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