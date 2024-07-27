using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace Appium_Exec
{
    public class SummatorAppiumTests
    {
        private AndroidDriver _driver;
        private AppiumLocalService _appiumLocalService;

        [OneTimeSetUp]
        public void Setup()
        { 
            _appiumLocalService=new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            _appiumLocalService.Start();

            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UiAutomator2",
                DeviceName = "Pixel 7 API 35",
                App = @"C:\\com.example.androidappsummator.apk",
                PlatformVersion = "15"
            };

            _driver = new AndroidDriver(_appiumLocalService, androidOptions);
        }

        [OneTimeTearDown] 
        public void TearDown() 
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService?.Dispose();
        }


        [Test]
        public void TestWithValidData()
        {
            IWebElement field1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            field1.Clear();
            field1.SendKeys("3");

            IWebElement field2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            field2.Clear();
            field2.SendKeys("4");

            IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            calcButton.Click();

            IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

            Assert.IsNotNull(result);
            Assert.That(result.Text, Is.EqualTo("7"));

        }
        [Test]
        public void TestWithInValidData()
        {
            IWebElement field1 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
            field1.Clear();
            

            IWebElement field2 = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
            field2.Clear();
            

            IWebElement calcButton = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
            calcButton.Click();

            IWebElement result = _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

          
            Assert.That(result.Text, Is.EqualTo("error"));

        }

        [Test]
        [TestCase("10","10","20")]
        [TestCase("100","200","300")]
        public void TestWithValidDataParametarized(string input1, string input2, string result)
        {
            IWebElement field1 = _driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText1\"]"));
            field1.Clear();
            field1.SendKeys(input1);

            IWebElement field2 = _driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText2\"]"));
            field2.Clear();
            field2.SendKeys(input2);

            IWebElement calcButton = _driver.FindElement(MobileBy.XPath("//android.widget.Button[@resource-id=\"com.example.androidappsummator:id/buttonCalcSum\"]"));
            calcButton.Click();

            IWebElement result1 = _driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editTextSum\"]"));

            Assert.That(result1.Text, Is.EqualTo(result));
        }


    }
}