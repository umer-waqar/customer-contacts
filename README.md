# customer-contacts


Create Empty Solution and Api Project
Customer.Services.ContactAPI

Install Nugets Packages
AutoMapper
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Annotations
Swashbuckle.AspNetCore.SwaggerUI
System.ComponentModel.Annotations

There are many database available but SQL Server is most propular. Lets configure the Entity Framework Core
Setup up Database 

Create Application Db Class, register in startup file and add in connection string in appsetting.json file.

Run Command in Package Manager Console to create Table in SQL Server based on the Contact Model
Add-Migration AddContactModelToDb
Update-Database

Implement API for Contact => Repository, Services, Controller and Response

Seed Contacts and add some data into the table 
Add-Migration SeedContacts
Update-Database

Create Gateway Project and Install nugets package Ocelot 
Register Ocelot in Startup Class 

info: Ocelot.Requester.Middleware.HttpRequesterMiddleware[0]
      requestId: 0HMHP2I5KCES5:00000001, previousRequestId: no previous request id, message: 200 (OK) status code, request uri: https://localhost:44340/api/contacts
	  
Implement validation checks for Personal Number, Email and Phone.  Write custom data annotation validation for personal number.

Social Security Number:  
•	Social Security Number is required.
•	Social Security Number should be minimum 10 digit long.
•	Social Security Number should be maximum 12 digit long.
•	Please enter valid social security number //Number only
•	Social Security Number should start from 19 or 20
Email Address : 
•	Invalid Email Address.

Phone Number:
•	Invalid Phone Number

https://www.oreilly.com/library/view/regular-expressions-cookbook/9781449327453/ch04s03.html
Note:  Regular expression copied from the above Url and not fully tested.

Cleanup and refactoring. App Done! Moving forward with dockerfile.


Gateway Url : https://localhost:5050
Service API Url : https://localhost:44340


Add Dockerfile by following the instruction from the Url
https://code.visualstudio.com/docs/containers/quickstart-aspnet-core

I am not confident with dockerfile. Need some improvements.