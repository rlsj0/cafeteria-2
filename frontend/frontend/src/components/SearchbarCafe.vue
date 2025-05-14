<template>
  <div>
    <label>Variedad: </label>
    <input type="search" v-model="variedad" v-on:input="$emit('searchVariedad', variedad)"></input>
  </div>
  <div>
    <label>Tipo: </label>
    <input type="search" v-model="tipo" v-on:input="$emit('searchTipo', tipo)"></input>
  </div>
</template>
<!--TODO: recordemos que se puede buscar por variedad, tipo, y orderBy (precio o id) -->

<script setup lang="ts">

import { ref, defineEmits } from 'vue';

const emit = defineEmits(['searchVariedad', 'searchTipo']);

const variedad = ref('');
const tipo = ref('');

</script>

<style></style>
