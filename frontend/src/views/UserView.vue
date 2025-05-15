<script setup lang="ts">
import LogoutBtn from '../components/LogoutBtn.vue'
import ListadoPedidosUsuario from '../components/ListadoPedidosUsuario.vue'
import { ref, onMounted } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();
const id = sessionStore.getId;

</script>

<template>

  <h1 class="text-h3 pa-4">Zona Privada de Usuario</h1>
  <p class="text-subtitle-1">Usuario número: {{ sessionStore.getId }} </p>
  <p class="text-subtitle-1">Correo: {{ sessionStore.getEmail }} </p>
  <h3 class="text-h5 pa-4">Listado de pedidos: </h3>
  <ListadoPedidosUsuario v-bind:identificador="id" />

</template>
