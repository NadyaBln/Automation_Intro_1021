### Description:
**Automation_Intro_1021** - is a collection of autotests to introduce my skills in C# + Selenium automation.

**NB:** Project is still in progress!
___________________

### Content:
**1. Class 'TC_Web.cs'** contains web test cases:
- Registration - just usual registration, also example of generated values;
- UI_Interactions_dragdrop;
- UI_Interactions_FileUpload;
- UI_Interactions_WriteValueToFile;

**2. Class 'TC_Mobile.cs'** contains test cases with run in a mobile view:
- 'OrderProcess' - user scenario of selecting and adding product to the cart;
- 'ProgressBarStopping' - start and stop progress bar on a certain value;

**3. Class 'CommonFunctions.cs'** contains methods and functions which could be used for all tests;

**4. Folder 'Resources'** contains:
- ChromeDriver;
- File 'emailFile' for test values;
- Folder 'Images';
- Xml file 'AccountDetails' with test user credentials;
___________________
**NB2:** Please bear in mind that site *http://automationpractice.com* (used by tests 'Registration', 'OrderProcess') 
could be unreachable due to error 508 - Resource Limit Is Reached.
You could wait a while or just glance my code and run another tests.
I hope you do not face this problem.
___________________
### How to install:
1. Open solution with Visual Studio (I have Visual Studio Community 2019, Version 16.11.4);
2. For solution you need NuGet packages:
- Selenium.WebDriver;
- NUnit;
- Microsoft.NET.Test.Sdk;
- Nunit3TestAdapter;	

3. **Please put folder 'Resources' into 'Project Folder' -> \bin\Debug\net5.0**