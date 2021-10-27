### Description:
**Automation_Intro_1021** - is a collection of autotests to introduce my skills in C# + Selenium automation.
___________________
**NB:** Project is still in progress!
___________________

### Content:
- **Class 'TC_Web.cs'** contains web test cases:
1. Registration - just usual registration, also example of generated values;
2. UI_Interactions_dragdrop;
3. UI_Interactions_FileUpload;
4. UI_Interactions_WriteValueToFile;

- **Class 'TC_Mobile.cs'** contains:
1. 'OrderProcess' - user scenario of selecting and adding product to the cart;
2. 'ProgressBarStopping' - start and stop progress bar on a certain value;

- **Class 'CommonFunctions.cs'** contains methods and functions which could be used for all tests;

- **Folder 'Resources'** contains:
1. ChromeDriver;
2. File 'emailFile' for test values;
3. Folder 'Images';
4. Xml file 'AccountDetails' with test user credentials;
___________________
**NB2:** Please bear in mind that site *http://automationpractice.com* (used by tests 'Registration', 'OrderProcess') 
could be unreachable due to error 508 - Resource Limit Is Reached.
You could wait a while or just glance my code and run another tests.
I hope you do not face this problem.
___________________
### How to install:
1. Open solution with Visual Studio;
2. For solution you need NuGet packages:
- Selenium.WebDriver;
- NUnit;
- Microsoft.NET.Test.Sdk;
- Nunit3TestAdapter;	

3. **Please put folder 'Resources' into 'Project Folder' -> \bin\Debug\net5.0**