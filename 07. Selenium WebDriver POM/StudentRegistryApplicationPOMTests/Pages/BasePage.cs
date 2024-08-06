
using OpenQA.Selenium;

namespace StudentRegistryApplicationPOMTests.Pages
{
    public class BasePage
    {
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver= driver;
            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(10);
        }

        public virtual string PageUrl { get; }
        public IWebElement linkHomePage => driver.FindElement(By.XPath("//body//a[1]"));

        //driver.FindElement(By.LinkText("Home")

        public IWebElement linkViewStudents => driver.FindElement(By.LinkText("View Students"));


    }
}
