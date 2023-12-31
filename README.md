# Web-App-Sprout-Pet-Project
## A project mimicking an automated HR and Payroll administrative task solution

This project is a web application that computes the salary of an employee. 
Moreover, employee type does have two regular and contractual. 
These two are different when it comes to computation. 
Here are some differences: 
* Regular Employee 
  * Per month salary and 12% tax deduction
* Contractual Employee
  * Has no tax deduction and per-day salary

This computation won’t be possible without employee maintenance. 

This maintenance helps HR people to create, read, update, and delete employees. 
So hopefully you’ll enjoy it. 

## Tools Used to Create The Web Application 
* Visual Studio 2022
* Microsoft SQL Server 2022 (RTM) - 16.0.1000.6 (X64)
* .NET 6.0
* Node v16.16.0

## Nuget Packages Used to Crate the Web Application 
* Microsoft.EntityFrameworkCore 7.0.11
* Microsoft.Extensions.Configuration 6.0.1
* AutoMapper 12.0.1
* FluentValidation 11.7.1
* Microsoft.Extensions.Configuration.Abstractions 7.0.0
* Microsoft.Extensions.DependencyInjection.Abstractions 7.0.0
* Microsoft.AspNetCore.ApiAuthorization.IdentityServer 6.0.22
* Microsoft.AspNetCore.Identity.EntityFrameworkCore 6.0.22
* Microsoft.AspNetCore.Identity.UI 6.0.22
* Microsoft.EntityFrameworkCore 7.0.11
* Microsoft.EntityFrameworkCore.Design 7.0.11
* Microsoft.EntityFrameworkCore.Relational 7.0.11
* Microsoft.EntityFrameworkCore.SqlServer 7.0.11
* Microsoft.EntityFrameworkCore.Tools 7.0.11
* Microsoft.Extensions.Configuration 6.0.11
* Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore 6.0.22
* Microsoft.AspNetCore.SpaServices.Extensions 5.0.4
* Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.16

## Project Structure
![image](https://github.com/jindeveloper/Web-App-Sprout-Pet-Project/assets/39805502/00cb06db-2004-4a79-b2b2-3b0c2d7f998c)

## Side Notes 
### Database 
Anyone can restore the database. 
Please look at the database folder and see the .bak file and SQL scripts.
These are provided for anyone to restore the database on their local machine. 
### User Credentials (To log in to the system) 

Email: jin.necesario@uap.asia

Password: p@ssw0rd123Jin

*Note: These credentials are automatically registered when the application starts.
Please check the SeeData.cs*

## Video Demo 
https://github.com/jindeveloper/Web-App-Sprout-Pet-Project/assets/39805502/04a9a088-113f-4ce3-bfff-1494fc43480b

## If would be deployed to Production 
### Here are some of my thoughts. 
If this would be deployed to production, here are some of my thoughts: 
*	Use docker or dockerize the application. 
*	An onboarding feature would be fun to create. 
*	Split the UI entirely from the ASP.NET Core application (e.g., Web API & React.js are separated applications). 
