<template>
  <v-container class="d-flex justify-center align-center fill-height">
    <v-card class="pa-6 w-auto">
      <v-card-title class="text-h5 mb-4">Registrarse</v-card-title>
      <!-- Usamos .prevent para prevenir que se recargue -->
      <v-form @submit.prevent="register" v-model="formValid">
        <v-text-field v-model="email" label="Email" id="email" type="email" :rules="emailRules" />
        <v-text-field v-model="password" label="Password" id="password" type="password" :rules="passwordRules" />

        <v-btn type="submit" color="primary" block class="mt-4" :disabled="!formValid">Regístrate</v-btn>
      </v-form>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue';

const formValid = ref(false);

const emailRules = [
  (value: string) => !!value || 'E-mail is required.',
  (value: string) => /.+@.+\..+/.test(value) || 'E-mail must be valid.',
]

const passwordRules = [
  (value: string) => !!value || 'Password is required.',
  (v: string) => v.length >= 6 || 'Debe tener al menos 6 caracteres.',
]

const email = ref('');
const password = ref('');

class User {
  constructor(email, password) {
    this.correo = email;
    this.contrasena = password;
  }
}

async function register() {
  console.log(email.value);
  console.log(password.value);
  console.log(JSON.stringify(new User(email.value, password.value)));

  const response = await fetch('http://localhost:8023/Auth/Register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(new User(email.value, password.value))
  })

  if (response.ok) {
    alert('Registro correcto!');
    email.value = '';
    password.value = '';
  } else {
    const errorData = await response.text();
    alert('Ha habido un problema: ' + errorData);
  }
}

</script>

<style></style>
