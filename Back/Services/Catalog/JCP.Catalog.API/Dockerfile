#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Catalog/JCP.Catalog.API/JCP.Catalog.API.csproj", "Services/Catalog/JCP.Catalog.API/"]
RUN dotnet restore "Services/Catalog/JCP.Catalog.API/JCP.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/JCP.Catalog.API"
RUN dotnet build "JCP.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JCP.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JCP.Catalog.API.dll"]