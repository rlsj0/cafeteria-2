<template>
  <button v-on:click="cerrarSesion">
    Log out
  </button>
</template>

<script setup lang="ts">
import { useSessionStore } from '@/stores/sessionStore'
const sessionStore = useSessionStore();

function cerrarSesion() {
  sessionStore.logout();
}

</script>
