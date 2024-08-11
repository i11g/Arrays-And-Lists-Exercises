using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text;

namespace RevueTestSeleniumWebDriver
{
    [TestFixture]
    public class RevueAutomatedTests
    {
        private WebDriver driver;
        private static readonly string baseURL = "https://d3s5nxhwblsjbi.cloudfront.net"; 
        private readonly string eMail = "iv@test.com";
        private readonly string pass = "123456";
        private string titleLastRevue = "";
        private string descriptionLastRevue = "";


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.LinkText("Login")).Click();

            var emailFiled=driver.FindElement(By.XPath("//input[@id='form3Example3']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(emailFiled).Click().Perform();
            emailFiled.SendKeys(eMail);
            driver.FindElement(By.XPath("//input[@id='form3Example4']")).SendKeys(pass);
            var button=driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mb-4']"));
            actions.MoveToElement(button).Click().Perform();
        }

        [OneTimeTearDown] 

        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void Create_Revue_Invalid_Data_Test()
        {
            driver.Navigate().GoToUrl(baseURL+"/Revue/Create");

            var fromelement = driver.FindElement(By.XPath("//form[@class='mx-1 mx-md-4']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(fromelement).Perform();

            driver.FindElement(By.XPath("//input[@name='Url']")).SendKeys("dhfg");
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            var pageUrl = driver.Url;
            
            Assert.That(pageUrl, Is.EqualTo(baseURL + "/Revue/Create"));

            var errorMessage = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li")).Text;

            Assert.That(errorMessage, Is.EqualTo("Unable to create new Revue!"));
        }
        [Test, Order(2)] 

        public void Create_Random_Revue_Tests ()
        {
            driver.Navigate().GoToUrl(baseURL + "/Revue/Create");

            var fromelement = driver.FindElement(By.XPath("//form[@class='mx-1 mx-md-4']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(fromelement).Perform();
            var randomTilte = GenerateRandomString(5);
            var randomDescription = GenerateRandomString(10);

            driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(randomTilte);
            driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']")).SendKeys(randomDescription);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            var pageUrl = driver.Url;

            Assert.That(pageUrl, Is.EqualTo(baseURL + "/Revue/MyRevues"));

            var createdRevues=driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
            var lastRevue=createdRevues.Last();

            titleLastRevue = lastRevue.FindElement(By.XPath(".//div[@class='text-muted text-center']")).Text;

            Assert.That(titleLastRevue, Is.EqualTo(randomTilte));
        }

        [Test, Order(3)]

        public void Search_ForRevue_Title_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/Revue/MyRevues");

            var searhField = driver.FindElement(By.XPath("//input[@id='keyword']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(searhField).Click().Perform();
            searhField.SendKeys(titleLastRevue);

            driver.FindElement(By.XPath("//button[@id='search-button']")).Click();
            var titleSearchRevue = driver.FindElement(By.XPath(".//div[@class='text-muted text-center']")).Text;

            Assert.That(titleSearchRevue, Is.EqualTo(titleLastRevue));
        }

        [Test, Order(4)] 
        public void EditLast_Created_RevueTitle_Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/Revue/MyRevues");
            var createdRevues = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

            Assert.That(createdRevues.Count(), Is.AtLeast(1));

            var lastCreatedRevue = createdRevues.Last();
            Actions actions=new Actions (driver);
            actions.MoveToElement(lastCreatedRevue).Perform();

            lastCreatedRevue.FindElement(By.CssSelector("a[href*='/Revue/Edit']")).Click();

            var editForm = driver.FindElement(By.XPath("//form[@class='mx-1 mx-md-4']"));
            actions.MoveToElement(editForm).Perform();

            driver.FindElement(By.XPath("//input[@id='form3Example1c']")).Clear();
            var editedTitle = "New Title";
            driver.FindElement(By.XPath("//input[@id='form3Example1c']")).SendKeys(editedTitle);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            var pageUrl = driver.Url;

            Assert.That(pageUrl, Is.EqualTo(baseURL + "/Revue/MyRevues"));

            createdRevues = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
            lastCreatedRevue = createdRevues.Last();
            actions.MoveToElement(lastCreatedRevue).Perform();

            var lastElementEditedTitle = lastCreatedRevue.FindElement(By.XPath(".//div[@class='text-muted text-center']")).Text;
            
            Assert.That(lastElementEditedTitle, Is.EqualTo(editedTitle));
        }
        [Test, Order(5)] 

        public void Delete_Last_revue_Test ()
        {
            driver.Navigate().GoToUrl(baseURL + "/Revue/MyRevues");
            var createdRevues = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

            Assert.That(createdRevues.Count(), Is.AtLeast(1));

            var lastCreatedRevue = createdRevues.Last();
            Actions actions = new Actions(driver);
            actions.MoveToElement(lastCreatedRevue).Perform();

            lastCreatedRevue.FindElement(By.CssSelector("a[href*='/Revue/Delete']")).Click();

            var pageUrl = driver.Url;
            Assert.That(pageUrl, Is.EqualTo(baseURL + "/Revue/MyRevues"));

            createdRevues = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
            lastCreatedRevue = createdRevues.Last();
            actions.MoveToElement(lastCreatedRevue).Perform();
            var lastElementTitle = lastCreatedRevue.FindElement(By.XPath(".//div[@class='text-muted text-center']")).Text;

            Assert.That(lastElementTitle, Is.Not.EqualTo(titleLastRevue));
        }


        public static string GenerateRandomString(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }

            return result.ToString();
        }
    }
}