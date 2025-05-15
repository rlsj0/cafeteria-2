<template>
  <v-container>
    <v-row>
      <v-col cols="12" sm="6">
        <v-text-field label="Variedad" type="search" v-model="variedad" @input="$emit('searchVariedad', variedad)"
          clearable />
      </v-col>

      <v-col cols="12" sm="6">
        <v-text-field label="Tipo" type="search" v-model="tipo" @input="$emit('searchTipo', tipo)" clearable />
      </v-col>
    </v-row>

    <v-row>
      <v-col cols="12" sm="6">
        <p>Ordenar por:</p>
        <v-radio-group v-model="orderBy" @change="$emit('orderBy', orderBy)" row>
          <v-radio label="Id" value="id" />
          <v-radio label="Precio" value="precio" />
        </v-radio-group>
      </v-col>

      <v-col cols="12" sm="6">
        <p>Orden:</p>
        <v-radio-group v-model="orderDesc" @change="$emit('orderDesc', orderDesc)" row>
          <v-radio label="Descendente" value="true" />
          <v-radio label="Ascendente" value="false" />
        </v-radio-group>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">

import { ref, defineEmits } from 'vue';

const emit = defineEmits(['searchVariedad', 'searchTipo', 'orderBy', 'orderDesc']);

const variedad = ref('');
const tipo = ref('');
const orderBy = ref('id');
const orderDesc = ref('false');

</script>

<style></style>
