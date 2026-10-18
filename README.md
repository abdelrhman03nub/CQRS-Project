# CQRS Web API - ASP.NET Core

A RESTful Web API designed and implemented using the **CQRS (Command Query Responsibility Segregation)** pattern with **MediatR** in ASP.NET Core. This architecture effectively decouples read and write operations, enhancing performance, scalability, and code maintainability.

---

## 🛠️ Tech Stack & Tools
- **Framework:** .NET / ASP.NET Core Web API
- **Language:** C#
- **Architecture:** CQRS Pattern via MediatR
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Validation:** FluentValidation (with MediatR Pipeline Behaviors)
- **Security:** JWT Authentication, Role-Based Access Control (RBAC), BCrypt Password Hashing
- **Documentation & Testing:** Swagger / OpenAPI

---

## ✨ Key Features
- **CQRS Architecture:** Complete separation between Commands (Data Modification) and Queries (Data Retrieval).
- **Domain Functionalities:** Full CRUD operations for Products & Categories and Order processing workflows.
- **Robust Security:** JWT-based user authentication, role-based authorization, and secure password encryption using BCrypt.
- **Automated Validation:** Integrated FluentValidation into MediatR pipeline behaviors to validate requests automatically before processing.
- **Global Exception Handling:** Centralized middleware to handle application exceptions gracefully and return standardized API responses.

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation & Setup
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/abdelrhman03nub/CQRS-Project.git](https://github.com/abdelrhman03nub/CQRS-Project.git)
