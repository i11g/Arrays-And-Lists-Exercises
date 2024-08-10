using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RevueTestSeleniumWebDriver
{
    [TestFixture]
    public class RevueAutomatedTests
    {
        private WebDriver driver;
        private static readonly string baseURL = "https://d3s5nxhwblsjbi.cloudfront.net";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
        }

        [OneTimeTearDown] 

        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void Create_Revue_Invalid_Data_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/Revue/Create");
        }
    }
}