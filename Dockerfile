FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln .
COPY src/OData.Demo.Api/*.csproj src/OData.Demo.Api/
COPY src/OData.Demo.Core/*.csproj src/OData.Demo.Core/
COPY src/OData.Demo.Infrastructure/*.csproj src/OData.Demo.Infrastructure/

# Restore NuGet packages
RUN dotnet restore

# Copy source code
COPY src/ src/

# Build and publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OData.Demo.Api.dll"]