using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DropDownPractice
{
    public class DropDownPracticeTests 
    {
        private WebDriver driver; 

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }
        [TearDown] 

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void DropDownPractice()
        {
            
        }
    }
}