FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OData.Demo.Api/OData.Demo.Api.csproj", "src/OData.Demo.Api/"]
COPY ["src/OData.Demo.Core/OData.Demo.Core.csproj", "src/OData.Demo.Core/"]
COPY ["src/OData.Demo.Infrastructure/OData.Demo.Infrastructure.csproj", "src/OData.Demo.Infrastructure/"]
RUN dotnet restore "src/OData.Demo.Api/OData.Demo.Api.csproj"
COPY . .
WORKDIR "/src/src/OData.Demo.Api"
RUN dotnet build "OData.Demo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OData.Demo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OData.Demo.Api.dll"]