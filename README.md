# ShoppingCartStore

Online eCommerse digital shopping cart application implementing a monolithic application architecture.

## Database Schema:
![Sorry, error loading image of diagram](DBDiagram.png)

## Visual Studio 2017 and SQL Server
Prerequisites
* SQL Server
* Visual Studio 2017 & with .NET Core SDK >= 2.2

Steps to run
* Have a running DB server & update the connection string in appsettings.json in ShoppingCartStore.Web.
* Build solution.
* In Solution Explorer, make sure that ShoppingCartStore.Web is selected as the Startup Project.
* Open Package Manager Console Window & execute "Update-Database" then press "Enter". This action will create database schema.
* In Visual Studio, press "Control + F5".

## Technologies and frameworks used:
* ASP.NET MVC Core 2.2
* Entity Framework Core 2.2
* ASP.NET Identity Core 2.2

## Product List View
![Sorry, error loading image of diagram](Homepage.png)

## Order Summary View
![Sorry, error loading image of diagram](Checkout.png)

## Product Description View
![Sorry, error loading image of diagram](Product.png)
