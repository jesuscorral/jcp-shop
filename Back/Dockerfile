# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Services/JCP.Ordering.API/JCP.Ordering.API.csproj ./Services/JCP.Ordering.API/
RUN dotnet restore

# copy everything else and build app
COPY Services/JCP.Ordering.API/. ./Services/JCP.Ordering.API/
WORKDIR /Services/JCP.Ordering.API
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "jcp-ordering-api.dll"]
