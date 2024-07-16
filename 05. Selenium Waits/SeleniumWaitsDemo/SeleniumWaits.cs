using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWaitsDemo
{
    public class SeleniumWaitsTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            
        }
        [TearDown]

        public void Teardown()
        {
            this.driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void RedBoxInteraction() 
        {
                       
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            IWebElement addButtton=driver.FindElement(By.XPath("//input[@id='adder']"));
            addButtton.Click();

            IWebElement redBox = driver.FindElement(By.XPath("//div[@id='box0']"));

            Assert.True(redBox.Displayed);
        }

        [Test]

        public void ExplicitWaitInteraction()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");

            driver.FindElement(By.XPath("//div [@class='example']//div[@id='start']//button")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement finishDiv = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div [@class='example']//div[@id='finish']")));

            Assert.IsTrue(finishDiv.Displayed);

        }

        [Test] 

        public void ImplicitWaitInteraction()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");

            driver.FindElement(By.XPath("//div [@class='example']//div[@id='start']//button")).Click(); 

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            IWebElement findDiv=driver.FindElement(By.XPath("//div [@class='example']//div[@id='finish']"));

            Assert.True(findDiv.Displayed);

        }
    }
}