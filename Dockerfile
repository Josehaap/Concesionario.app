# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar todo el repo
COPY . ./

# Restaurar la solución
RUN dotnet restore Concesionario.App/Concesionario.app.sln

# Publicar el proyecto Blazor Server
RUN dotnet publish Concesionario.App/Concesionario/Concesionario.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Puerto dinámico de Render
ENV DOTNET_URLS=http://*:${PORT}
EXPOSE 5000

# Ejecutar la app
ENTRYPOINT ["dotnet", "Concesionario.dll"]
