# 📝 Blog Content API

A RESTful API built with ASP.NET Core 8 using Clean Architecture.

---

## 🚀 Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT Authentication
- Clean Architecture
- FluentValidation

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

## 📌 Endpoints

### Auth
| Method | URL | Description |
|--------|-----|-------------|
| POST | /api/auth/register | Register |
| POST | /api/auth/login | Login |

### Posts
| Method | URL | Description |
|--------|-----|-------------|
| GET | /api/posts | Get all posts |
| GET | /api/posts/{slug} | Get post by slug |
| POST | /api/posts | Create post |
| PUT | /api/posts/{id} | Update post |
| DELETE | /api/posts/{id} | Delete post |

### Categories
| Method | URL | Description |
|--------|-----|-------------|
| GET | /api/categories | Get all categories |
| POST | /api/categories | Create category |

### Comments
| Method | URL | Description |
|--------|-----|-------------|
| GET | /api/posts/{postId}/comments | Get comments |
| POST | /api/posts/{postId}/comments | Add comment |
| DELETE | /api/posts/{postId}/comments/{id} | Delete comment |