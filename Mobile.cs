﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automation_Intro_1021
{
    [TestFixture("Category1")]
    public class TC_Mobile
    {
        IWebDriver _driver;
        string device1 = "iPhone X";
        private object ExpectedConditions = "";

        public TC_Mobile(string nodeType)
        {

        }

        [SetUp]
        public void StartBrowserMobView()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            CommonFunctions.GetUserdataFromResourceFile();
            options.EnableMobileEmulation(device1);
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + "\\Resources\\ChromeDriverFile\\";
            _driver = new ChromeDriver(path, options);
        }

        [Test]

        public void OrderProcess()
        {
            //in this test user logged in, opened certain category on products, select one,
            //change amount of product and add it to cart. Checking of successful adding

            _driver.Url = "http://automationpractice.com";
            Thread.Sleep(5000);

            //login with existing user (get user creds from AccountDetails file)
            _driver.FindElement(By.XPath("//a[@class='login']")).Click();
            Thread.Sleep(3000);

            //check is there Authentication page
            bool AuthentificationPart = CommonFunctions.IsElementPresent(By.XPath("//h1[text()='Authentication']"), _driver);
            Assert.AreEqual(AuthentificationPart, true, "Authentication page is not loaded");

            //input login/pass
            IWebElement Login = _driver.FindElement(By.Id("email"));
            Login.SendKeys(CommonFunctions.Login);
            IWebElement Pass = _driver.FindElement(By.Id("passwd"));
            Pass.SendKeys(CommonFunctions.Pass);
            _driver.FindElement(By.Id("SubmitLogin")).Click();
            Thread.Sleep(5000);

            //check is user logged in 
            IWebElement infoAcc = CommonFunctions.FindWebElement(By.ClassName("info-account"), _driver, 10);
            string text = infoAcc.GetAttribute("textContent");
            Assert.AreEqual(text.Contains("Welcome to your account. Here you can manage all of your personal information and orders"), true, "User is not logged in");

            //go to Categories > Women 
            _driver.FindElement(By.CssSelector("div.cat-title")).Click();
            _driver.FindElement(By.XPath("//a[@title='Women']")).Click();

            //scroll to item and select it 
            IWebElement TshirtItem = CommonFunctions.FindWebElement(By.XPath("//img[@alt='Faded Short Sleeve T-shirts']"), _driver, 10);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", TshirtItem);
            Thread.Sleep(2000);
            TshirtItem.Click();
            Thread.Sleep(2000);

            //check product page is open 
            bool ProdPage = CommonFunctions.IsElementPresent(By.Id("short_description_content"), _driver);
            Assert.AreEqual(ProdPage, true, "Product page is not loaded");

            //select amount 
            _driver.FindElement(By.CssSelector("i.icon-plus")).Click();
            Thread.Sleep(1000);
            //Add to cart btn
            _driver.FindElement(By.CssSelector("button.exclusive")).Click();
            Thread.Sleep(2000);

            //check is item added to cart
            bool cartMessage = CommonFunctions.IsElementPresent(By.CssSelector("i.icon-ok"), _driver);
            Assert.AreEqual(cartMessage, true, "Item is not added to cart");
            Thread.Sleep(3000);

        }

        [TearDown]
        public void closeBrowser()
        {
            _driver.Quit();
        }


    }
}
