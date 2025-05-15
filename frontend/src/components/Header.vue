<script setup lang="ts">
import UserPrivateZoneBtn from '../components/UserPrivateZoneBtn.vue'
import AdminPrivateZoneBtn from '../components/AdminPrivateZoneBtn.vue'
import LogoutBtn from '../components/LogoutBtn.vue'
import { ref } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();

</script>

<template>
  <v-app-bar>
    <router-link to="/">
      <h1>Cafetería 2</h1>
    </router-link>
    <nav>
      <UserPrivateZoneBtn v-if="sessionStore.token && !sessionStore.isAdmin" />
      <AdminPrivateZoneBtn v-if="sessionStore.token && sessionStore.isAdmin" />
      <LogoutBtn v-if="sessionStore.token" />
    </nav>
  </v-app-bar>
</template>
