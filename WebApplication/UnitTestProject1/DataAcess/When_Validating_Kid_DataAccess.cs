using System;
using NUnit.Framework;
using WebApplication.Library.DataAccess;
using WebApplication.Library.Models;

namespace WebApplication.Tests.DataAcess
{
    // Given_When_Then
    [TestFixture]
    public class When_Validating_Kid_DataAccess
    {
        private int integrationDelete;
        private int integrationInsert;
        private int integrationUpdate;
        private int integrationForUpdate;

        [Test]
        public void Null_KidDataAccess_Insert_ThrowError()
        {
            // Arrange
            var AddKid = new KidDataAccess();

            // Act
            // Assert

            Assert.Throws<ArgumentException>(() => AddKid.Insert(null) );

        }

        [Test]
        public void EmptyRecord_KidDataAccess_Insert_ThrowError()
        {
            // Arrange
            var newKid = new Kid();
            var AddKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => AddKid.Insert(newKid));

        }

        [Test]
        [TestCase("Allison","AllisonJadeWysocki@gmail.com")]
        public void Valid_KidDataAccess_Insert_AddsKid(string Name, string Email)
        {
            // Arrange
            var newKid = new Kid();
            newKid.Name = Name;
            newKid.Email = Email;
            var AddKid = new KidDataAccess();

            // Act
            var result = AddKid.Insert(newKid);

            // Assert
            Assert.AreEqual(true, result, "We should have Inserted the Record");
        }

        [Test]
        public void Null_KidDataAccess_Update_ThrowError()
        {
            // Arrange
            var AddKid = new KidDataAccess();

            // Act
            // Assert

            Assert.Throws<ArgumentException>(() => AddKid.Update(null));

        }

        [Test]
        public void EmptyRecord_KidDataAccess_Update_ThrowError()
        {
            // Arrange
            var newKid = new Kid();
            var AddKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => AddKid.Update(newKid));

        }

        [Test]
        [TestCase("Richard", "RichardWysocki@gmail.com")]
        public void Valid_KidDataAccess_Update_updateKid(string Name, string Email)
        {
            // Arrange
            var updateKid = new Kid();
            updateKid.KidID = integrationForUpdate;
            updateKid.Name = Name;
            updateKid.Email = Email;
            var AddKid = new KidDataAccess();

            // Act
            var result = AddKid.Update(updateKid);

            // Assert
            Assert.AreEqual(true, result, "We should have Updated the Record");

        }

        [Test]
        public void EmptyRecord_KidDataAccess_Delete_ThrowError()
        {
            // Arrange
            var deleteID = 0;
            var AddKid = new KidDataAccess();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => AddKid.Delete(deleteID));

        }

        [Test]
        public void Valid_KidDataAccess_Delete_updateKid()
        {
            // Arrange
            var deleteID = integrationDelete;
            var deleteKid = new KidDataAccess();

            // Act
            var result = deleteKid.Delete(deleteID);

            // Assert
            Assert.AreEqual(true, result, "We should have Deleted the Record");

        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            integrationDelete = TestHelperUtility.ExecuteInsert(@"INSERT INTO XKid(Name, Email) Values('MaggiWysocki','MagiWysocki@gmail.com')");

            integrationForUpdate = TestHelperUtility.ExecuteInsert(@"INSERT INTO XKid(Name, Email) Values('Rich','RichardWysocki@gmail.com')");

            integrationUpdate = TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'","Allison","AllisonJadeWysocki@gmail.com"));
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            var DeleteInsert = TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'", "Allison", "AllisonJadeWysocki@gmail.com"));
            if (DeleteInsert > 0)
                TestHelperUtility.Delete(string.Format("Delete XKid where KidID={0}", DeleteInsert));

            var DeleteUpdate = TestHelperUtility.Execute(string.Format("Select KidID from XKid Where Name='{0}' and Email='{1}'", "Richard", "RichardWysocki@gmail.com"));
            if (DeleteUpdate > 0)
                TestHelperUtility.Delete(string.Format("Delete XKid where KidID={0}", DeleteUpdate));
        }
    }
}
