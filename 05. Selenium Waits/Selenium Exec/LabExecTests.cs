
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

        [Test, Order(4)] 
        public void AddBoxWithImplicitWait()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("adder")).Click();

            IWebElement findBox = driver.FindElement(By.Id(("box0")));

            Assert.True(findBox.Displayed);
        }

        [Test, Order(5)] 

        public void AddBoxWithExplicitWait ()
        {
            driver.Navigate().GoToUrl(baseURL);

            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            wait.Until(driver => revealed.Displayed);
            revealed.SendKeys("Displayed");

            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

        [Test, Order(6)] 

        public void AddBoXWithFluentWaitExpectedConditionsAndIgnoredExeptions()
        {
            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.Id("adder")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement newBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));

            Assert.That(newBox.Displayed);
        }


        [Test, Order(7)]

        public void RevealInputWithCustomFluentWait()
        {
            driver.Navigate().GoToUrl(baseURL);

            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };

            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(driver =>
            {
                revealed.SendKeys("Displayed");
                return true;
            });

            Assert.That(revealed.TagName, Is.EqualTo("input"));
            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }

    }
}
