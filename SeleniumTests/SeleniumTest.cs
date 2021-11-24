using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Assert = NUnit.Framework.Assert;

namespace SeleniumTests
{
    [TestClass]
    class SeleniumTest
    {
        String app_url = "https://bp-ca1-qa.azurewebsites.net/";
        IWebDriver driver;

        [SetUp]
        public void Start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
        }

        [Test, Order(1)]
        public void TestLowCategory()
        {
            driver.Url = app_url;

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
            Assert.AreEqual("Low Blood Pressure", text);
        }


        [Test, Order(2)]
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
            Assert.AreEqual("Ideal Blood Pressure", text);
        }

        [Test, Order(3)]
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
            Assert.AreEqual("Pre-High Blood Pressure", text);
        }

        [Test, Order(4)]
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
            Assert.AreEqual("High Blood Pressure", text);
        }

        [TearDown]
        public void Close_Browser()
        {
            driver.Quit();
        }
    }
}
