using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace POMExercise.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait= new WebDriverWait(driver,TimeSpan.FromSeconds(10));
        }

        protected IWebElement FindElement(By by )
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        } 
        protected ReadOnlyCollection<IWebElement> FindElements(By by) 
        {
            return driver.FindElements(by); 
        }

    }
}
