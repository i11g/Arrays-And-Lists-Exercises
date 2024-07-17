using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
