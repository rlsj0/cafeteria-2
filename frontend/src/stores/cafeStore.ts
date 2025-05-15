import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useCafeStore = defineStore('cafe', () => {
  const cafes = ref([]);

  // // const variedad = ref('');
  // const tipo = ref('');
  // const orderBy = ref('');
  // const orderDesc = ref('');
  //
  const filtros = ref({
    Variedad: '',
    Tipo: '',
    OrderBy: '',
    Desc: ''
  });

  async function fetchCafes() {
    const url = new URL('http://localhost:8023/Cafe');

    for (const [clave, valor] of Object.entries(filtros.value)) {
      if (valor != null && valor != '') {
        url.searchParams.set(clave, valor);
      } else {
        url.searchParams.delete(clave);
      }
    }

    const response = await fetch(url);
    const data = await response.json();
    cafes.value = await data;
  }

  return {
    cafes,
    filtros,
    fetchCafes
  }
});

