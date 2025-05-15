<script setup lang="ts">
import UserPrivateZoneBtn from '../components/UserPrivateZoneBtn.vue'
import AdminPrivateZoneBtn from '../components/AdminPrivateZoneBtn.vue'
import LogoutBtn from '../components/LogoutBtn.vue'
import { ref } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();

</script>

<template>
  <v-app-bar color="primary" density="comfortable" app>
    <div class="d-flex align-center justify-space-between w-100 px-4">
      <router-link to="/" class="text-white text-decoration-none text-h6">Cafetería 2</router-link>

      <div class="d-flex space-between">
        <UserPrivateZoneBtn v-if="sessionStore.token && !sessionStore.isAdmin" />
        <AdminPrivateZoneBtn v-if="sessionStore.token && sessionStore.isAdmin" />
        <LogoutBtn v-if="sessionStore.token" />
      </div>
    </div>
  </v-app-bar>
</template>

<style scoped></style>
