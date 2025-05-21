# cafeteria-2

Página web en Vue3 que consume una API de Dotnet. Se trata de una
cafetería virtual, en la que los usuarios pueden buscar los distintos
productos según varios campos y se pueden dar de alta y hacer pedidos,
o ver sus pedidos ya hechos. El admin puede ver todos los usuarios y
los pedidos, y crear y modificar productos (_esto último no
implementado en la web pero sí en la API_).

## Requisitos del frontend

### Obligatorios

- [X] Deben existir 3 pantallas distintas, cada una con su vista, ruta
  y componentes
    - HomeView, AdminView y UserView
- [X] Debe existir una gestión centralizada del estado
    - Petición inicial de Cafés a backend. También gestión de los
      filtros.
    - Persistimos los usuarios y pedidos creados en el backend. 
    - Al menos 3 operaciones sobre backend:
        - GET cafes (`/Cafe`)
        - GET all pedidos (`/Pedido`)
        - POST pedido (`/Pedido`)
        - GET pedidos de usuario (`/Usuario/{id}/pedidos`)
        - Login user
        - Register user
- [X] Deben existir componentes para las partes específicas
    - [X] Header
    - [X] Footer
    - [X] Vistas
- [X] Vistas compuestas por componentes, con menor lógica posible
- [X] Maquetación con vuetify

### Opcionales

- [X] (2 pto) Implementación de login y autenticación
- [X] (1 pto) Roles de administrador y usuario
- [X] (1 pto) Buscador

## Requisitos del backend

### Obligatorios

- [X] API RESTful, CRUD y HTTP
    - [X] Gestión de alta y tratamiento de usuarios y productos
    - [X] Zona privada de información
    - [X] Zona pública de información (admin y usuario)
- [X] Modelo de datos con ORM
    - [X] Al menos 3 clases con 6 atributos
    - [X] Acceso con ORM (EF Core)
- [X] Búsqueda para zona privada y pública. Filtrar y ordenar
- [X] Autenticación con JWT
- [X] Contenerizar

### Opcionales

- [X] Git y gitflow
- [X] Estrategia Code First
- [ ] Consume la API en Web Contenerizada (_en proceso_)
- [ ] Despliegue mediante CI/CD (Github Actions) (_en proceso_)

