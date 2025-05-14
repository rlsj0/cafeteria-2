import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import { jwtDecode } from 'jwt-decode'

export const useSessionStore = defineStore('session', () => {

  const email = ref('');
  const password = ref('');
  // Usamos las variables reactivas para actualizar si hay cambios
  const token = ref(sessionStorage.getItem('authToken') || "");
  const isAdmin = ref(sessionStorage.getItem('isAdmin') === "true");

  // Almacenamos el token con la clave 'authToken'
  function setToken(newToken: string) {
    sessionStorage.setItem('authToken', newToken);
    token.value = newToken;

    // Aprovechamos a guardar si es admin
    try {
      const decodedToken = jwtDecode(newToken);
      isAdmin.value = decodedToken.role === "admin";
      // console.log(isAdmin.value);

      sessionStorage.setItem('isAdmin', isAdmin.value.toString());
    }
    catch (ex) {
      console.log("Error al guardar el token: " + ex.message)
      isAdmin.value = false;
      sessionStorage.removeItem('isAdmin');
    }
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

    // TODO: es necesario meter lo esta parte en un try catch y tal
    // (no se debería intentar set el token si falla)

    // El token no es json sino texto plano
    const newToken = await response.text();
    // console.log('Token: ' + newToken);
    // const decoded = jwtDecode(newToken);
    // console.log('Decodificado: ', decoded);

    setToken(newToken);
  }

  function logout() {
    isAdmin.value = false;
    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('isAdmin');
    token.value = "";
    email.value = "";
    password.value = "";
    console.log('Sesión cerrada');
  }

  function estaLogueado() {
    if (sessionStorage.getItem('authToken') != null) {
      return true
    } else {
      return false
    }
  }

  function esAdmin() {
    if (sessionStorage.getItem('isAdmin') === 'true')
      return true
    else
      return false
  }

  return {
    email,
    password,
    getToken,
    login,
    logout,
    isAdmin,
    token,
    estaLogueado,
    esAdmin,
  }
});
