<script setup lang="ts">
import LogoutBtn from '../components/LogoutBtn.vue'
import ListadoPedidosUsuario from '../components/ListadoPedidosUsuario.vue'
import { ref, onMounted } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();
const id = sessionStore.getId;

</script>

<template>

  <h1>Zona Privada de Usuario</h1>
  <p>Usuario número: {{ sessionStore.getId }} </p>
  <p>Correo: {{ sessionStore.getEmail }} </p>
  <h3>Listado de pedidos: </h3>
  <ListadoPedidosUsuario v-bind:identificador="id" />

</template>
