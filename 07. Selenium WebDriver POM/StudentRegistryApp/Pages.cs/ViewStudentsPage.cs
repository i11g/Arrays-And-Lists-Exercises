﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StudentRegistryApp.Pages.cs
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";

        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body>ul>li")); 

        public string[] GetRegisterStudents ()
        {
            var elementsStudents=this.ListItemsStudents.Select(s=>s.Text).ToArray();
            return elementsStudents;
        }


    }
}
