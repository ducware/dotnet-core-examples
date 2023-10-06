# GraphQL Dotnet Core

## 📦 Packagae

✨ **HotChocolate.AspNetCore**

✨ **Microsoft.EntityFrameworkCore**

## 🧩Register

```csharp
services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

app.MapGraphQL();
```

## I. Query Type

### 1.1 Get all

**⭐ C#**

```csharp
public class Query : IQuery
{
    public async Task<List<Cake>> AllCakeAsync([Service] ApplicationDbContext context)
    {
        return await context.Cakes.ToListAsync();
    }
}
```

**⭐ GraphQL**

```graphql
query{
  allCake {
    id,
    name
  }
}
```

## II. Mutation Type

### 2.1 Create

**⭐ C#**

```csharp
public class Mutation : IMutation
{
    public async Task<Cake> SaveCakeAsync([Service] ApplicationDbContext context, Cake cake)
    {
        await context.Cakes.AddAsync(cake);
        await context.SaveChangesAsync();

        return cake;
    }
}
```

**⭐ GraphQL**

```graphql
mutation($cake: CakeInput!){
  saveCake(cake: $cake) {
    id,
    name
  }
}
```

**variable:** 

```json
{
  "cake":{
    "id": 0,
    "name": "Cake 6",
    "price": 100,
    "description": "des"
  }
}
```

### 2.2 Update

**⭐ C#**

```csharp
public class Mutation : IMutation
{
    public async Task<Cake> UpdateCakeAsync([Service] ApplicationDbContext context, Cake cake)
		{
		    context.Cakes.Update(cake);
		    await context.SaveChangesAsync();
		    return cake;
		}
}
```

**⭐ GraphQL**

```graphql
mutation($cake: CakeInput!){
  updateCake(cake: $cake) {
    id,
    name,
    description,
    price
  }
}
```

**variable:** 

```json
{
  "cake":{
    "id": 6,
    "name": "Cake 6 edit",
    "price": 100,
    "description": "des edit"
  }
}
```

## 2.3 Delete

**⭐ C#**

```csharp
public class Mutation : IMutation
{
    public async Task<string> DeleteCakeAsync([Service] ApplicationDbContext context, int id)
		{
		    var cake = await context.Cakes.FindAsync(id);
		    if (cake == null)
		    {
		        return "invalid operation!";
		    }
		
		    context.Cakes.Remove(cake);
		    await context.SaveChangesAsync();
		    return "Deleted!";
		}
}
```

**⭐ GraphQL**

```graphql
mutation($id: Int!){
  deleteCake(id: $id)
}
```

**variable:** 

```json
{
  "id": 6
}
```

### Reference: https://www.learmoreseekmore.com/2022/01/basic-graphql-crud-operation-dotnet6-hotchocolate-v12-sqldatabase.html
