# News REST Service

REST service based on ASP.NET Core Web API, Entity Framework Core and SQL Server that holds news.

## Features

- [x] AutoMapper
- [x] EntityFramework Core with SQL Server and ASP.NET Identity
- [x] JWT authentication/authorization
- [x] File logging with Serilog
- [x] Stylecop
- [x] Neat folder structure

```
├───src
│   ├───configuration
│   └───server
│       ├───News.Api
│       ├───News.Business
│       ├───News.Core
│       ├───News.Data
│       └───News.Data.EntityFramework
└───tests
    └───News.Business.Tests

```


- [x] Swagger UI + Fully Documented Controllers <br>

![swagger-ui](https://devadventures.net/wp-content/uploads/2018/06/swagger-ui-new.png)

- [x] Global Model Errors Handler <br>

![model-errors](https://devadventures.net/wp-content/uploads/2018/05/model-errors.png)
- [x] Global Environment-Dependent Exception Handler <br>
Development <br>
![exception-development](https://devadventures.net/wp-content/uploads/2018/06/exception-development.png)<br> 
Production <br>
