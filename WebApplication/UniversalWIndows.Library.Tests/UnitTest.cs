

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using universalwindows.library.Common;
using universalwindows.library.Models;

namespace UniversalWIndows.Library.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var b = new PersonBusiness();
            var pm = new PersonModel()
            {
                Email = "RichardWysocki@gmail.com",
                Name = "Richard Wysocki",
                Phone = "215-771-1365"
            };
            //Act
            var resoponse = b.ValidatePerson(pm);
            //Assert
            Assert.AreEqual(true, resoponse.IsValid,"");
        }
    }
}
