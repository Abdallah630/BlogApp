# 📝 Blog Content API

A scalable RESTful API built with ASP.NET Core 8 using Clean Architecture.

---

## 🚀 Features

* 🔐 JWT Authentication & Role-Based Authorization (Admin / User)
* 📝 Full CRUD for Posts, Categories, and Comments
* 💬 Comments System with user interactions
* 📄 Pagination & Filtering for posts
* 🔎 Search posts by title
* ✅ Input Validation using FluentValidation
* ⚠️ Global Exception Handling Middleware

---

## 🚀 Technologies

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* JWT Authentication
* Clean Architecture
* FluentValidation

---

## 🏗️ Architecture

```
BlogApp/
├── BlogApp.Domain          → Entities
├── BlogApp.Application     → DTOs, Interfaces, Validators
├── BlogApp.Infrastructure  → Repositories, Services, DbContext
└── BlogApp.API             → Controllers, Middleware
```

---

## ⚙️ Setup

1. Clone the repo

```bash
git clone https://github.com/Abdallah630/BlogApp.git
```

2. Update `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=BlogAppDb;Trusted_Connection=True;"
  },
  "JWT": {
    "AuthKey": "your-secret-key",
    "ValidAudience": "MySecuredAPIsUsers",
    "ValidIssuer": "https://localhost:7192",
    "DurationIndDays": "7"
  }
}
```

3. Run Migrations

```bash
dotnet ef database update --project BlogApp.Infrastructure --startup-project BlogApp.API
```

4. Run the API

```bash
dotnet run --project BlogApp.API
```

---

## 📌 API Endpoints

### 🔐 Auth

| Method | URL                | Description             |
| ------ | ------------------ | ----------------------- |
| POST   | /api/auth/register | Register new user       |
| POST   | /api/auth/login    | Login and get JWT token |

---

### 📝 Posts

| Method | URL               | Description                                     |
| ------ | ----------------- | ----------------------------------------------- |
| GET    | /api/posts        | Get all posts (supports pagination & filtering) |
| GET    | /api/posts/{slug} | Get post by slug                                |
| POST   | /api/posts        | Create new post (Authorized)                    |
| PUT    | /api/posts/{id}   | Update post (Owner/Admin)                       |
| DELETE | /api/posts/{id}   | Delete post (Owner/Admin)                       |

---

### 🗂 Categories

| Method | URL             | Description                  |
| ------ | --------------- | ---------------------------- |
| GET    | /api/categories | Get all categories           |
| POST   | /api/categories | Create category (Admin only) |

---

### 💬 Comments

| Method | URL                               | Description                    |
| ------ | --------------------------------- | ------------------------------ |
| GET    | /api/posts/{postId}/comments      | Get all comments for a post    |
| POST   | /api/posts/{postId}/comments      | Add comment (Authorized users) |
| DELETE | /api/posts/{postId}/comments/{id} | Delete comment (Owner/Admin)   |

---



## 👨‍💻 Author

**Abdallah Saad**
GitHub: https://github.com/Abdallah630
LinkedIn: https://linkedin.com/in/abdallah-saad-925b4224a
