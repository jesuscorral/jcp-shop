#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["JCP.Ordering.API/JCP.Ordering.API.csproj", "JCP.Ordering.API/"]
RUN dotnet restore "JCP.Ordering.API/JCP.Ordering.API.csproj"
COPY . .
WORKDIR "/src/JCP.Ordering.API"
RUN dotnet build "JCP.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JCP.Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JCP.Ordering.API.dll"]