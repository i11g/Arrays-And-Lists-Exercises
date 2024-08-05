using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Working_With_Windows1
{
    public class WorkingWithWindowsTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows ");
        }

        [Test, Order(1)]
        public void HandleMultipleWindows_Test()
        {
            driver.FindElement(By.XPath("//div[@class='example']//a")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2), "The windows are not open");

            driver.SwitchTo().Window(windowHandles[1]);

          var  newWindowContent=driver.FindElement(By.XPath("//div[@class='example']//h3")).Text;

            Assert.That(newWindowContent, Is.EqualTo("New Window"));
        }
    }
}