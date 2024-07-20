using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExercise.Pages;


namespace POMExercise.Tests
{
    public class BasePageTests
    {
        protected IWebDriver driver;

        protected LoginPage loginPage; 

        protected InventoryPage inventoryPage;
        
        [SetUp]
        
        public void SetUp()
        {
            var chromeOpnions = new ChromeOptions();
            chromeOpnions.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(chromeOpnions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            inventoryPage = new InventoryPage(driver);
            
            

        }

        [TearDown]

        public void TearDown() 
        {   
            if(driver!=null)
            {
                driver.Quit();
                driver.Dispose();
            }           

        }

        protected void LoginMethod(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            loginPage.LoginUser(username, password);           
            
        }

        
    }
}
