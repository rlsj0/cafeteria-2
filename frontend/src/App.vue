<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
</script>

<template>
  <v-app class="d-flex flex-column min-h-screen">
    <Header />
    <v-main class="flex-grow-1 d-flex flex-column fill-height">
      <RouterView class="vh100" />
    </v-main>
    <Footer />
  </v-app>

</template>

<style></style>
