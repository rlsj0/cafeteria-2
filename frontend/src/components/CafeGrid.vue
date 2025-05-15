<template>
  <div>
    <v-btn color="primary" class="mb-4" @click="confirmarPedido" v-if="sessionStore.token && !sessionStore.isAdmin"
      :disabled="detallesPedido.length === 0">
      Confirmar pedido
    </v-btn>

    <v-row dense>
      <v-col v-for="cafe in cafeStore.cafes" :key="cafe.id" class="d-flex justify-center">
        <v-card outlined class="pa-4" style="min-width: 250px;">
          <div>
            <v-card-title class="text-h6">{{ cafe.variedad }}</v-card-title>
            <v-card-subtitle class="mb-2">{{ cafe.tipo }}</v-card-subtitle>
            <v-card-text>
              <p class="mb-1"><strong>Precio:</strong> {{ cafe.precio }} $</p>
              <p class="mb-1">Cantidad disponible: {{ cafe.cantidadStock }}</p>
            </v-card-text>
          </div>

          <v-card-actions>
            <v-btn color="primary" block @click="anadir(cafe.id, cafe.variedad, cafe.tipo)"
              :disabled="cafe.cantidadStock === 0" v-if="sessionStore.token && !sessionStore.isAdmin">
              Añadir
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted, computed, watch, watchEffect } from 'vue';

import { useCafeStore } from '@/stores/cafeStore'
import { useSessionStore } from '@/stores/sessionStore'

const cafeStore = useCafeStore();
const sessionStore = useSessionStore();

onMounted(async () => {
  cafeStore.fetchCafes();
});

// TODO: revisar el tema este del pedido
const detallesPedido = ref([]);

// Le meto el nombre pero tendremos que quitarlo al hacer el POST
class Detalle {
  constructor(id, variedad, tipo) {
    this.id = id;
    this.nombre = variedad + ": " + tipo;
    this.cantidad = 1;
  }
}

function anadir(id, variedad, tipo) {
  // Revisar la lista para ver si ya hay un detalle con esa id de café
  // Si la hay añadir una cifra de cantidad
  // Si no la hay agregar un nuevo objeto detalle a la lista
  const existe = detallesPedido.value.find(d => d.id == id);
  if (existe) {
    existe.cantidad += 1;
  } else {
    detallesPedido.value.push(new Detalle(id, variedad, tipo));
  }
  console.log(JSON.stringify(detallesPedido.value, null, 2));
}

// PARTE DE COGER EL VALOR DEL PADRE

const props = defineProps({
  filtroVariedad: String,
  filtroTipo: String,
  filtroOrderBy: String,
  filtroOrderDesc: String
})

watch(() => props.filtroVariedad, (nuevoValor) => {
  cafeStore.filtros.Variedad = nuevoValor;
  cafeStore.fetchCafes();
})

watch(() => props.filtroTipo, (nuevoValor) => {
  cafeStore.filtros.Tipo = nuevoValor;
  cafeStore.fetchCafes();
})

watch(() => props.filtroOrderBy, (nuevoValor) => {
  cafeStore.filtros.OrderBy = nuevoValor;
  cafeStore.fetchCafes();
})

watch(() => props.filtroOrderDesc, (nuevoValor) => {
  cafeStore.filtros.Desc = nuevoValor;
  cafeStore.fetchCafes();
})

async function confirmarPedido() {
  if (detallesPedido.value.length == 0) {
    // alert para que salga un aviso al usuario
    alert("No hay cafés en el pedido.");
    return;
  }

  const usuarioId = sessionStore.getId;
  const token = ref('');
  token.value = sessionStore.token;

  const pedido = {
    clienteSatisfecho: true,
    pedidoDetallesCreateDto: detallesPedido.value.map(detalle => ({
      cafeId: detalle.id,
      cantidad: detalle.cantidad
    }))
  };

  try {
    const response = await fetch('http://localhost:8023/Pedido', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token.value}`
      },
      body: JSON.stringify(pedido)
    });

    alert("Pedido realizado con éxito");
    // Acordarse de limpiar la lista de pedidos
    detallesPedido.value = [];
  } catch (ex) {
    console.log(ex);
    alert("No se pudo hacer el pedido");
  }
}

</script>

<style></style>
