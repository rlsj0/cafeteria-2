import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useSessionStore = defineStore('session', () => {

  const email = ref('');
  const password = ref('');

  // Almacenamos el token con la clave 'authToken'
  function setToken(newToken: string) {
    sessionStorage.setItem('authToken', newToken);
  }

  // Accedemos al store con la clave authToken
  const getToken = () => {
    sessionStorage.getItem('authToken');
  }

  async function login() {
    console.log('Email: ' + email.value);
    console.log('Contrasena: ' + password.value);
    const user = { correo: email.value, contrasena: password.value }

    const response = await fetch('http://localhost:8023/Auth/Login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(user),
    })

    // TODO: verificar si la respuesta es Ok o no:
    // Puede ser fallo al verificar el usuario (usuario o contraseña incorrectos), o puede ser
    // fallo que la contraseña es muy corta o el correo no es un correo.
    // El Token me llega como texto plano. El error como un json.
    // if(!response.ok)...

    // El token no es json sino texto plano
    const newToken = await response.text();
    console.log('Token: ' + newToken);

    setToken(newToken);
  }

  return {
    email,
    password,
    getToken,
    login,
  }
});
