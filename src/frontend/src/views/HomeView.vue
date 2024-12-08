<template>
  <v-app>
    <NavBar />
    
    <v-main class="bg-grey-lighten-4">
      <v-container>
        <v-row>
          <v-col cols="12" class="mb-6">
            <v-card class="mx-auto pa-6" elevation="2">
              <div class="d-flex align-center mb-6">
                <div>
                  <h1 class="text-h4 font-weight-bold mb-2">
                    Tableau de bord
                  </h1>
                  <p class="text-subtitle-1 text-medium-emphasis mb-0">
                    Bienvenue sur votre espace personnel
                  </p>
                </div>
                <v-spacer></v-spacer>
                <v-btn
                  color="primary"
                  prepend-icon="mdi-plus"
                  size="large"
                >
                  Nouvelle action
                </v-btn>
              </div>

              <v-divider class="mb-6"></v-divider>

              <v-row>
                <v-col cols="12" sm="6" md="3">
                  <v-card
                    class="pa-4"
                    elevation="1"
                    :color="'primary'"
                    theme="dark"
                  >
                    <div class="d-flex justify-space-between align-center">
                      <div>
                        <div class="text-subtitle-2 mb-1">Total Users</div>
                        <div class="text-h4 font-weight-bold">1,294</div>
                      </div>
                      <v-icon size="42" icon="mdi-account-group"></v-icon>
                    </div>
                  </v-card>
                </v-col>

                <v-col cols="12" sm="6" md="3">
                  <v-card
                    class="pa-4"
                    elevation="1"
                    color="success"
                    theme="dark"
                  >
                    <div class="d-flex justify-space-between align-center">
                      <div>
                        <div class="text-subtitle-2 mb-1">Active Sessions</div>
                        <div class="text-h4 font-weight-bold">432</div>
                      </div>
                      <v-icon size="42" icon="mdi-clock"></v-icon>
                    </div>
                  </v-card>
                </v-col>

                <v-col cols="12" sm="6" md="3">
                  <v-card
                    class="pa-4"
                    elevation="1"
                    color="warning"
                    theme="dark"
                  >
                    <div class="d-flex justify-space-between align-center">
                      <div>
                        <div class="text-subtitle-2 mb-1">Pending Tasks</div>
                        <div class="text-h4 font-weight-bold">64</div>
                      </div>
                      <v-icon size="42" icon="mdi-clipboard-list"></v-icon>
                    </div>
                  </v-card>
                </v-col>

                <v-col cols="12" sm="6" md="3">
                  <v-card
                    class="pa-4"
                    elevation="1"
                    color="error"
                    theme="dark"
                  >
                    <div class="d-flex justify-space-between align-center">
                      <div>
                        <div class="text-subtitle-2 mb-1">Issues</div>
                        <div class="text-h4 font-weight-bold">5</div>
                      </div>
                      <v-icon size="42" icon="mdi-alert-circle"></v-icon>
                    </div>
                  </v-card>
                </v-col>
              </v-row>

              <v-row class="mt-6">
                <v-col cols="12" md="8">
                  <v-card elevation="1">
                    <v-card-title class="text-h6 font-weight-bold pa-4">
                      Activité récente
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-list lines="two">
                      <v-list-item
                        v-for="(item, index) in recentActivity"
                        :key="index"
                        :title="item.title"
                        :subtitle="item.subtitle"
                        :prepend-icon="item.icon"
                      >
                        <template v-slot:append>
                          <div class="text-caption text-medium-emphasis">
                            {{ item.time }}
                          </div>
                        </template>
                      </v-list-item>
                    </v-list>
                  </v-card>
                </v-col>

                <v-col cols="12" md="4">
                  <v-card elevation="1">
                    <v-card-title class="text-h6 font-weight-bold pa-4">
                      Tâches en cours
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-list>
                      <v-list-item
                        v-for="(task, index) in tasks"
                        :key="index"
                        :title="task.title"
                        :subtitle="task.dueDate"
                      >
                        <template v-slot:prepend>
                          <v-checkbox-btn :model-value="task.completed"></v-checkbox-btn>
                        </template>
                        <template v-slot:append>
                          <v-chip
                            :color="task.priority.color"
                            size="small"
                            class="text-caption"
                          >
                            {{ task.priority.label }}
                          </v-chip>
                        </template>
                      </v-list-item>
                    </v-list>
                  </v-card>
                </v-col>
              </v-row>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import NavBar from '@/components/NavBar.vue'

const recentActivity = ref([
  {
    title: 'Nouvelle connexion détectée',
    subtitle: 'Une nouvelle connexion a été détectée depuis Paris, France',
    icon: 'mdi-login',
    time: 'Il y a 5 minutes'
  },
  {
    title: 'Mise à jour du profil',
    subtitle: 'Les informations du profil ont été mises à jour avec succès',
    icon: 'mdi-account-edit',
    time: 'Il y a 2 heures'
  },
  {
    title: 'Nouveau message',
    subtitle: 'Vous avez reçu un nouveau message de support',
    icon: 'mdi-message',
    time: 'Il y a 5 heures'
  }
])

const tasks = ref([
  {
    title: 'Mettre à jour la documentation',
    dueDate: 'Échéance : Aujourd\'hui',
    completed: false,
    priority: { label: 'Urgent', color: 'error' }
  },
  {
    title: 'Réviser les paramètres de sécurité',
    dueDate: 'Échéance : Demain',
    completed: true,
    priority: { label: 'Normal', color: 'primary' }
  },
  {
    title: 'Planifier la réunion mensuelle',
    dueDate: 'Échéance : Cette semaine',
    completed: false,
    priority: { label: 'Faible', color: 'success' }
  }
])
</script>

<style scoped>
.v-card {
  transition: transform 0.2s;
}

.v-card:hover {
  transform: translateY(-2px);
}

.v-list-item {
  transition: background-color 0.2s;
}

.v-list-item:hover {
  background-color: rgb(var(--v-theme-primary), 0.05);
}
</style>
