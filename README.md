#### Description:
**Automation_Intro_1021** - is a collection of autotests to introduce my skills in C# + Selenium automation.
___________________
**NB:** Project is still in progress!
___________________

#### Content:
- **Class 'TC_Web.cs'** contains web test cases:
		* Registration - just usual registration, also example of generated values;
		* UI_Interactions_dragdrop;
		* UI_Interactions_FileUpload;
		* UI_Interactions_WriteValueToFile;

- **Class 'TC_Mobile.cs'** contains:
		* test 'OrderProcess' with user scenario of ordering product on a site;
		* 'ProgressBarStopping' - start and stop progress bar on a certain value;

- **Class 'CommonFunctions.cs'** contains methods and functions which could be used for all tests;

- **Folder 'Resources'** contains:
		* ChromeDriver;
		* file 'emailFile' for test values;
		* folder 'Images';
		* xml file 'AccountDetails' with test user credentials;
___________________
**NB2:** Please bear in mind that site *http://automationpractice.com* (used by tests 'Registration', 'OrderProcess') 
could be unreachable due to error 508 - Resource Limit Is Reached.
You could wait a while or just glance my code and run another tests.
I hope you do not face this problem.
___________________
#### How to install:
1. Open solution with Visual Studio;
2. For solution you need NuGet packages:
		- Selenium.WebDriver;
		- NUnit;
		- Microsoft.NET.Test.Sdk;
		- Nunit3TestAdapter;	

3. **Please put folder 'Resources' into 'Project Folder' -> \bin\Debug\net5.0**