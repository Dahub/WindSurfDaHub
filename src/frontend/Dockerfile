# Image de base Node.js
FROM node:18-alpine

# Définir le répertoire de travail
WORKDIR /app

# Copier les fichiers de dépendances
COPY package*.json ./

# Installer toutes les dépendances
RUN npm install

# Forcer l'installation de sass
RUN npm install -D sass sass-loader 

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
