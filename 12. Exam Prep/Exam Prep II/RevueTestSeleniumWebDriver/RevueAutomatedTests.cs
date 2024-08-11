using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace RevueTestSeleniumWebDriver
{
    [TestFixture]
    public class RevueAutomatedTests
    {
        private WebDriver driver;
        private static readonly string baseURL = "https://d3s5nxhwblsjbi.cloudfront.net"; 
        private readonly string eMail = "iv@test.com";
        private readonly string pass = "123456";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.LinkText("Login")).Click();

            var emailFiled=driver.FindElement(By.XPath("//input[@id='form3Example3']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(emailFiled).Click().Perform();
            emailFiled.SendKeys(eMail);
            driver.FindElement(By.XPath("//input[@id='form3Example4']")).SendKeys(pass);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mb-4']")).Click();

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
            //driver.Navigate().GoToUrl(baseURL+"/Revue/Create");
        }
    }
}