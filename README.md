# DaGet

Une application web moderne de gestion financière construite avec Vue.js et .NET 8, suivant les principes du Clean Architecture.

## Architecture

### Frontend (Vue.js + TypeScript)

L'application frontend est construite avec Vue.js 3 et suit une architecture modulaire :

```
src/frontend/
├── src/
│   ├── assets/          # Ressources statiques
│   ├── components/      # Composants réutilisables
│   ├── services/        # Services d'API et logique métier
│   ├── views/           # Composants de pages
│   ├── router/          # Configuration des routes
│   └── main.ts         # Point d'entrée
```

#### Technologies Frontend
- **Vue.js 3** avec Composition API pour une meilleure réutilisation du code
- **TypeScript** pour le typage statique
- **Vuetify 3** pour les composants UI Material Design
- **Vite** pour le bundling et le développement
- **Axios** pour les appels API
- **Vue Router** pour la navigation
- **Pinia** pour la gestion d'état (prévu)

### Backend (.NET 8)

Le backend suit les principes du Clean Architecture avec une séparation claire des responsabilités :

```
src/backend/
├── DaGet.Api/            # Couche API
├── DaGet.Application/    # Couche Application
├── DaGet.Domain/         # Couche Domain
└── DaGet.Infrastructure/ # Couche Infrastructure
```

#### Technologies Backend
- **.NET 8** pour les performances et les fonctionnalités modernes
- **Entity Framework Core 8** pour l'ORM
- **SQL Server** pour la persistance
- **MediatR** pour l'implémentation CQRS
- **FluentValidation** pour la validation des données (prévu)

#### Patterns & Principes
- **Clean Architecture** pour une séparation claire des responsabilités
- **CQRS** (Command Query Responsibility Segregation) pour séparer les lectures des écritures
- **Domain-Driven Design** pour la modélisation du domaine
- **Repository Pattern** pour l'abstraction de la persistance

### Infrastructure

Le projet utilise Docker pour la containerisation et assure une configuration cohérente entre les environnements :

```yaml
services:
  frontend:    # Vue.js sur le port 5173
  backend:     # API .NET sur le port 5269
  db:          # SQL Server sur le port 1433
```

## Démarrage Rapide

1. **Prérequis**
   - Docker Desktop
   - .NET SDK 8.0 (pour le développement)
   - Node.js 18+ (pour le développement)

2. **Lancement avec Docker**
   ```bash
   docker-compose up --build
   ```

3. **Accès**
   - Frontend : http://localhost:5173
   - API : http://localhost:5269
   - Swagger : http://localhost:5269/swagger

## Authentification

- JWT pour l'authentification stateless
- Validation d'email unique
- Hachage sécurisé des mots de passe
- Gestion des sessions avec refresh tokens (prévu)

## Sécurité

- HTTPS en production
- Protection CSRF
- Validation des entrées
- Gestion sécurisée des mots de passe
- Headers de sécurité configurés

## Tests (Prévu)

- Tests unitaires avec xUnit et Jest
- Tests d'intégration
- Tests E2E avec Cypress
- Tests de performance avec k6

## CI/CD (Prévu)

- GitHub Actions pour l'intégration continue
- Déploiement automatisé
- Analyse de code avec SonarQube
- Scan de sécurité des dépendances

## Contribution

1. Fork le projet
2. Créez une branche (`git checkout -b feature/nouvelle-fonctionnalite`)
3. Committez vos changements (`git commit -m 'Ajout d'une nouvelle fonctionnalité'`)
4. Push vers la branche (`git push origin feature/nouvelle-fonctionnalite`)
5. Créez une Pull Request

## License

MIT
