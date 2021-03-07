#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "JCP-Shop.sln" "JCP-Shop.sln"

COPY "BuildingBlocks/Logger/JCP.Logger/JCP.Logger.csproj" "BuildingBlocks/Logger/JCP.Logger/JCP.Logger.csproj"
COPY "Services/Catalog/JCP.Catalog.API/JCP.Catalog.API.csproj" "Services/Catalog/JCP.Catalog.API/JCP.Catalog.API.csproj"
COPY "Services/Catalog/JCP.Catalog.Domain/JCP.Catalog.Domain.csproj" "Services/Catalog/JCP.Catalog.Domain/JCP.Catalog.Domain.csproj"
COPY "Services/Catalog/JCP.Catalog.Infrastructure/JCP.Catalog.Infrastructure.csproj" "Services/Catalog/JCP.Catalog.Infrastructure/JCP.Catalog.Infrastructure.csproj"
COPY "Services/Catalog/JCP.Catalog.UnitTests/JCP.Catalog.UnitTests.csproj" "Services/Catalog/JCP.Catalog.UnitTests/JCP.Catalog.UnitTests.csproj"
COPY "Services/Ordering/JCP.Ordering.API/JCP.Ordering.API.csproj" "Services/Ordering/JCP.Ordering.API/JCP.Ordering.API.csproj"
COPY "Services/Ordering/JCP.Ordering.UnitTests/JCP.Ordering.UnitTests.csproj" "Services/Ordering/JCP.Ordering.UnitTests/JCP.Ordering.UnitTests.csproj"
COPY "Services/Identity/JCP.IdentityServer.API/JCP.IdentityServer.API.csproj" "Services/Identity/JCP.IdentityServer.API/JCP.IdentityServer.API.csproj"]

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore "JCP-Shop.sln"

COPY . .
WORKDIR "/src/Services/Catalog/JCP.IdentityServer.API"
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JCP.IdentityServer.API.dll"]