<script setup lang="ts">
import CafeGrid from '../components/CafeGrid.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
import SearchbarCafe from '../components/SearchbarCafe.vue'
import UserPrivateZoneBtn from '../components/UserPrivateZoneBtn.vue'
import LogoutBtn from '../components/LogoutBtn.vue'
import { ref } from 'vue';
import { useSessionStore } from '@/stores/sessionStore'

const sessionStore = useSessionStore();

const variedad = ref('');
const tipo = ref('');
const orderBy = ref('');
const orderDesc = ref('');

</script>

<template>
  <main>
    <h1>Home</h1>
    <SearchbarCafe v-on:searchVariedad="variedad = $event" v-on:searchTipo="tipo = $event"
      v-on:orderBy="orderBy = $event" v-on:orderDesc="orderDesc = $event" />
    <UserPrivateZoneBtn v-if="sessionStore.token && !sessionStore.isAdmin" />
    <LogoutBtn v-if="sessionStore.token" />
    <Login />
    <Register />
    <CafeGrid :filtroVariedad="variedad" :filtroTipo="tipo" :filtroOrderBy="orderBy" :filtroOrderDesc="orderDesc" />
  </main>
</template>
