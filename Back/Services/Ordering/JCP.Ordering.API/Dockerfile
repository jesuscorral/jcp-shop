
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY  ["JCP.Ordering.API.csproj", "./Services/Ordering/"]
RUN dotnet restore "./Services/Ordering/JCP.Ordering.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "JCP.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JCP.Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JCP.Ordering.API.dll"]