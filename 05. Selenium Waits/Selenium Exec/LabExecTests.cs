
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Exec
{
    
    public class LabExecTests
    {
        IWebDriver driver;
        string baseURL;
        [SetUp] 
        public void SetUp()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.selenium.dev/selenium/web/dynamic.html";
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        
        [Test, Order(1)]
        public void AddBoxWithoutWaitsFalls()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.XPath("//input[@id='adder']")).Click();

            IWebElement findBox = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(findBox.Displayed); 
        }
        [Test, Order(2)] 

        public void RevealInputWithoutWaitsFail()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.XPath("//input[@id='reveal']")).Click();

            IWebElement revealed = driver.FindElement(By.XPath("//input[@id='revealed']"));

            revealed.SendKeys("Displayed");

            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));

        }
        [Test, Order(3)] 

        public void AddBoxWithTreadSleep()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.XPath("//input[@id='adder']")).Click();

            Thread.Sleep(3000);

            IWebElement newBox = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(newBox.Displayed);

        }

    }
}
