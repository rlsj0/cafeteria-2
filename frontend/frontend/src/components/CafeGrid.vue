<template>
  <div class="cafe-grid">
    <div v-for="cafe in cafes" :key="cafe.id">
      <h3>{{ cafe.variedad }}</h3>
      <p>{{ cafe.tipo }}</p>
      <p>{{ cafe.precio }}$</p>
      <button v-on:click="anadir(cafe.id, cafe.variedad, cafe.tipo)">Añadir</button>
    </div>
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted, computed, watch, watchEffect } from 'vue';

let cafes = ref(0);
const url = new URL('http://localhost:8023/Cafe');

onMounted(async () => {
  const response = await fetch(url);
  const data = await response.json();
  cafes.value = data;
});

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
  filtroTipo: String
})

const variedad = ref('');

// TODO: meter más filtros de búsqueda. Para ello, cambiar la propiedad de este componente (en vez
// de llamarse filtro, puede llamarse filtroVariedad, o similar.

// TODO: crear objeto filtros

const filtros = ref({
  Variedad: '',
  Tipo: ''
});

watch(() => props.filtroVariedad, (nuevoValor) => {
  //variedad.value. = nuevoValor;
  filtros.value.Variedad = nuevoValor;
  //console.log(variedad.value);
  //busquedaVariedad(variedad.value);
  busqueda(filtros.value);
})

watch(() => props.filtroTipo, (nuevoValor) => {
  filtros.value.Tipo = nuevoValor;
  busqueda(filtros.value);
})

// TODO: convertir en un método de búsqueda
const busquedaVariedad = async (variedad) => {
  if (variedad != null && variedad != '')
    url.searchParams.set('Variedad', variedad);
  else
    url.searchParams.delete('Variedad');
  const response = await fetch(url);
  const data = await response.json();
  cafes.value = data;
}

const busqueda = async (filtros) => {
  const urlBusqueda = new URL(url);

  for (const [clave, valor] of Object.entries(filtros)) {
    if (valor != null && valor != '') {
      urlBusqueda.searchParams.set(clave, valor);
    }
  }

  const response = await fetch(urlBusqueda);
  const data = await response.json();
  cafes.value = data;
};

</script>

<style></style>
