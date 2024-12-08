<template>
  <div class="login-container">
    <v-container fluid class="fill-height">
      <v-row align="center" justify="center">
        <v-col cols="12" sm="8" md="4" lg="3">
          <v-card class="login-card" elevation="8">
            <v-card-title class="text-center pt-6">
              <v-row align=start justify="end">
                <v-col class="shrink">
                  <v-img
                  :src="logo"
                  max-height="80"
                  max-width="80"
                  class="mb-4"
                  alt="DaGet Logo"
                  ></v-img>
                </v-col>
                <v-col>
                  <div class="d-flex flex-column align-center">
                    
                    <h1 class="text-h4 font-weight-bold mb-2">Connexion</h1>
                    <p class="text-subtitle-1 text-medium-emphasis">
                      Bienvenue sur DaGet
                    </p>
                  </div>
                </v-col>
              </v-row>
              
              
            </v-card-title>
                
            <v-card-text class="pt-4">
              <v-form @submit.prevent="handleSubmit">
                <v-text-field
                v-model="email"
                label="Email"
                type="email"
                variant="outlined"
                prepend-inner-icon="mdi-email"
                :rules="[rules.required, rules.email]"
                class="mb-4"
                ></v-text-field>
                
                <v-text-field
                v-model="password"
                label="Mot de passe"
                :type="showPassword ? 'text' : 'password'"
                variant="outlined"
                prepend-inner-icon="mdi-lock"
                :append-inner-icon="showPassword ? 'mdi-eye-off' : 'mdi-eye'"
                @click:append-inner="showPassword = !showPassword"
                :rules="[rules.required]"
                class="mb-6"
                ></v-text-field>
                
                <v-alert
                v-if="error"
                type="error"
                variant="tonal"
                class="mb-4"
                closable
                >
                {{ error }}
              </v-alert>
              
              <v-btn
              type="submit"
              color="primary"
              block
              size="large"
              :loading="loading"
              class="mb-4"
              >
              Se connecter
            </v-btn>
          </v-form>
        </v-card-text>
        
        <v-card-text class="text-center pb-4">
          <p class="text-body-2 text-medium-emphasis">
            Pas encore de compte ?
            <v-btn
            variant="text"
            color="primary"
            class="px-2 font-weight-bold"
            @click="router.push('/register')"
            >
            S'inscrire
          </v-btn>
        </p>
      </v-card-text>
    </v-card>
  </v-col>
</v-row>
</v-container>
</div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import auth from '@/services/auth'
import logo from '../assets/logo.jpg'

const router = useRouter()
const email = ref('')
const password = ref('')
const error = ref('')
const loading = ref(false)
const showPassword = ref(false)

const rules = {
  required: (v: string) => !!v || 'Ce champ est requis',
  email: (v: string) => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'Adresse email invalide'
}

const handleSubmit = async () => {
  if (!email.value || !password.value) {
    error.value = 'Veuillez remplir tous les champs'
    return
  }
  
  loading.value = true
  error.value = ''
  
  try {
    await auth.login({ email: email.value, password: password.value })
    // Redirection vers la page principale après connexion réussie
    router.push({ name: 'home' })
  } catch (err: any) {
    error.value = err.message
  } finally {
    loading.value = false
  }
}
</script>

<style scoped>
.login-container {
  background: linear-gradient(135deg, #f5f7fa 0%, #e4e8eb 100%);
  min-height: 100vh;
}

.login-card {
  border-radius: 16px;
  background: rgba(255, 255, 255, 0.95);
}

.v-text-field :deep(.v-field__outline__start) {
  border-radius: 10px 0 0 10px;
}

.v-text-field :deep(.v-field__outline__end) {
  border-radius: 0 10px 10px 0;
}

.v-btn {
  text-transform: none;
  letter-spacing: 0.5px;
}
</style>
