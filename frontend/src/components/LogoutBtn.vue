<template>
  <v-btn class="text-h6" v-on:click="cerrarSesion">Log out</v-btn>
</template>

<script setup lang="ts">
import { useSessionStore } from '@/stores/sessionStore'
const sessionStore = useSessionStore();

function cerrarSesion() {
  sessionStore.logout();
}

</script>
