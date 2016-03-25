using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication.Library.Business;

namespace WebApplication.Tests.Business
{
    [TestClass]
    public class When_Validating_ErrorLog
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
            string x = "";
            LogErrorBusiness.AddLogError("SendWithLog", "Message", "Source");

            // Assert
            Assert.IsNotNull(x);
        }
    }
}
