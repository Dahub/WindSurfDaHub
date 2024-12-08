<template>
  <v-app-bar 
    color="primary" 
    elevation="4"
    class="px-3"
  >
    <v-app-bar-nav-icon class="d-flex d-sm-none"></v-app-bar-nav-icon>
    
    <router-link to="/" class="text-decoration-none text-white d-flex align-center">
      <v-img
        :src="logo"
        max-height="40"
        max-width="40"
        class="me-2"
        alt="DaGet Logo"
      ></v-img>
      <v-app-bar-title>DaGet</v-app-bar-title>
    </router-link>

    <v-spacer></v-spacer>

    <div class="d-none d-sm-flex align-center">
      <v-btn
        variant="text"
        class="mx-2"
        :ripple="false"
      >
        Dashboard
      </v-btn>
      <v-btn
        variant="text"
        class="mx-2"
        :ripple="false"
      >
        Profil
      </v-btn>
    </div>

    <v-btn
      icon
      class="ms-3"
      @click="logout"
    >
      <v-icon>mdi-logout</v-icon>
      <v-tooltip
        activator="parent"
        location="bottom"
      >
        Se déconnecter
      </v-tooltip>
    </v-btn>
  </v-app-bar>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import auth from '@/services/auth'
import logo from '../assets/logo.jpg'

const router = useRouter()
const username = ref<string | null>(null)

onMounted(() => {
  const user = auth.getCurrentUser()
  username.value = user?.username
})

const logout = () => {
  auth.logout()
  router.push('/login')
}
</script>

<style scoped>
.v-app-bar {
  border-bottom: 1px solid rgba(255, 255, 255, 0.12);
}

.v-btn {
  letter-spacing: 0.5px;
  font-weight: 500;
  transition: background-color 0.2s ease;
}

.v-btn:hover {
  background-color: rgba(255, 255, 255, 0.1);
}
</style>
