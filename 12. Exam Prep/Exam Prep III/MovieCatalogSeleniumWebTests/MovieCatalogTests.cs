using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MovieCatalogSeleniumWebTests
{
    [TestFixture]
    public class MovieCatalogTests
    {
        private static WebDriver driver;
        private readonly string baseURL = "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com/";
        private readonly string eMail = "iv@test.com";
        private readonly string password = "123456";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options=new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.XPath("//li[@class='nav-item']//a[@class='nav-link js-scroll-trigger active']")).Click();
            var loginButton=driver.FindElement(By.XPath("//a[@id='loginBtn']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(loginButton).Click().Perform();

            driver.FindElement(By.XPath("//input[@id='form2Example17']")).SendKeys(eMail);
            driver.FindElement(By.XPath("//input[@id='form2Example27']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='btn warning']")).Click();
        }

        [OneTimeTearDown] 
        public void OneTimeTearDown ()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void Add_Movie_WIthout_Title_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "Catalog/Add");

            var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(addButton).Click().Perform();

            var errorMessage = driver.FindElement(By.XPath("//script[@type='text/javascript']")).Text;

            Assert.That(errorMessage, Is.EqualTo("The Title field is required."), "Error message is not correct");

        }
    }
}