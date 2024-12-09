<template>
  <v-app>
    <NavBar />
    
    <v-main class="bg-grey-lighten-4">
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-card class="mx-auto pa-6" elevation="2">
              <div class="text-center">
                <h1 class="text-h4 font-weight-bold mb-4">TODO</h1>
              </div>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import NavBar from '@/components/NavBar.vue'
</script>