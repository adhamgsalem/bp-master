using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
 
namespace SeleniumTests
{
    class SeleniumTest
    {
        String app_url = "http://localhost:5000/";
        IWebDriver driver;

        [SetUp]
        public void Start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLowCategory()
        {
            IWebElement systolicPressure = driver.FindElement(By.Id("BP_Systolic"));
            systolicPressure.Clear();
            systolicPressure.SendKeys("80");

            System.Threading.Thread.Sleep(1000);

            IWebElement diastolicPressure = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicPressure.Clear();
            diastolicPressure.SendKeys("55");

            System.Threading.Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.XPath("//body/div[1]/main[1]/div[1]/div[1]/form[1]/div[3]/input[1]"));
            submitButton.Click();

            System.Threading.Thread.Sleep(1000);

            String text = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/form[1]/div[4]")).Text;
            Assert.AreEqual(text, "Low Blood Pressure");
        }

        [Test]
        public void TestIdealCategory()
        {
            driver.Url = app_url;

            IWebElement systolicPressure = driver.FindElement(By.Id("BP_Systolic"));
            systolicPressure.Clear();
            systolicPressure.SendKeys("119");

            System.Threading.Thread.Sleep(1000);

            IWebElement diastolicPressure = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicPressure.Clear();
            diastolicPressure.SendKeys("79");

            System.Threading.Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.XPath("//body/div[1]/main[1]/div[1]/div[1]/form[1]/div[3]/input[1]"));
            submitButton.Click();

            System.Threading.Thread.Sleep(1000);

            String text = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/form[1]/div[4]")).Text;
            Assert.AreEqual(text, "Ideal Blood Pressure");
        }

        [Test]
        public void TestPreCategory()
        {
            driver.Url = app_url;

            IWebElement systolicPressure = driver.FindElement(By.Id("BP_Systolic"));
            systolicPressure.Clear();
            systolicPressure.SendKeys("125");

            System.Threading.Thread.Sleep(1000);

            IWebElement diastolicPressure = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicPressure.Clear();
            diastolicPressure.SendKeys("85");

            System.Threading.Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.XPath("//body/div[1]/main[1]/div[1]/div[1]/form[1]/div[3]/input[1]"));
            submitButton.Click();

            System.Threading.Thread.Sleep(1000);

            String text = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/form[1]/div[4]")).Text;
            Assert.AreEqual(text, "Pre-High Blood Pressure");
        }

        public void TestHighCategory()
        {
            driver.Url = app_url;

            IWebElement systolicPressure = driver.FindElement(By.Id("BP_Systolic"));
            systolicPressure.Clear();
            systolicPressure.SendKeys("150");

            System.Threading.Thread.Sleep(1000);

            IWebElement diastolicPressure = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicPressure.Clear();
            diastolicPressure.SendKeys("90");

            System.Threading.Thread.Sleep(1000);

            IWebElement submitButton = driver.FindElement(By.XPath("//body/div[1]/main[1]/div[1]/div[1]/form[1]/div[3]/input[1]"));
            submitButton.Click();

            System.Threading.Thread.Sleep(1000);

            String text = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/form[1]/div[4]")).Text;
            Assert.AreEqual(text, "High Blood Pressure");
        }

        [TearDown]
        public void Close_Browser()
        {
            driver.Quit();
        }
    }
}
