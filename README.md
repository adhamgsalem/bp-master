# Implementation of Build & Release Pipeline
## Introduction
Blood Pressure and Heart Rate Calculator application is a .Net Razor application based on Microsoft .Net Core 3.1. It provides a basic calculation of your blood pressure category. The application is developed using the following tools:
* Microsoft Visual Studio 2019
* C# as prgramming language
* Selenuim for End to End testing
* Gherkin and step defention files for Acceptance testing
* XUnit for unit testing
* Zap scanner for Pen testing
* K6 for load/perfomance testing
* GitHub for source control and CI/CD
* Microsoft Azure platform for hosting of the website


## Build & Release Design
### Source Code Management
The Blood Pressure and Heart Rate Calculator is stored in a GIT based source code management system from GiTHub. GIT a lightweight but powerful decentralised SCM. All code for the project can be found in the https://github.com/adhamgsalem/bp-master

---
### Build Pipeline
Build services are provided by GitHub Actions. This suite of tools provide Agents and Task for building of applications across multiple platforms.  The build pipeline implements the following funcationality:

1. Initalization & Source Code Download
2. Application Compile
3. Unit Test Execution
4. Code Quality Analysis & Publication
5. Application Publication
6. Build Artifact Publication

All builds in this pipeline are run on Microsoft Windows based servers in the VS 2019 Host pool, some other tools run on Linux as a docker container. 
We have one pipeline within the GitHub actions that basically builds and deploys the code across different azure web servers.

#### Application Compile, Test and Publish
The application is compiled using the DOTNET Core task. This task has a number of commands will build, test and publish your web applications applications.  Unit testing is completed as part of the build with 30+ tests executed covering 80% of the new code added for the Blood Pressure and Heart Rate Category calculations. 

#### Code Quality Analysis
Code Analysis is being performed by Sonar Cloud.

##### Sonar Cloud
The Sonar Cloud project used for code quality analysis. This tool is linked to the GITHub repository for analysis cand provides information on:
* Bugs
* Code Smells
* Coverage  
The tool provide a widget that is availalbe in the Azure DevOps Dashboard. It is possible to get code coverage information both additional manipulation of the .coverage is required for the information to be available for analysis

---
### Release Pipeline
The release pipeline is developed in GitHub actions. The release pipeline is linked to the Build Pipeline with artifcates being made available to the release after a successful build has completed. 
The release pipeline is comprised of the following stages:
1. Deployment to QA environment
2. Running Acceptance Test
3. Deployment to Staging slot (10%)
3. Running E2E Test
4. Running Performance Test
5. Running Penteration Test scan
6. Deployment to Production slot (90%)

#### Azure Platform 
The Azure platform is used for hosting the web application. The platform provides Web Application resource that will make the application available via a named url. The url for the production site for this application is http://bp-ca1-prod.azurewebsites.net/


The Azure Platform, also provides deployment slots that are used in the release pipeline to test the web application before it goes into produced.  In this pipeline we deploy a build into the following slots:
* QA: Used for testing of the application in a QA environment (acceptance testing) | http://bp-ca1-qa.azurewebsites.net/
* STAGING: Used for performance,  pen testing and E2E testing | http://bp-ca1-prod-bp-ca1-staging.azurewebsites.net/
* PRODUCTION: Used by the end user - the production slot is main application web URL, we use a slot swap to move from Stage into Production as part of the release pipline | http://bp-ca1-prod.azurewebsites.net/


---
# New Features
1. Implemented Crisis Blood Pressure category which will target a systolic pressure of >= 190 < the max allowed input of 250.
2. Implemented a new page 'Heart Rate' where the user can check his Heart Rate Category.
3. Impelemented a heart rate category functinality that is somehow releveant to all modern blood pressure monitor devices so that the user can input the reading and know his HR category.
   Heart Rate categoties are as follows
	1. Check that if HR > 30 and  < 40 then HR categorty should be LOW
	2. Check that if HR >= 40 and < 70 then HR categorty should be AVERAGE
	3. Check that if HR >= 70 and <100 then HR categorty should be POOR
---
