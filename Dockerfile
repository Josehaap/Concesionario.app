# -------------------------------
# Etapa 1: Build
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copiar solución y proyectos para aprovechar cache de restore
COPY Concesionario.app.sln ./
COPY Concesionario/Concesionario.csproj ./Concesionario/
COPY LibsClass/*.csproj ./LibsClass/

# Restaurar dependencias
RUN dotnet restore Concesionario.app.sln

# Copiar todo el código fuente
COPY . ./

# Publicar Blazor Server
RUN dotnet publish Concesionario/Concesionario.csproj -c Release -o /app/publish

# -------------------------------
# Etapa 2: Runtime
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copiar solo lo publicado
COPY --from=build /app/publish .

# Puerto dinámico de Render
ENV DOTNET_URLS=http://*:${PORT}
EXPOSE 5000

# Ejecutar la app
ENTRYPOINT ["dotnet", "Concesionario.dll"]

