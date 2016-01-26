
using WebApplication.Library;
using NUnit.Framework;

namespace WebApplication.Tests.Library
{
    [TestFixture]
    public class NunitUniqueObjectShould
    {

        [Test]
        public void  ReturnValue()
        {
        //Arrange
        var item1 = new UniqueObject(1);
    //Act
    var response = item1.GetbyId(1);
    //Assert
    Assert.AreEqual(item1, response);
        }
    }
}
