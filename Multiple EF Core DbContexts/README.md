## Stack
### 🚀 .NET Core 7
### 🚀 Entity Framework
### 🚀 Minimal APIs

🔗 **Migration:**

```bash
Add-Migration CreateDatabase -Context OrdersDbContext -o Migrations/Orders
Add-Migration CreateDatabase -Context ProductsDbContext -o Migrations/Products
```

🔗 **Update Database:**

```bash
Update-Database -Context OrdersDbContext
Update-Database -Context ProductsDbContext
```

## Reference
### https://www.milanjovanovic.tech/blog/using-multiple-ef-core-dbcontext-in-single-application
