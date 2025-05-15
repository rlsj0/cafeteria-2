<script setup lang="ts">
import CafeGrid from '../components/CafeGrid.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
import SearchbarCafe from '../components/SearchbarCafe.vue'
import UserPrivateZoneBtn from '../components/UserPrivateZoneBtn.vue'
import AdminPrivateZoneBtn from '../components/AdminPrivateZoneBtn.vue'
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
  <div>
    <h1 class="text-h2">Home</h1>
    <v-row justify="space-between" align="stretch" class="my-4">
      <v-col>
        <Login v-if="!sessionStore.token" />
      </v-col>
      <v-col>
        <Register v-if="!sessionStore.token" />
      </v-col>
    </v-row>
    <SearchbarCafe v-on:searchVariedad="variedad = $event" v-on:searchTipo="tipo = $event"
      v-on:orderBy="orderBy = $event" v-on:orderDesc="orderDesc = $event" />
    <CafeGrid :filtroVariedad="variedad" :filtroTipo="tipo" :filtroOrderBy="orderBy" :filtroOrderDesc="orderDesc" />
  </div>
</template>
