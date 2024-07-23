using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Exec
{
    public class SeleniumWaits 
    {
        IWebDriver driver;

        [SetUp]
        public void Setup() 
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDOwn()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void IgnoreExceptionWithFluentWait() 
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");

            driver.FindElement(By.XPath("//div[@id='start']//button")).Click();

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            fluentWait.Timeout=TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval=TimeSpan.FromMilliseconds(50);

            IWebElement finishDiv = fluentWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='finish']//h4")));

            Assert.That(finishDiv.Displayed);

        }
    }
}