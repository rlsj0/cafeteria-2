<template>
  <div>
    <label>Variedad: </label>
    <input type="search" v-model="searchword" v-on:input="$emit('searchCafe', searchword)"></input>
  </div>
  <!--TODO: recordemos que se puede buscar por variedad, tipo, y orderBy (precio o id) -->
</template>

<script setup lang="ts">

import { ref } from 'vue';

const searchword = ref('');

// function searchCafe() {
//   console.log(searchword.value);
// }

</script>

<style></style>
