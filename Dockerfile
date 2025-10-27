# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar todo desde Concesionario.app (contexto de build)
COPY . ./

# Restaurar la solución
RUN dotnet restore Concesionario.app.sln

# Publicar el proyecto Blazor Server
RUN dotnet publish Concesionario/Concesionario.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Puerto dinámico asignado por Render
ENV DOTNET_URLS=http://*:${PORT}
EXPOSE 5000

# Ejecutar la aplicación
ENTRYPOINT ["dotnet", "Concesionario.dll"]
