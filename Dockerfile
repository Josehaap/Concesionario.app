# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar solución y proyectos (ajustado a tu estructura)
COPY Concesionario.app/Concesionario.app.sln ./
COPY Concesionario.app/Concesionario/Concesionario.csproj Concesionario/
COPY Concesionario.app/LibsClass/LibsClass.csproj LibsClass/

# Restaurar dependencias
RUN dotnet restore Concesionario.app.sln

# Copiar todo el código
COPY Concesionario.app/ .

# Publicar proyecto
RUN dotnet publish Concesionario/Concesionario.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render usa el puerto dinámico 10000 (o PORT si lo define)
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "Concesionario.dll"]

