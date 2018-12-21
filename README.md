# News REST Service

REST service based on ASP.NET Core Web API, Entity Framework Core and SQL Server that holds news.

## Client Applications:

- [x] ASP.NET Core MVC
- [x] Xamarin Android

## Endpoints:
- [x] GET /api/news – returns all news ordered by publish date. 
- [x] POST /api/news – creates a news item by given title, content and publish date. 
- [x] PUT /api/news/{id} – updates an existing news item by given id (given in the request URL) and title, content and publish date. 
- [x] DELETE /api/news/{id} – deletes an existing news item by given id.

## Features:

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
![enter image description here](https://devadventures.net/wp-content/uploads/2018/05/exception-production.png)
- [x] Neatly organized solution structure <br>
![solution-structure](https://devadventures.net/wp-content/uploads/2018/05/solution-structure.png)
- [x] Thin Controllers <br>
![thin-controllers](https://devadventures.net/wp-content/uploads/2018/05/tight-controllers.png) <br>
- [x] Robust service layer using the [Either](http://optional-github.com) monad. <br>
![either-monad](https://devadventures.net/wp-content/uploads/2018/05/either-monad.png)<br>
- [x] Safe query string parameter model binding using the [Option](http://optional-github.com) monad.<br>
![optional-binding](https://devadventures.net/wp-content/uploads/2018/05/option-binding-4-1.png)<br>

### Test Suite
- [x] xUnit
- [x] Autofixture
- [x] Moq
- [x] Shouldly
- [x] Arrange Act Assert Pattern

![enter image description here](https://devadventures.net/wp-content/uploads/2018/05/sample-test.png)
