<template>
  <div class="cafe-grid">
    <div v-for="cafe in cafeStore.cafes" :key="cafe.id">
      <h3>{{ cafe.variedad }}</h3>
      <p>{{ cafe.tipo }}</p>
      <p>{{ cafe.precio }}$</p>
      <button v-on:click="anadir(cafe.id, cafe.variedad, cafe.tipo)">Añadir</button>
    </div>
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted, computed, watch, watchEffect } from 'vue';

import { useCafeStore } from '@/stores/cafeStore'

const cafeStore = useCafeStore();

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

</script>

<style></style>
