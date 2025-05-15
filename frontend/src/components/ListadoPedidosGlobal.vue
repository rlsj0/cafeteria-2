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
  <v-container>
    <v-row dense>
      <v-col v-for="pedido in pedidos" :key="pedido.id" cols="12">
        <v-card outlined class="pa-4 mb-4">
          <v-card-title class="text-h6">Pedido #{{ pedido.id }}</v-card-title>
          <v-card-subtitle>Fecha: {{ pedido.fecha }}</v-card-subtitle>

          <v-card-text>
            <p><strong>User ID:</strong> {{ pedido.usuarioId }}</p>
            <p><strong>Precio total:</strong> {{ pedido.precioTotal }}</p>

            <v-divider class="my-3"></v-divider>

            <v-list dense>
              <v-list-item v-for="detalle in pedido.pedidoDetallesCreateDto" :key="detalle.cafeId">
                <v-list-item-title>
                  {{ detalle.cafeId }})
                  {{cafeStore.cafes.find(c => c.id === detalle.cafeId).variedad}}:
                  {{cafeStore.cafes.find(c => c.id === detalle.cafeId).tipo}}
                </v-list-item-title>
                <v-list-item-subtitle>
                  Precio unitario: {{cafeStore.cafes.find(c => c.id === detalle.cafeId).precio}}
                </v-list-item-subtitle>
                <v-list-item-subtitle>
                  Cantidad: {{ detalle.cantidad }}
                </v-list-item-subtitle>
              </v-list-item>
            </v-list>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
