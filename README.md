# OData .NET 8 Demo

A clean architecture implementation of OData with .NET 8, following best practices and design patterns.

## Project Structure

The solution follows Clean Architecture principles with the following projects:

- **OData.Demo.Api**: Web API project with OData endpoints
- **OData.Demo.Core**: Core domain entities and interfaces
- **OData.Demo.Infrastructure**: Data access and implementation details

## Features

- Clean Architecture implementation
- OData v8.2 implementation
- Entity Framework Core 8
- Repository Pattern with Generic Repository
- Unit of Work Pattern
- SOLID Principles
- Dependency Injection
- Swagger/OpenAPI documentation
- Proper error handling
- Entity configurations
- Database migrations

## Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository:
```bash
git clone https://github.com/YourUsername/odata-net8-demo.git
cd odata-net8-demo
```

2. Update the connection string in `src/OData.Demo.Api/appsettings.json` if needed.

3. Run Entity Framework migrations:
```bash
dotnet ef migrations add InitialCreate -p src/OData.Demo.Infrastructure -s src/OData.Demo.Api
dotnet ef database update -p src/OData.Demo.Infrastructure -s src/OData.Demo.Api
```

4. Run the application:
```bash
dotnet run --project src/OData.Demo.Api
```

## OData Query Examples

1. Get all products:
```
GET /odata/Products
```

2. Filter products by price:
```
GET /odata/Products?$filter=Price gt 100
```

3. Sort products by name:
```
GET /odata/Products?$orderby=Name desc
```

4. Select specific fields:
```
GET /odata/Products?$select=Name,Price,CategoryId
```

5. Expand related entities:
```
GET /odata/Products?$expand=Category
```

6. Pagination:
```
GET /odata/Products?$top=10&$skip=20
```

7. Counting:
```
GET /odata/Products?$count=true
```

## API Endpoints

### Products
- GET /odata/Products - Get all products
- GET /odata/Products({id}) - Get product by ID
- POST /odata/Products - Create new product
- PUT /odata/Products({id}) - Update product
- DELETE /odata/Products({id}) - Delete product

### Categories
- GET /odata/Categories - Get all categories
- GET /odata/Categories({id}) - Get category by ID
- POST /odata/Categories - Create new category
- PUT /odata/Categories({id}) - Update category
- DELETE /odata/Categories({id}) - Delete category

## Best Practices Implemented

1. **Clean Architecture**
   - Clear separation of concerns
   - Domain-centric architecture
   - Dependency inversion

2. **Repository Pattern**
   - Abstract data access layer
   - Generic repository implementation
   - Easy to test and mock

3. **Unit of Work Pattern**
   - Transaction management
   - Maintain data consistency
   - Atomic operations

4. **SOLID Principles**
   - Single Responsibility Principle
   - Open/Closed Principle
   - Interface Segregation
   - Dependency Inversion

5. **OData Best Practices**
   - Query optimization
   - Security considerations
   - Proper routing
   - Error handling

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details