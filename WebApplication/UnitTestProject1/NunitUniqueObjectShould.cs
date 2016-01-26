
using WebApplication.Library;
using NUnit.Framework;

namespace WebApplication.Tests.Library
{
    [TestFixture]
    public class NunitUniqueObjectShould
    {

        [Test]
        public void returnSameObjectasInserted()
        {
            //Arrange
            var item1 = new UniqueObject(0);
            //Act
            var response = UniqueObject.GetbyId(0);
            //Assert
            Assert.AreEqual(item1, response);
        }

        [Test]
        public void returnSameObjectasInsertedwithMultiple()
        {
            //Arrange
            var item1 = new UniqueObject(1);
            var item2 = new UniqueObject(2);
            var item3 = new UniqueObject(3);
            //Act
            var response1 = UniqueObject.GetbyId(1);
            var response2 = UniqueObject.GetbyId(2);
            var response3 = UniqueObject.GetbyId(3);
            //Assert
            Assert.AreEqual(response3, item3);
        }

        [Test]
        public void returnSameObjectasInsertedwithMultipleFailed()
        {
            //Arrange
            var item1 = new UniqueObject(4);
            var item2 = new UniqueObject(5);
            var item3 = new UniqueObject(6);
            //Act
            var response1 = UniqueObject.GetbyId(4);
            var response2 = UniqueObject.GetbyId(5);
            var response3 = UniqueObject.GetbyId(6);
            //Assert
            Assert.AreEqual(response3, item3);
        }
    }
}
