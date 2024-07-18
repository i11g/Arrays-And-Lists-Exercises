using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryApp.Pages.cs
{
    public class AddStudentPage : BasePage 
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
            
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";


        public IWebElement FieldStudentName => driver.FindElement(By.XPath("//input[@id='name']"));

        public IWebElement FieldStudentEmail => driver.FindElement(By.XPath("//input[@id='email']"));

        public IWebElement ButtonAdd => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector("body>div"));

        public void AddStudent(string studentName, string  studentEmail)
        {
            this.FieldStudentName.SendKeys(studentName); 
            this.FieldStudentEmail.SendKeys(studentEmail);
            this.ButtonAdd.Click();
        }

        public string GetErrorMessage ()
        {
            return ErrorMessage.Text;
        }

    }
}
