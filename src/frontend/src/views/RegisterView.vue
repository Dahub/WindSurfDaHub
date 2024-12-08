<template>
  <v-app>
    <v-main>
      <v-container class="fill-height">
        <v-row justify="center">
          <v-col cols="12" sm="8" md="6" lg="4">
            <v-card class="elevation-12">
              <v-card-title class="text-center py-4">
                <v-img
                  :src="logo"
                  max-height="80"
                  max-width="80"
                  class="mb-4"
                  alt="DaGet Logo"
                ></v-img>
                <h1 class="text-h4 font-weight-bold mb-2">Inscription</h1>
                <p class="text-subtitle-1 text-medium-emphasis">
                  Créez votre compte DaGet
                </p>
              </v-card-title>
              <v-card-text>
                <v-form @submit.prevent="handleSubmit">
                  <v-text-field
                    v-model="email"
                    label="Email"
                    type="email"
                    required
                    prepend-icon="mdi-email"
                  ></v-text-field>
                  <v-text-field
                    v-model="username"
                    label="Nom d'utilisateur"
                    required
                    prepend-icon="mdi-account"
                  ></v-text-field>
                  <v-text-field
                    v-model="password"
                    label="Mot de passe"
                    :type="showPassword ? 'text' : 'password'"
                    required
                    prepend-icon="mdi-lock"
                    :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                    @click:append="showPassword = !showPassword"
                  ></v-text-field>
                  <v-text-field
                    v-model="confirmPassword"
                    label="Confirmer le mot de passe"
                    :type="showPassword ? 'text' : 'password'"
                    required
                    prepend-icon="mdi-lock"
                    :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                    @click:append="showPassword = !showPassword"
                  ></v-text-field>
                  <v-btn
                    type="submit"
                    block
                    color="primary"
                    class="mt-4"
                    :loading="loading"
                  >
                    S'inscrire
                  </v-btn>
                  <v-alert v-if="error" type="error" class="mt-4">
                    {{ error }}
                  </v-alert>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-row justify="center" class="mb-4">
                  <v-btn
                    variant="text"
                    @click="$router.push('/login')"
                  >
                    Déjà un compte ? Se connecter
                  </v-btn>
                </v-row>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import auth from '@/services/auth'

const router = useRouter()
const email = ref('')
const username = ref('')
const password = ref('')
const confirmPassword = ref('')
const error = ref('')
const showPassword = ref(false)
const loading = ref(false)

const handleSubmit = async () => {
  if (!email.value || !username.value || !password.value || !confirmPassword.value) {
    error.value = 'Veuillez remplir tous les champs'
    return
  }

  if (password.value !== confirmPassword.value) {
    error.value = 'Les mots de passe ne correspondent pas'
    return
  }

  loading.value = true
  error.value = ''

  try {
    await auth.register(email.value, username.value, password.value)
    router.push('/login')
  } catch (err: any) {
    error.value = err.message
  } finally {
    loading.value = false
  }
}
</script>
