#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src

COPY "JCP-Shop.sln" "JCP-Shop.sln"

COPY "BuildingBlocks/Logger/JCP.Logger/JCP.Logger.csproj" "BuildingBlocks/Logger/JCP.Logger/JCP.Logger.csproj"
COPY "Services/Catalog/Presentation/JCP.Catalog.API/JCP.Catalog.API.csproj" "Services/Catalog/Presentation/JCP.Catalog.API/JCP.Catalog.API.csproj"
COPY "Services/Catalog/Core/JCP.Catalog.Domain/JCP.Catalog.Domain.csproj" "Services/Catalog/Core/JCP.Catalog.Domain/JCP.Catalog.Domain.csproj"
COPY "Services/Catalog/Infrastructure/JCP.Catalog.Infrastructure/JCP.Catalog.Infrastructure.csproj" "Services/Catalog/Infrastructure/JCP.Catalog.Infrastructure/JCP.Catalog.Infrastructure.csproj"
COPY "Services/Ordering/JCP.Ordering.API/JCP.Ordering.API.csproj" "Services/Ordering/JCP.Ordering.API/JCP.Ordering.API.csproj"
COPY "Services/Ordering/JCP.Ordering.UnitTests/JCP.Ordering.UnitTests.csproj" "Services/Ordering/JCP.Ordering.UnitTests/JCP.Ordering.UnitTests.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

RUN dotnet restore "JCP-Shop.sln"

COPY . .
WORKDIR "/src/Services/Ordering/JCP.Ordering.API"
RUN dotnet publish --no-restore -c Release -o /app

FROM build as unittest
WORKDIR /src/Services/Ordering/Ordering.UnitTests

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JCP.Ordering.API.dll"]