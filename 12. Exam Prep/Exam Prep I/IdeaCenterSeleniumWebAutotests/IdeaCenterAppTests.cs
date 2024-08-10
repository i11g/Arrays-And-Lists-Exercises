using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IdeaCenterSeleniumWebAutotests
{
    [TestFixture]
    public class IdeaCenterAppTests
    {
        private IWebDriver driver;
        private readonly string BASEURL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";
        private static string lastCreatedIdeaTitle;
        private static string lastCreatedIdeaDescription;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl(BASEURL+ "/Users/Login");
            driver.FindElement(By.XPath("//input[@id='typeEmailX-2']")).SendKeys("iv1234@test.com");
            driver.FindElement(By.XPath("//input[@id='typePasswordX-2']")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']")).Click();
        }

        [OneTimeTearDown]

        public void OneTimetearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void Create_Idea_With_InvalidDataTest()
        {
            driver.Navigate().GoToUrl(BASEURL + "/Ideas/Create");
            string title = "";
            string description = "";

            var titleField = driver.FindElement(By.Id("form3Example1c"));
            titleField.SendKeys(title);
            var descriptionField = driver.FindElement(By.Id("form3Example4cd"));
            descriptionField.SendKeys(description);
           
            Assert.That(titleField.Text, Is.EqualTo(""));
            Assert.That(descriptionField.Text, Is.EqualTo(""));

            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            var pageUrl = driver.Url;

            Assert.That(pageUrl, Is.EqualTo(BASEURL + "/Ideas/Create"), "Page Url is not correct");

            var mainMessage=driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
            Assert.That(mainMessage.Text, Is.EqualTo("Unable to create new Idea!"), "Main message is not correct");

            var titleMessage = driver.FindElement(By.XPath("//div[@style='text-align:center']//span[contains(text(), 'The Title field')]"));
            Assert.That(titleMessage.Text, Is.EqualTo("The Title field is required."), "Title message is not correct");

            var descriptionMessage = driver.FindElement(By.XPath("//div[@style='text-align:center']//span[contains(text(),'The Description field')]"));
            Assert.That(descriptionMessage.Text, Is.EqualTo("The Description field is required."), "Description message is not correct");
        }
        [Test, Order(2)] 

        public void Create_Random_Idea_Test()
        {
            driver.Navigate().GoToUrl(BASEURL + "/Ideas/Create");
            lastCreatedIdeaTitle = GenerateRandomString(6);
            lastCreatedIdeaDescription ="Description " + GenerateRandomString(10); 

            driver.FindElement(By.Id("form3Example1c")).SendKeys(lastCreatedIdeaTitle);
            driver.FindElement(By.Id("form3Example4cd")).SendKeys(lastCreatedIdeaDescription);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            var pageUrl = driver.Url;
            Assert.That(pageUrl, Is.EqualTo(BASEURL + "/Ideas/MyIdeas"));

            ReadOnlyCollection<IWebElement> createdIdeas=driver.FindElements(By.CssSelector(".card.mb-4.box-shadow"));
            IWebElement lastIdea = createdIdeas.Last();
            var lastIdeaText=lastIdea.FindElement(By.XPath(".//div[@class='card-body']//p"));

            Assert.That(lastIdeaText.Text, Is.EqualTo(lastCreatedIdeaDescription));
        }
        [Test,Order(3)] 

        public void View_Last_Created_Idea_Test ()
        {
            driver.Navigate().GoToUrl(BASEURL + "/Ideas/MyIdeas");
            ReadOnlyCollection<IWebElement> createdIdeas = driver.FindElements(By.CssSelector(".card.mb-4.box-shadow"));
            IWebElement lastIdea = createdIdeas.Last();

            var viewLastIdeaButton = lastIdea.FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary'and text()='View']"));
            
            Actions actions = new Actions(driver);
            actions.MoveToElement(viewLastIdeaButton).Click().Perform();

            
            var textTitle = driver.FindElement(By.XPath("//div[@id='intro']//h1")).Text.Trim();

            Assert.That(textTitle, Is.EqualTo(lastCreatedIdeaTitle), "Last Idea text title is not correct");
        }
        [Test, Order(4)] 

        public void Edit_Last_Created_Idea_Title_Test ()
        {
            driver.Navigate().GoToUrl(BASEURL+ "/Ideas/MyIdeas");

            var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            var createdIdeas = wait.Until(driver=>driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));
            
            Assert.IsTrue(createdIdeas.Count > 0, "No idea cards were found on the page.");
            
            var lastIdea = createdIdeas.Last();            

            var editButton = lastIdea.FindElement(By.CssSelector("a[href*='/Ideas/Edit']")); 
            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();

            driver.FindElement(By.XPath("//input[@id='form3Example1c']")).Clear();
            var editedTitle = "Edite Title";
            driver.FindElement(By.XPath("//input[@id='form3Example1c']")).SendKeys(editedTitle);
            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            createdIdeas = driver.FindElements(By.CssSelector(".card.mb-4.box-shadow"));
            lastIdea = createdIdeas.Last();

            var viewButton = lastIdea.FindElement(By.CssSelector("a[href*='/Ideas/Read']"));
            Actions action = new Actions(driver);
            action.MoveToElement(viewButton).Click().Perform();

            var newEditedTitle = driver.FindElement(By.XPath("//*[@id='intro']/h1")).Text;

            Assert.That(newEditedTitle, Is.EqualTo(editedTitle));
        }

        [Test, Order(5)]

        public void Edit_LastCreatedIdea_Deacription_Tests()
        {
            driver.Navigate().GoToUrl(BASEURL + "/Ideas/MyIdeas");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));

            Assert.IsTrue(ideaCards.Count > 0, "No idea cards were found on the page.");

            var lastIdeaCard = ideaCards.Last();
            var editButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Edit']"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(editButton).Click().Perform();


            driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']")).Clear();
            driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']")).SendKeys("Changed Description: Edited Decription");

            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            ideaCards = wait.Until(driver => driver.FindElements(By.CssSelector(".card.mb-4.box-shadow")));
            lastIdeaCard = ideaCards.Last();

            var viewButton = lastIdeaCard.FindElement(By.CssSelector("a[href*='/Ideas/Read']"));
            Actions action = new Actions(driver);
            action.MoveToElement(viewButton).Click().Perform();

            var editedDescription = driver.FindElement(By.XPath("//section[@class='row']//p")).Text;

            Assert.That(editedDescription, Is.EqualTo("Changed Description: Edited Decription"), "Edited Description is not correct");
        }
        [Test, Order(6)] 

        public void Delete_lastIdea_Test()
        {
            driver.Navigate().GoToUrl(BASEURL + "/Ideas/MyIdeas");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var ideaCards = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")));
            var lastIdea = ideaCards.Last();

            var deleteButton = driver.FindElement(By.XPath(".//a[contains(@href, '/Ideas/Delete')]"));

            Actions actions = new Actions (driver);
            actions.MoveToElement(deleteButton).Click().Perform();

            ideaCards = wait.Until(driver => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")));

            bool ideaCardDleted=ideaCards.All(e=>!e.Text.Contains(lastCreatedIdeaDescription));
            Assert.IsTrue(ideaCardDleted, "The last idea was not deleted succesfully");
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "hskjghskjhgdskjhgsjdkghdsjkghsdkjg";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).
                Select(s => s[random.Next(s.Length)]).ToArray());
        } 
    }
}