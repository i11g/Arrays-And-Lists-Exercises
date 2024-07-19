using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMExercise.Tests
{
    public class BasePageTests
    {
        protected IWebDriver driver;
        
        [SetUp]
        
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]

        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();

        }

        
    }
}
