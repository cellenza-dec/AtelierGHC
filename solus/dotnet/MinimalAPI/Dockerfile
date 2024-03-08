# Utilisez l'image de base .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Définissez le répertoire de travail
WORKDIR /app

# Copiez le fichier csproj et restorez les dépendances
COPY *.csproj .
RUN dotnet restore

# Copiez le reste du code source et construisez l'application
COPY . .
RUN dotnet publish -c Release -o out

# Utilisez l'image de base ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Définissez le répertoire de travail
WORKDIR /app

# Copiez les fichiers de l'étape de construction
COPY --from=build /app/out .

# Exposez le port 8080
EXPOSE 8080

# Démarrez l'application
ENTRYPOINT ["dotnet", "MinimalAPI.dll"]