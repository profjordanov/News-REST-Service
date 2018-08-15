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
