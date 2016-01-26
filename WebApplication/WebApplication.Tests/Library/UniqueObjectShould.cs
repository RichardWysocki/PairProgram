using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Library;

namespace WebApplication.Tests.Library
{
    [TestClass]
    public class UniqueObjectShould
    {

        [TestMethod]
        public void WhenGiveDataValidation()
        {
            //Arrange
            var item1 = new UniqueObject(1);
            //Act
            var response = UniqueObject.GetbyId(1);
            //Assert
            Assert.AreEqual(item1, response);
        }
    }
}
