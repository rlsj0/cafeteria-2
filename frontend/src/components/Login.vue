<template>
  <div>
    <!-- Usamos .prevent para prevenir que se recargue -->
    <form @submit.prevent="login">
      <div>
        <label for="email">Email</label>
        <input type="email" id="email" v-model="sessionStore.email" required />
      </div>

      <div>
        <label for="password">Contraseña</label>
        <input type="password" id="password" v-model="sessionStore.password" required />
      </div>

      <button type="submit">Iniciar sesión </button>
    </form>
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();

// async await para que funcione
async function login() {
  sessionStore.email = email.value;
  sessionStore.password = password.value;

  await sessionStore.login();
}


</script>

<style></style>
