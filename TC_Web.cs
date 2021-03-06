using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Automation_Intro_1021
{
    [TestFixture("Category1")]
    public class TC_Web
    {
        IWebDriver _driver;

        public TC_Web(string nodeType)
        {

        }

        [SetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            CommonFunctions.GetUserdataFromResourceFile();

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + "\\Resources\\ChromeDriverFile\\";
           _driver = new ChromeDriver(path, options);
        }

        public string RandomString(int size, bool lowerCase = true)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }


        [Test]
        public void Registration()
        {
            //common registration on test site
            _driver.Url = "http://automationpractice.com"; 
            Thread.Sleep(4000);

            //Signin btn
            IWebElement SigninBtn = _driver.FindElement(By.XPath("//a[@class='login']"));
            SigninBtn.Click();
            Thread.Sleep(4000);

            //check is there 'create acc form'
            bool accountFormBox = CommonFunctions.IsElementPresent(By.Id("create-account_form"), _driver);
            Assert.AreEqual(accountFormBox, true, "There are no create-account_form");

            //Generate random for data
            var RegaRandom = new Random();
            int registrationInt = RegaRandom.Next(10, 99999);
            string registrationEmailString = "test_" + registrationInt.ToString() + "@test.com";
            
            int registrationPhoneint = RegaRandom.Next(10, 9999999);
            string phone = registrationPhoneint.ToString();

            string FullName = RandomString(6, true);

            var Birth = new Random();
            int BDay = Birth.Next(1, 30);
            int BMon = Birth.Next(1, 12);
            int BYea = Birth.Next(1920, 2000);

            string BdaySt = BDay.ToString();
            string BMonSt = BMon.ToString();
            string BYeaSt = BYea.ToString();

            int zip = RegaRandom.Next(10000, 99999);
            string zipSt = zip.ToString();

            string pass = "test1234";

            //input email
            _driver.FindElement(By.Id("email_create")).SendKeys(registrationEmailString);

            //submit btn
            _driver.FindElement(By.Id("SubmitCreate")).Click();
            Thread.Sleep(6000);

            //check is there account_creation box
            bool accCreationBox = CommonFunctions.IsElementPresent(By.Id("account-creation_form"), _driver);
            Assert.AreEqual(accCreationBox, true, "There are no account_creation form");

            //gender
            _driver.FindElement(By.Id("id_gender1")).Click();

            //1st & last name
            _driver.FindElement(By.XPath("//input[@name='customer_firstname']")).SendKeys(FullName);
            _driver.FindElement(By.Name("customer_lastname")).SendKeys(FullName);

            //pass 
            _driver.FindElement(By.Id("passwd")).SendKeys(pass);

            //birth
            _driver.FindElement(By.Id("days")).SendKeys(BdaySt);
            _driver.FindElement(By.Id("months")).FindElement(By.XPath("//option[contains(text(),'February')]")).Click();
            _driver.FindElement(By.Id("years")).SendKeys(BYeaSt);

            //other
            _driver.FindElement(By.XPath("//input[@name='optin'][@type='checkbox']")).Click();
            _driver.FindElement(By.Id("address1")).SendKeys(FullName + BMon);
            _driver.FindElement(By.Id("city")).SendKeys(FullName);
            _driver.FindElement(By.Id("id_state")).FindElement(By.XPath("//option[contains(text(),'California')]")).Click();
            _driver.FindElement(By.Id("postcode")).SendKeys(zipSt);
            _driver.FindElement(By.Id("phone_mobile")).SendKeys(phone);
            _driver.FindElement(By.Id("submitAccount")).Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Check is user logged in  or get an error
            //in case of error - fail the test
            if (_driver.FindElements(By.XPath("//div[@class='alert alert-danger']")).Count > 0)
            {
                Assert.IsTrue(false, "There are some errors");
            }
            else
            {
                IWebElement infoAcc = CommonFunctions.FindWebElement(By.ClassName("info-account"), _driver, 10);
                string text = infoAcc.GetAttribute("textContent");
                Assert.AreEqual(text.Contains("Welcome to your account. Here you can manage all of your personal information and orders"), true, "User is not logged in");
            }
        }

        [Test]

        public void UI_Interactions_FileUpload()
        {
            //file uploading and checking is it uploaded
            _driver.Url = "https://demoqa.com/upload-download";

            //get path to file
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + @"\Resources\Images\img1.jpg";

            //find button and send value
            IWebElement fileUpload = _driver.FindElement(By.Id("uploadFile"));
            fileUpload.SendKeys(path);
            Thread.Sleep(3000);

            //check is file uploaded
            IWebElement UploadedFilePath = _driver.FindElement(By.Id("uploadedFilePath"));
            string UploadedFilePathText = UploadedFilePath.GetAttribute("textContent");
            Assert.AreEqual(UploadedFilePathText.Contains("img1.jpg"), true, "File was not uploaded");

        }

        [Test]
        public void UI_Interactions_DragDrop()
        {
            _driver.Url = "https://demoqa.com/droppable";

            //find elements which will be dragged and dropped  
            var whatToDrag = _driver.FindElement(By.XPath("//div[text()='Drag me']"));
            var whereToDrag = _driver.FindElement(By.Id("droppable"));

            //perform an action
            Actions builder = new Actions(_driver);
            IAction dragAndDrop = builder.ClickAndHold(whatToDrag).MoveToElement(whereToDrag).Release(whatToDrag).Build();
            dragAndDrop.Perform();
            Thread.Sleep(3000);

            //check is element dropped
            bool isDropped = CommonFunctions.IsElementPresent(By.XPath("//p[text()='Dropped!']"), _driver);
            Assert.AreEqual(isDropped, true, "Element was not dropped");
        }

        [Test]
        public void UI_Interactions_WriteValueToFile()
        {
            //find value in table and write it to file
            _driver.Url = "https://demoqa.com/webtables";

            //find email column, 2nd row
            IWebElement thirdRow = _driver.FindElement(By.XPath("//div[@class='rt-tr -even']//div[@class='rt-td'][4]"));

            //save email to string 
            string thirdRowString = thirdRow.GetAttribute("textContent");

            //write to file email and actual time
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path = directory + "\\Resources\\Files\\emailFile.csv";
            string dt = DateTime.Now.ToString();
            File.AppendAllText(path, thirdRowString + ',');
            File.AppendAllText(path, Convert.ToString(dt) + ',' + Environment.NewLine);

            //now you can check value appearing in file: ProjectFolder -> \bin\Debug\net5.0\Resources\Files\emailFile.csv
        }

  

        [TearDown]
        public void closeBrowser()
        {
            _driver.Quit();
        }


    }

}

