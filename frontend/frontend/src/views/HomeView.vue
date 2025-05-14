<script setup lang="ts">
import CafeGrid from '../components/CafeGrid.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
import SearchbarCafe from '../components/SearchbarCafe.vue'
import { ref } from 'vue';

const filtro = ref('');

</script>

<template>
  <main>
    <h1>Home</h1>
    <SearchbarCafe v-on:searchCafe="filtro = $event" />
    <Login />
    <Register />
    <CafeGrid :filtrar="filtro" />
  </main>
</template>
