# 🌎 CRM - CSharp

## 📝 Description

This is a **Simple** CRM Web API application that allows you to manage your customers and have an authentication system. It is written in C# and uses a MySqlite database.
What makes special this project is that uses an **n - tier** architecture, which means that the application is divided into layers. This allows you to have a better organization of the code and a better understanding of the application.
This is the first time I have used this architecture and I have learned a lot from it, also c sharp is a language that I have never worked before, so I have learned a lot from this project.
I have done this in my thesis that is being made Lafise Bank to learn how the systems are made in the company.

## 🌃 Architecture

The application is divided into 5 layers:

- **Service**: This layer is the one that is exposed to the user, it is the one that contains the controllers and the models that are used in the controllers.
- **Application**: This layer is the one that prepares the data to be used in the service layer, it is the one that contains the DTOs and the models that are used in the DTOs.
- **Domain**: This layer is the one that contains the domain logic and buisness rules, it is the one that contains the entities and the models that are used in the entities.
- **Infrastructure**: This layer is the one that contains the data access logic, it is the one that contains the repositories and the models that are used in the repositories.
- **Transversal**: This layer is the one that contains the common logic, and can be used by any layer.

## 🚀 Usage

To use this is necessary to have installed the dotnet core sdk 7.0 and the dotnet core runtime. You can download it from [here](https://dotnet.microsoft.com/download).

1. Clone the repository
1. Open the project in your favorite IDE
1. Run the init query from the Docs/Queries folder
1. Run the command `dotnet restore` to restore the dependencies
1. Run the command `dotnet run` to run the application
1. Open the browser and go to `[domain]/swagger/index.html` to see the documentation of the API

**note**: The customer's endpoint are private so you would need to get the token in the Authentication Endpoint and then put it in the Authorize button in the top right corner of the swagger page.

## 📦 Dependecies

- [Dapper](dotnet add package Dapper --version 2.1.4)
- [AutoMapper](dotnet add package AutoMapper --version 12.0.1)
- [AutoMapper.Extensions.Microsoft.DependencyInjection](dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1)
- [Swagger](dotnet add package Swashbuckle.AspNetCore.Swagger --version 6.5.0)
- [Microsoft.AspNetCore.Authentication.JwtBearer](dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0-rc.1.23421.29)
- [Microsoft.Data.Sqlite](dotnet add package Microsoft.Data.Sqlite --version 8.0.0-rc.1.23419.6)

## 📌 Endpoints

### Authentication

- **POST** /api/User/Authenticate

### Customers

- **GET** //api/Customer/GetAll
- **POST** /api/Customer/Insert
- **PUT** /api/Customer/Update
- **GET** /api/Customer/Get/customerId?customerId={customerId}
- **DELETE** /api/Customer/Delete/customerId?customerId={customerId}
