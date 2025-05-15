<script setup lang="ts">
import LogoutBtn from '../components/LogoutBtn.vue'
import ListadoPedidosGlobal from '../components/ListadoPedidosGlobal.vue'
import { ref, onMounted } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();
const id = sessionStore.getId;

</script>

<template>

  <h1 class="text-h3 pa-4">Zona Privada de Admin</h1>
  <h3 class="text-h4 pa-4">Listado global de pedidos: </h3>
  <!-- <ListadoPedidosUsuario v-bind:identificador="id" />-->
  <ListadoPedidosGlobal />

</template>
