<template>
  <div>
    <!-- Usamos .prevent para prevenir que se recargue -->
    <form @submit.prevent="register">
      <div>
        <label for="email">Email</label>
        <input type="email" id="email" v-model="email" required />
      </div>

      <div>
        <label for="password">Contraseña</label>
        <input type="password" id="password" v-model="password" required />
      </div>

      <button type="submit">Registrarse</button>
    </form>
  </div>
</template>

<script setup lang="ts">

import { ref, onMounted } from 'vue';

const email = ref('');
const password = ref('');

class User {
  constructor(email, password) {
    this.correo = email;
    this.contrasena = password;
  }
}

function register() {
  console.log(email.value);
  console.log(password.value);
  console.log(JSON.stringify(new User(email.value, password.value)));

  fetch('http://localhost:8023/Auth/Register', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(new User(email.value, password.value))
  })
    .then(async response => {
      // TODO: verificar si la respuesta es Ok o no
      // Puede ser fallo al verificar el usuario (usuario o contraseña incorrectos), o puede ser
      // fallo que la contraseña es muy corta o el correo no es un correo.
      // El Token me llega como texto plano. El error como un json.
      // TODO: ojo porque si ya hay un usuario con ese correo me está llegando como string, pero si
      // estoy enviando una contraseña muy corta me está llegando como token.
      const token = await response.text();
      // TODO: guardarlo
      console.log('Token: ' + token);
    })
}

</script>

<style></style>
