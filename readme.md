#Setup

##Requirements
  .Net 8.0 SDK

##1 - Install Entity Framework tools
Run the following commands in the project folder
  dotnet tool install --global dotnet-ef
  //or
  dotnet tool update

  dotnet add package Microsoft.EntityFrameworkCore.Design

##2 - Create Intial Database Migrations
Run the following commands in the project folder
  dotnet ef migrations add InitialCreate
  dotnet ef database update