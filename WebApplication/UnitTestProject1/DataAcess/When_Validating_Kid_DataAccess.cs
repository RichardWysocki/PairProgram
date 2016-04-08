using System;
using NUnit.Framework;
using WebApplication.Library.DataAccess;
using WebApplication.Library.Models;
using WebApplication.Library.Utilities;

namespace UnitTestProject1.DataAcess
{
    // Given_When_Then
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class When_Validating_Kid_DataAccess
    {
        private int _integrationDelete;
        private int _integrationForUpdate;

        [Test]
        public void Null_KidDataAccess_Insert_ThrowError()
        {
            // Arrange
            var addKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => addKid.Insert(null) );
        }

        [Test]
        public void EmptyRecord_KidDataAccess_Insert_ThrowError()
        {
            // Arrange
            var newKid = new Kid();
            var addKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => addKid.Insert(newKid));

        }

        [Test]
        [TestCase("Allison","AllisonJadeWysocki@gmail.com")]
        public void Valid_KidDataAccess_Insert_AddsKid(string name, string email)
        {
            // Arrange
            var newKid = new Kid();
            newKid.Name = name;
            newKid.Email = email;
            var addKid = new KidDataAccess();

            // Act
            var result = addKid.Insert(newKid);

            // Assert
            Assert.AreEqual(true, result, "We should have Inserted the Record");
        }

        [Test]
        public void Null_KidDataAccess_Update_ThrowError()
        {
            // Arrange
            var addKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => addKid.Update(null));

        }

        [Test]
        public void EmptyRecord_KidDataAccess_Update_ThrowError()
        {
            // Arrange
            var newKid = new Kid();
            var addKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => addKid.Update(newKid));

        }

        [Test]
        [TestCase("Richard", "RichardWysocki@gmail.com")]
        public void Valid_KidDataAccess_Update_updateKid(string name, string email)
        {
            // Arrange
            var updateKid = new Kid();
            updateKid.KidID = _integrationForUpdate;
            updateKid.Name = name;
            updateKid.Email = email;
            var addKid = new KidDataAccess();

            // Act
            var result = addKid.Update(updateKid);

            // Assert
            Assert.AreEqual(true, result, "We should have Updated the Record");

        }

        [Test]
        public void EmptyRecord_KidDataAccess_Delete_ThrowError()
        {
            // Arrange
            var deleteID = 0;
            var addKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => addKid.Delete(deleteID));

        }

        [Test]
        public void Valid_KidDataAccess_Delete_deleteKid()
        {
            // Arrange
            var deleteId = _integrationDelete;
            var deleteKid = new KidDataAccess();

            // Act
            var result = deleteKid.Delete(deleteId);

            // Assert
            Assert.AreEqual(true, result, "We should have Deleted the Record");

        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void InValidKidID_KidDataAccess_Delete_deleteKid()
        {
            // Arrange
            var deleteId = 999;
            var deleteKid = new KidDataAccess();

            // Act
            var result = deleteKid.Delete(deleteId);

            // Assert
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            _integrationDelete = TestHelperUtility.ExecuteInsert(@"INSERT INTO XKid(Name, Email) Values('MaggiWysocki','MagiWysocki@gmail.com')");

            _integrationForUpdate = TestHelperUtility.ExecuteInsert(@"INSERT INTO XKid(Name, Email) Values('Rich','RichardWysocki@gmail.com')");

            TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'","Allison","AllisonJadeWysocki@gmail.com"));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            var deleteInsert = TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'", "Allison", "AllisonJadeWysocki@gmail.com"));
            if (deleteInsert > 0)
                TestHelperUtility.Delete(string.Format("Delete XKid where KidID={0}", deleteInsert));

            var deleteUpdate = TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'", "Richard", "RichardWysocki@gmail.com"));
            if (deleteUpdate > 0)
                TestHelperUtility.Delete(string.Format("Delete XKid where KidID={0}", deleteUpdate));
        }
    }
}
