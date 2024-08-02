using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace Working_With_Web_Tables
{
    public class WorkingWithTablesTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com");
        }

        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            IWebElement productTable = driver.FindElement(By.XPath("//div[@id='bodyContent']//div//div[2]//table"));

            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody/tr"));

            string path=System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv"; 

            if(File.Exists(path))
            {
                File.Delete(path);
            }

            foreach (var trow in tableRows)
            {
                
                ReadOnlyCollection<IWebElement> tcolums = trow.FindElements(By.XPath("//td"));

                foreach (var column in tcolums)
                {
                    string data = column.Text;
                    string[] productInfo = data.Split('\n');
                    string printProductInfo = productInfo[0].Trim() + "," + productInfo[1].Trim() + "\n";

                    File.AppendAllText(path, printProductInfo);
;                }
            }

            Assert.IsTrue(File.Exists(path), "CSV file was not created");
            Assert.That(new FileInfo(path).Length > 0, "CSV file is empty");
        }
    }
}