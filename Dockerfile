FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar proyectos
COPY ["LibsClass/LibsClass.csproj", "LibsClass/"]
COPY ["Concesionario/Concesionario.csproj", "Concesionario/"]

RUN dotnet restore "Concesionario/Concesionario.csproj"

# Copiar todo el resto del proyecto
COPY . .

# Publicar
RUN dotnet publish "Concesionario/Concesionario.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Concesionario.dll"]
