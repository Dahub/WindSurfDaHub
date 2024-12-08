# WindSurfDaGet

Application full-stack moderne utilisant Flutter Web, .NET 8, et SQL Server, le tout conteneurisé avec Docker.

## Stack Technique

### Frontend
- Flutter Web
- Material Design 3
- HTTP pour les appels API
- Nginx comme serveur web

### Backend
- .NET 8 Minimal API
- Architecture Clean
- Support CORS
- Swagger/OpenAPI

### Infrastructure
- Docker & Docker Compose
- SQL Server 2022
- Nginx reverse proxy

## Prérequis
- Docker Desktop
- Git

## Installation et Démarrage

1. Cloner le repository :
```bash
git clone [votre-repo-url]
cd WindSurfDaGet
```

2. Lancer l'application :
```bash
docker-compose up --build
```

## Accès aux Services

- Frontend : http://localhost
- Backend API : http://localhost:5000/swagger
- Base de données : localhost:1433

## Structure du Projet

```
WindSurfDaGet/
├── src/
│   ├── frontend/           # Application Flutter
│   │   ├── lib/           # Code source Flutter
│   │   ├── web/          # Fichiers web
│   │   ├── Dockerfile    # Configuration Docker frontend
│   │   └── nginx.conf    # Configuration Nginx
│   │
│   └── backend/           # API .NET
│       ├── WindSurfDaGet.Api/      # API Layer
│       ├── WindSurfDaGet.Domain/   # Domain Layer
│       └── Dockerfile             # Configuration Docker backend
│
└── docker-compose.yml    # Configuration Docker Compose
```

## Fonctionnalités Actuelles
- Interface utilisateur Flutter moderne
- Communication frontend-backend via API REST
- Exemple d'endpoint "Hello World"
- Conteneurisation complète de l'application

## Développement

### Frontend
Le frontend Flutter est servi via Nginx et communique avec le backend via un proxy inverse.
Les appels API sont configurés pour passer par le chemin `/api/`.

### Backend
L'API .NET expose ses endpoints via Swagger UI pour faciliter les tests et la documentation.
CORS est configuré pour permettre les appels depuis le frontend.

### Base de données
SQL Server est accessible sur le port standard 1433.
Les données sont persistées via un volume Docker.

## Variables d'Environnement

### Frontend
- `BACKEND_URL`: URL du backend (configuré via nginx)

### Backend
- `ASPNETCORE_ENVIRONMENT`: Environment .NET
- `ASPNETCORE_URLS`: URLs d'écoute de l'API

### Base de données
- `SA_PASSWORD`: Mot de passe SQL Server
- `ACCEPT_EULA`: Acceptation licence SQL Server

## À Venir
- [ ] Authentification utilisateur
- [ ] Tests automatisés
- [ ] CI/CD
- [ ] Monitoring
- [ ] Logging centralisé
