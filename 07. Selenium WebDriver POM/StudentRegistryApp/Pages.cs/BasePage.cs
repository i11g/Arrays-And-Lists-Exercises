

using OpenQA.Selenium;

namespace StudentRegistryApp.Pages.cs
{
    public class BasePage 
    {
        protected readonly IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver; 
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        } 

        public virtual string PageUrl { get; }

        public IWebElement linkHomePage => driver.FindElement(By.XPath("//a[@href='/']"));
        //driver.FindElement(By.LinkedText("Home")

        public IWebElement linkViewStudents => driver.FindElement(By.XPath("//a[@href='/students']"));
        //driver.FindElement(By.LinkedText("View Students")

        public IWebElement linkAddStudent => driver.FindElement(By.XPath("//a[@href='/add-student']"));
        //driver.Findelement(By. 

        public IWebElement PageHeading => driver.FindElement(By.CssSelector("body>h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTtitle()
        {
            return driver.Title;
        } 

        public string GetPageHeadingtext ()
        {
            return PageHeading.Text;
        }
    }
}
