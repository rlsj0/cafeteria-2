<template>
  <div>
    <label>Variedad: </label>
    <input type="search" v-model="variedad" v-on:input="$emit('searchVariedad', variedad)"></input>
  </div>
  <div>
    <label>Tipo: </label>
    <input type="search" v-model="tipo" v-on:input="$emit('searchTipo', tipo)"></input>
  </div>
  <div>
    <p>Ordenar por: </p>
    <label>
      <input type="radio" name="orderBy" value="id" v-model="orderBy" v-on:change="$emit('orderBy', orderBy)" />
      Id
    </label>
    <label>
      <input type="radio" name="orderBy" value="precio" v-model="orderBy" v-on:change="$emit('orderBy', orderBy)" />
      Precio
    </label>
  </div>
  <div>
    <p>Orden: </p>
    <label>
      <input type="radio" name="orderDesc" value="true" v-model="orderDesc"
        v-on:change="$emit('orderDesc', orderDesc)" />
      Descendente
    </label>
    <label>
      <input type="radio" name="orderDesc" value="false" v-model="orderDesc"
        v-on:change="$emit('orderDesc', orderDesc)" />
      Ascendente
    </label>
  </div>
</template>

<script setup lang="ts">

import { ref, defineEmits } from 'vue';

const emit = defineEmits(['searchVariedad', 'searchTipo', 'orderBy', 'orderDesc']);

const variedad = ref('');
const tipo = ref('');
const orderBy = ref('');
const orderDesc = ref('');

</script>

<style></style>
