# Image de base Node.js
FROM node:18-alpine

# Définir le répertoire de travail
WORKDIR /app

# Installation des dépendances
COPY package*.json ./
RUN npm install

# Copier le code source
COPY . .

# Variables d'environnement
ENV NODE_ENV=development
ENV VITE_API_URL=http://localhost:5269

# Exposer le port de développement Vite
EXPOSE 5173

# Configuration pour le hot-reload dans Docker
ENV CHOKIDAR_USEPOLLING=true
ENV WATCHPACK_POLLING=true

# Démarrer le serveur de développement
CMD ["npm", "run", "dev", "--", "--host"]
