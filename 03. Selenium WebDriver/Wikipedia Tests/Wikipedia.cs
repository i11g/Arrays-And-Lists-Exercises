using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wikipedia_Tests
{
    public class Wikipedia
    {   
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        { 
            this.driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
        } 

        [TearDown] 

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void TestTitle ()
        {
            
            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));
            
        }

        [Test] 

        public void TestQualityAssurance()
        {

            driver.Manage().Window.Maximize();         
            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);

            Assert.That(driver.Title, Is.EqualTo("Quality assurance - Wikipedia"));

            
        } 
    }
}