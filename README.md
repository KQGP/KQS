# KQS — Inventory & POS System

A **Windows desktop application** (C# WinForms, .NET Framework 4.8.1) for small-business **inventory, sales, and accounting**: items, categories, customers, suppliers, invoices, expenses, and financial reports. Backed by **SQL Server**.

## ✨ Features

- 🔐 Login / Signup with PBKDF2 password hashing
- 📊 Dashboard (today/monthly sales, low stock, active customers)
- 🗂️ Categories & Items management
- 👥 Customers & Suppliers
- 💰 Sales (Sells) & Invoices
- 📦 Inventory
- 💸 Expenses tracking
- 📈 Financial reports
- 👤 User management (roles)
- 📋 Sales logs

## 🧱 Tech Stack

- C# / .NET Framework 4.8.1
- Windows Forms
- SQL Server (local, `Server=.;Database=KQS`)
- System.Data.SqlClient

## 📁 Project Structure

```
KQS.sln
KQS/
├── Program.cs
├── *Form.cs / *.Designer.cs   # UI forms
├── DashboardService.cs
├── PasswordHelper.cs
└── Properties/
```

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022 (or MSBuild) with .NET desktop workload
- SQL Server (Express/LocalDB) with a database named `KQS`

### Setup
1. Restore/create the `KQS` database on `Server=.` (connection string in forms).
2. Open `KQS.sln` in Visual Studio.
3. Build & run (F5).

### Connection String
Default: `Server=.;Database=KQS;Integrated Security=True;` (in each form). Update if needed.
