using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text;
using System;

namespace MovieCatalogSeleniumWebTests
{
    [TestFixture]
    public class MovieCatalogTests
    {
        private static WebDriver driver;
        private readonly string baseURL = "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com/";
        private readonly string eMail = "iv@test.com";
        private readonly string password = "123456";
        private static string randomTitle = "";
        private static string randomDescription = "";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);

            driver.FindElement(By.XPath("//li[@class='nav-item']//a[@class='nav-link js-scroll-trigger active']")).Click();
            var loginButton = driver.FindElement(By.XPath("//a[@id='loginBtn']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(loginButton).Click().Perform();

            driver.FindElement(By.XPath("//input[@id='form2Example17']")).SendKeys(eMail);
            driver.FindElement(By.XPath("//input[@id='form2Example27']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@class='btn warning']")).Click();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
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


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
            var errorMessage = wait.Until(driver => driver.FindElement(By.XPath("//div[contains(@class, 'toast-error')]")));

            var errorMessageText = errorMessage.Text;

            Assert.That(errorMessageText, Is.EqualTo("The Title field is required."), "Error message is not correct");
        }

        [Test, Order(2)]
        public void Add_Movie_Without_Description_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "Catalog/Add");

            var randomTitle = GenerateRandomTitle(10);

            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomTitle);
            var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(addButton).Click().Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var errorMessage = wait.Until(driver => driver.FindElement(By.XPath("//div[contains(@class, 'toast-error')]")));
            var errorMessageText = errorMessage.Text;

            Assert.That(errorMessageText, Is.EqualTo("The Description field is required."), "Error message is not correct");
        }
        [Test, Order(3)]
        public void Add_Movie_WithTitle_Description_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "Catalog/Add");
            randomTitle = GenerateRandomTitle(5);
            randomDescription = GenerateRandomTitle(10);
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomTitle);
            driver.FindElement(By.XPath("//textarea[@name='Description']")).SendKeys(randomDescription);

            var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(addButton).Click().Perform();

            var pages=driver.FindElements(By.XPath("//a[@class='page-link']"));
            var lastPage = pages.Last();
            lastPage.Click();

            var addedMovies= driver.FindElements(By.CssSelector(".col-lg-4"));
            var lastAddedMovie= addedMovies.Last();

            var lastAddedMovieTitle = lastAddedMovie.FindElement(By.CssSelector(".col-lg-4>h2")).Text;

            Assert.That(lastAddedMovieTitle, Is.EqualTo(randomTitle.ToUpper()));
        }

        [Test, Order(4)] 

        public void Edit_Last_Movie_Test ()
        {
            driver.Navigate().GoToUrl(baseURL + "Catalog/All");

            var pages = driver.FindElements(By.XPath("//a[@class='page-link']"));
            var lastPage = pages.Last();
            lastPage.Click();

            var addedMovies = driver.FindElements(By.CssSelector(".col-lg-4"));
            var lastAddedMovie = addedMovies.Last();

            lastAddedMovie.FindElement(By.CssSelector(".btn-outline-success")).Click();
            driver.FindElement(By.XPath("//input[@name='Title']")).Clear();
            var editedTitle = "New Title";
            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(editedTitle);

            var editButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var successMessage = wait.Until(driver => driver.FindElement(By.XPath("//div[contains(@class, 'toast-success')]")));
            var successMessageText = successMessage.Text;

            Assert.That(successMessageText, Is.EqualTo("The Movie is edited successfully!"), "The title was not edoted successfully");

        }

        

        public static string GenerateRandomTitle(int length)
        {
            Random _random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            StringBuilder title = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                title.Append(chars[_random.Next(chars.Length)]);
            }

            
            return title.ToString().Trim();      
        }
    }
}