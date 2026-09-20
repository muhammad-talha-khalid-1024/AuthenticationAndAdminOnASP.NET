# ASP.NET Core MVC Project

## 📋 Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express / LocalDB)
- [Git](https://git-scm.com/downloads)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

---

## 🚀 Getting Started

Follow these steps **in order** to get the project up and running on your local machine.

### Step 1: Clone the Repository & Pull the Latest Changes

First, clone the repository and pull the latest changes from the specified branch:

```bash
# Clone the repository
git clone https://github.com/muhammad-talha-khalid-1024/AuthenticationAndAdminOnASP.NET.git

# Navigate into the project folder
cd <project-folder>

# Pull the latest changes from the branch
git pull origin master
```

> ⚠️ **Important:** Make sure you are on the correct branch before proceeding. You can check your current branch with `git branch` and switch to the required one with `git checkout <branch-name>`.

---

### Step 2: Install NuGet Packages

Restore all the required NuGet packages for the solution:

```bash
dotnet restore
```

If you're using **Visual Studio**, you can also right-click the solution in **Solution Explorer** and select **Restore NuGet Packages**.

---

### Step 3: Run Database Migrations

Apply the Entity Framework Core migrations to create/update the database schema:

```bash
dotnet ef database update
```

> 💡 **Note:**
> - If `dotnet ef` is not installed, install it globally first:
>   ```bash
>   dotnet tool install --global dotnet-ef
>   ```
> - Make sure your **connection string** in `appsettings.json` is correctly configured to point to your database before running the migration.

---

### Step 4: Build and Run the Project

Finally, build and start the project:

```bash
dotnet build
dotnet run
```

Or, if you're using Visual Studio, simply press **F5** or click the **Run** button.

Once the application is running, open your browser and navigate to:

```
https://localhost:<port>
```

(The exact port will be displayed in your terminal/console output.)

---

## 🛠️ Troubleshooting

| Issue | Solution |
|-------|----------|
| `dotnet ef` command not found | Install EF Core tools: `dotnet tool install --global dotnet-ef` |
| Database connection error | Verify your connection string in `appsettings.json` |
| Migration fails | Delete the `Migrations` folder (if applicable) and re-run `dotnet ef migrations add InitialCreate` |
| Port already in use | Change the port in `launchSettings.json` or stop the process using that port |

---

## 📁 Project Structure

```
├── Controllers/        # MVC Controllers
├── Models/             # Data Models
├── Views/              # Razor Views
├── Data/               # DbContext & Migrations
├── wwwroot/            # Static files (CSS, JS, Images)
├── appsettings.json    # Configuration settings
└── Program.cs          # Application entry point
```

---

## 📝 Summary of Steps

1. ✅ **Pull** the latest changes from the branch
2. ✅ **Install** NuGet packages (`dotnet restore`)
3. ✅ **Run** database migrations (`dotnet ef database update`)
4. ✅ **Start** the project (`dotnet run`)

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the [issues page](../../issues).

---

**Happy Coding! 🎉**