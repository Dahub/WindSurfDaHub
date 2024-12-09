<template>
  <v-app-bar 
    color="primary" 
    elevation="4"
    class="px-3"
  >
    <router-link to="/" class="text-decoration-none text-white d-flex align-center">
      <v-img
        :src="logo"
        max-height="40"
        max-width="40"
        class="me-2"
        alt="DaGet Logo"
      ></v-img>
      <v-app-bar-title class="text-no-wrap">DaGet</v-app-bar-title>
    </router-link>

    <v-spacer></v-spacer>

    <v-btn
      icon
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
import { useRouter } from 'vue-router'
import auth from '@/services/auth'
import logo from '@/assets/logo.jpg'

const router = useRouter()

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

.v-app-bar-title{
  width: 150px !important;
}
</style>
