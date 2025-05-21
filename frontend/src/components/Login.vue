<template>
  <v-container class="d-flex justify-center align-center fill-height">
    <v-card class="pa-6">
      <v-card-title class="text-h5 mb-4">Iniciar sesión</v-card-title>

      <!-- Usamos .prevent para prevenir que se recargue -->
      <!-- El v-model nos permite desmarcar el disabled -->
      <v-form @submit.prevent="login" v-model="formValid">
        <v-text-field v-model="sessionStore.email" label="Email" id="email" type="email" :rules="emailRules" required />

        <v-text-field v-model="sessionStore.password" label="Contraseña" id="password" type="password"
          :rules="rulesPassword" required />

        <v-btn type="submit" color="primary" block class="mt-4" :disabled="!formValid">Iniciar sesión </v-btn>
      </v-form>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue';
import { useSessionStore } from '../stores/sessionStore'

const sessionStore = useSessionStore();

const formValid = ref(false);

const emailRules = [
  (value: string) => !!value || 'E-mail is required.',
  (value: string) => /.+@.+\..+/.test(value) || 'E-mail must be valid.',
]

const rulesPassword = [
  (value: string) => !!value || 'Password is required.',
  (v: string) => v.length >= 6 || 'Debe tener al menos 6 caracteres.',
]

// async await para que funcione
async function login() {
  // sessionStore.email = email.value;
  // sessionStore.password = password.value;
  //
  // console.log(email.value);

  await sessionStore.login();
}


</script>

<style></style>
