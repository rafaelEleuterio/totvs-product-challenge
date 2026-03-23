# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo do contexto (backend/src)
COPY src ./src

# Restaura e publica

RUN dotnet restore "src/ProducManager.Api/ProducManager.Api.csproj"
RUN dotnet publish "src/ProducManager.Api/ProducManager.Api.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "ProducManager.Api.dll"]