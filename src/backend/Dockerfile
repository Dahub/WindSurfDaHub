# Utiliser l'image SDK .NET 8.0 pour le développement
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Définir le répertoire de travail
WORKDIR /app

# Installer les outils de développement nécessaires
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copier les fichiers projet et restaurer les dépendances
COPY ["src/backend/WindSurfDaGet.Api/WindSurfDaGet.Api.csproj", "src/backend/WindSurfDaGet.Api/"]
COPY ["src/backend/WindSurfDaGet.Application/WindSurfDaGet.Application.csproj", "src/backend/WindSurfDaGet.Application/"]
COPY ["src/backend/WindSurfDaGet.Domain/WindSurfDaGet.Domain.csproj", "src/backend/WindSurfDaGet.Domain/"]
COPY ["src/backend/WindSurfDaGet.Infrastructure/WindSurfDaGet.Infrastructure.csproj", "src/backend/WindSurfDaGet.Infrastructure/"]

# Restaurer les packages
RUN dotnet restore "src/backend/WindSurfDaGet.Api/WindSurfDaGet.Api.csproj"

# Copier le reste des fichiers
COPY src/backend/. ./src/backend/

# Définir le répertoire de travail pour l'API
WORKDIR "/app/src/backend/WindSurfDaGet.Api"

# Exposer le port de l'application
EXPOSE 5269

# Configuration pour ASP.NET Core
ENV ASPNETCORE_URLS=http://+:5269
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_WATCH_RESTART_ON_RUDE_EDIT=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true
ENV ASPNETCORE_LOGGING__CONSOLE__FORMATTEROPTIONSNAME=Simple

# Désactiver le lancement automatique du navigateur
ENV DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER=true

# Utiliser dotnet watch pour le hot reload avec options de débogage
ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "--no-launch-profile"]
