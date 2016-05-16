

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UniversalWIndows.Library.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var x = 1;
            Assert.AreEqual(1,x,"are equal");
        }
    }
}
