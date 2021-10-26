using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace Automation_Intro_1021
{
    public static class CommonFunctions
    {

        public static string Login = "";
        public static string Pass = "";

        internal static bool IsElementPresent(By by, IWebDriver _driver)
        {
            try
            {
                IWebElement displayed = _driver.FindElement(by);
                if (displayed != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        internal static bool ElementFoundAfterRetry(By by, int retries, IWebDriver _driver)
        {
            try
            {
                for (int i = 0; i <= retries; i++)
                {
                    if (IsElementPresent(by, _driver))
                    {
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        internal static IWebElement FindWebElement(By by, IWebDriver _driver, int retries)
        {
            try
            {
                if (CommonFunctions.ElementFoundAfterRetry(by, retries, _driver))
                {
                    IWebElement templateElement = _driver.FindElement(by);
                    return templateElement;
                }
                else
                {
                    return null;
                }
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        internal static void GetUserdataFromResourceFile()
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + "\\Resources\\AccountDetails.xml";
            XmlDocument accountDetails = new();
            accountDetails.Load(path);

            XmlElement xRoot = accountDetails.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("type");
                    if (attr.Value == "UserCreds")
                    {
                        Login = xnode.ChildNodes[0].InnerText;
                        Pass = xnode.ChildNodes[1].InnerText;
                    }

                }
            }
        }
    }
}

