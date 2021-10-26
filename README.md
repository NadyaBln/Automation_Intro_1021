## Description:
	Automation_Intro_1021 - 
	is a collection of autotests to introduce my skills in C# + Selenium automation.
	
	NB: Project is still in progress.

## Content:
	 - *Class 'TC_Web.cs'* contains web test cases:
		1. Registration - just usual registration, also example of generated values;
		2. UI_Interactions_dragdrop;
		3. UI_Interactions_FileUpload;
		4. UI_Interactions_WriteValueToFile;

	- Class 'TC_Mobile.cs' contains test 'OrderProcess' with user scenario of ordering product on a site.

	- 'CommonFunctions.cs' contains methods and functions which could be used for all tests;

	- Folder 'Resources' contains:
		1. ChromeDriver;
		2. file 'emailFile' for test values;
		3. folder 'Images';
		4. xml file 'AccountDetails' with test user credentials;
		

## How to install:
	1. Open solution with Visual Studio;
	2. For solution you need NuGet packages:
		- Selenium.WebDriver;
		- NUnit;
		- Microsoft.NET.Test.Sdk;
		- Nunit3TestAdapter;	

	3. Please put folder 'Resources' into 'Project Folder' -> \bin\Debug\net5.0