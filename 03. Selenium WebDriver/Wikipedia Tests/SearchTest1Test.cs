
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class SearchTest1Test {
  private IWebDriver driver;
  
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
    driver.Dispose();
  }
  [Test]
  public void searchTest1() {
    driver.Navigate().GoToUrl("https://softuni.bg/");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 832);
    driver.FindElement(By.CssSelector(".header-search-icon > img")).Click();
    driver.FindElement(By.Id("search-input")).Click();
    driver.FindElement(By.Id("search-input")).SendKeys("QA");
    driver.FindElement(By.CssSelector(".fa-search")).Click();
    Assert.That(driver.FindElement(By.CssSelector(".search-title")).Text, Is.EqualTo("Резултати от търсене на “QA”"));
  }
}
