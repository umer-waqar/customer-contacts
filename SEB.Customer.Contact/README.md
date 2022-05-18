# customer-contacts


Create Empty Solution and Api Project

Install Nugets Packages
AutoMapper
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore.Annotations
Swashbuckle.AspNetCore.SwaggerUI


There are many database available but SQL Server is most propular. Lets configure the Entity Framework
Setup up Database 

Create Application Db Class, register in startup file and add in connection string in appsetting.json file.

Run Command in Package Manager Console to create Table in SQL Server based on the Contact Model
Add-Migration AddContactModelToDb
Update-Database

Implement API for Contact => Repository, Services, Controller and Response

Seed Contacts and add some data into the table 
Add-Migration SeedContacts
Update-Database