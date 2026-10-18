# CQRS Project - ASP.NET Core Web API

A backend Web API project built with ASP.NET Core and .NET 10, demonstrating the CQRS pattern and common backend development practices.

## Technologies Used

- C#
- ASP.NET Core Web API
- .NET 10
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- JWT Authentication
- BCrypt Password Hashing
- Swagger / OpenAPI
- Git & GitHub

## Features

- Product management (CRUD operations)
- Category management
- User registration and login
- JWT-based authentication
- Role-based authorization (Admin and Customer)
- Password hashing with BCrypt
- CQRS pattern using Commands and Queries
- MediatR request handling
- FluentValidation for request validation
- Centralized exception handling
- Entity Framework Core database integration
- API documentation and testing with Swagger

## Authentication and Authorization

- Users can register and log in.
- Passwords are hashed before being stored.
- JWT tokens are used to authenticate requests.
- Product endpoints require authentication.
- Only Admin users can create, update, or delete products.
- Customer users can access authorized read operations.

## Database

The project uses SQL Server LocalDB during development and Entity Framework Core for database access and migrations.

## Getting Started

1. Clone the repository.
2. Open `CQRS Project.slnx` in Visual Studio.
3. Configure the database connection string using User Secrets.
4. Configure the JWT signing key using User Secrets.
5. Apply Entity Framework Core migrations.
6. Run the application.
7. Open Swagger to explore and test the API endpoints.

## Security Notes

Sensitive configuration values, such as database connection strings and JWT signing keys, should not be committed to source control.

## Author

**Abdelrhman Mohamed**

- GitHub: [abdelrhman03nub](https://github.com/abdelrhman03nub)
