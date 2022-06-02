using Fujitsu.Base;

namespace Fujitsu.OpenEMRAutomation
{
    public class LoginTest : WebDriverWrapper
    {


        [Test]
        public void ValidateTitleTest()
        {
            Assert.That(driver.Title, Is.EqualTo("OpenEMR Login"));
        }
    }
}