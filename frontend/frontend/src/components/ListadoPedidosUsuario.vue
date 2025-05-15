<script setup lang="ts">
import { ref, onMounted, defineProps } from 'vue'

import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();

const props = defineProps({ identificador: String });
const token = ref('');
const id = sessionStore.getId;

const pedidos = ref([]);

onMounted(() => {
  token.value = sessionStore.token;
  console.log(props.identificador)
  fetchPedidosUsuario();
  // TODO: pintar los pedidos
})

// Usuario/{usuarioId}/pedidos
async function fetchPedidosUsuario() {
  const url = new URL('http://localhost:8023/Usuario/' + id + '/pedidos');
  console.log(url.toString());

  console.log(url, {
    method: 'GET',
    headers: {
      'Accept': '*/*',
      'Authorization': `Bearer ${token.value}`,
      'Content-Type': 'application/json'
    }
  });

  const response = await fetch(url, {
    method: 'GET',
    headers: {
      'Accept': '*/*',
      'Authorization': `Bearer ${token.value}`,
      'Content-Type': 'application/json'
    }
  });
  const data = await response.json();
  pedidos.value = await data;
  console.log(data);
}

</script>

<template>
  <div>

  </div>
</template>
