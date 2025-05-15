<script setup lang="ts">
import { ref, onMounted, defineProps } from 'vue'

import { useSessionStore } from '@/stores/sessionStore'
import { useCafeStore } from '@/stores/cafeStore'

const sessionStore = useSessionStore();
const cafeStore = useCafeStore();

// const props = defineProps({ identificador: String });
const token = ref('');
const id = sessionStore.getId;

const pedidos = ref([]);

onMounted(async () => {
  token.value = sessionStore.token;

  // Limpiar los filtros para que salgan todos los cafés
  cafeStore.filtros.Variedad = '';
  cafeStore.filtros.Tipo = '';
  cafeStore.filtros.OrderBy = '';
  cafeStore.filtros.Desc = '';

  await cafeStore.fetchCafes();
  await fetchPedidos();
})

// Usuario/{usuarioId}/pedidos
async function fetchPedidos() {
  const url = new URL('http://localhost:8023/Pedido');

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
    <div v-for="pedido in pedidos" :key="pedido.id">
      <br />
      <p>Fecha: {{ pedido.fecha }}</p>
      <p>Id del pedido: {{ pedido.id }}</p>
      <p>User id: {{ pedido.usuarioId }}</p>
      <p>Precio total: {{ pedido.precioTotal }}</p>
      <div v-for="detalle in pedido.pedidoDetallesCreateDto" :key="detalle.cafeId">
        <p>{{ detalle.cafeId }}) {{cafeStore.cafes.find(c => c.id === detalle.cafeId).variedad}}:
          {{cafeStore.cafes.find(c => c.id === detalle.cafeId).tipo}}</p>
        <p>Precio unitario:
          {{cafeStore.cafes.find(c => c.id === detalle.cafeId).precio}}</p>
        <p>Cantidad: {{ detalle.cantidad }}</p>
      </div>
    </div>
  </div>
</template>
