# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo do contexto (backend/src)
COPY . .

# Vai até o projeto da API
WORKDIR /src/ProducManager.Api

# Restaura e publica
RUN dotnet restore "ProductManager.Api.csproj"
RUN dotnet publish "ProductManager.Api.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "ProductManager.Api.dll"]