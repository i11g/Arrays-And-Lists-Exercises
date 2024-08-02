using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Waits
{
    public class SearchProductWithImplicitWaits  
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com");
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.XPath("//input[@name='keywords']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.XPath("//td[@align='center']//span//span[2]")).Click();
                var text = driver.FindElement(By.XPath("//td[2]/a[1]/strong"));

                Assert.That(driver.PageSource.Contains("keyboard"), "The product keyboard was not found");
                Assert.That(text.Displayed, "The text is not displayed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }
    }
}