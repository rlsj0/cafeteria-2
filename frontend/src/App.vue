<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import Header from './components/Header.vue'
import Footer from './components/Footer.vue'
</script>

<template>
  <v-app>
    <Header />
    <v-main>
      <RouterView />
    </v-main>
    <Footer />
  </v-app>

</template>

<style></style>
