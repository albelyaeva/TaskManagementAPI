# 🧾 TaskManagerX – Full-Stack Task Manager (Next.js + ASP.NET Core)

Welcome to **TaskManagerX**, a secure full-stack task management app built with **Next.js** (React) on the frontend and **ASP.NET Core Web API** on the backend. Authenticated users can register, log in, and manage tasks via a clean, responsive interface.

---

## 🧠 Project Overview

- 🔐 **JWT-based Auth**
- 📦 **CRUD API for Tasks**
- 🌓 **Dark mode-ready UI**
- 🔄 **Live task updates on edit/save**
- 🌍 **Timezone-aware due dates**

---

# 📁 Folder Structure

```
/task-manager-frontend    ← Next.js frontend (React, TailwindCSS)
/task-manager-api         ← ASP.NET Core backend (C#, EF Core, PostgreSQL)
```

---

# 📦 Backend – ASP.NET Core Web API

### 📂 `/task-manager-api`

### ✅ Features
- RESTful API for tasks
- User registration and login
- Password hashing + JWT generation
- PostgreSQL DB with EF Core migrations

### 🛠 Tech Stack
- C# / .NET 8 Web API
- Entity Framework Core
- PostgreSQL (locally or via Docker)
- JWT Authentication
- Swagger for API docs

### 🚀 Getting Started

```bash
cd TaskManagerApi

# Set up environment variables
cp appsettings.Development.json.example appsettings.Development.json

# Run database migrations
dotnet ef database update

# Run the backend
dotnet run
```

### 🔑 Environment Settings (`appsettings.Development.json`)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TaskManagerDB;Username=postgres;Password=yourpassword"
  },
  "Jwt": {
    "Key": "your_super_secure_key",
    "Issuer": "TaskManagerAPI"
  }
}
```

# 👩‍💻 Author
**Aleksandra** – Full-stack developer based in Switzerland 🇨🇭

---
