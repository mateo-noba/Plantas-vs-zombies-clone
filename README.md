# 🌱 Plants vs Zombies (PVZ) Clone

Un clon inspirado en **Plants vs Zombies**, desarrollado como proyecto personal para practicar desarrollo de videojuegos, lógica de gameplay y conexión con una base de datos para guardar puntajes.

El juego incluye mecánicas clásicas como plantar defensas, recolectar soles, atacar con proyectiles, generación de zombies por oleadas y un sistema de puntajes con tabla de clasificación.

---

## 🎮 Características principales

- 🌻 **Sistema de soles** (recolección manual y generación automática).
- 🌱 **Semillero de plantas** con selección por cartas.
- ⏳ **Tiempo de recarga** para cada planta.
- 🧟 **Generación de zombies aleatoria** (spawn dinámico).
- 💥 **Sistema de daño** (guisantes impactan a zombies).
- 🍽️ **Zombies comen plantas** cuando están cerca.
- 🏆 **Sistema de puntaje** (suma puntos al eliminar zombies).
- 🕒 **Tiempo jugado mostrado en pantalla**.
- ⏸️ **Sistema de pausa y menú de derrota**.
- 📊 **Scoreboard** conectado a base de datos.

---

## 🛠️ Tecnologías utilizadas

### 🎮 Desarrollo del Juego
- **Unity (2D)**
- **C#**
- **Unity Physics 2D** (Raycast, Colliders, Triggers)
- **TextMeshPro** (UI y textos en pantalla)
- **Canvas / UI System**
- **Prefabs y Scriptable Objects** (para plantas y cartas)

### 🌐 Página Web / Frontend
- **React**
- **TypeScript**
- **Vite**
- **Fetch API**
- **HTML / CSS**

### 🖥️ Backend / API
- **Node.js**
- **Express.js**
- **MongoDB Atlas**
- **Mongoose**
- **JWT (JSON Web Token)** para autenticación

---

## 📌 Funcionalidades del sistema web

- Registro e inicio de sesión de usuarios
- Guardado de puntajes del jugador
- Obtención de puntajes desde la API
- Tabla de clasificaciones (ScoreBoard)

---

## 📂 Estructura del proyecto

El proyecto se divide en tres partes:

- 🎮 **Juego Unity**: lógica principal del gameplay
- 🌐 **Frontend Web**: página con scoreboard e interfaz
- 🖥️ **Backend API**: servidor con rutas y conexión a MongoDB

---

## ⚙️ Variables de entorno

Ejemplo de `.env` para el backend:

```env
PORT=3000
MONGO_URI=mongodb+srv://usuario:password@cluster.mongodb.net/PVZDB
JWT_SECRET=tu_clave_secreta
VITE_API_URL=http://localhost:3000
```
---

## 📌 Objetivo del proyecto

Este proyecto fue creado con el objetivo de practicar:

- Programación orientada a objetos en **C#**
- Mecánicas de videojuegos **2D en Unity**
- Manejo de UI con **Canvas** y **TextMeshPro**
- Uso de **Raycasts** y **colisiones**
- Consumo de **APIs** desde **React**
- Creación de backend con **Express**
- Persistencia de datos en **MongoDB**
- Autenticación con **JWT**

---

## ⚙️ Instalación del Backend

## 1. Descargar repositorio

Descargar el zip del repositorio desde el boton "<> code"

## 2. Instalar dependencias

```bash
npm install
```

## 3. Crear archivo .env

```env
PORT=3000
MONGO_URI=mongodb+srv://usuario:password@cluster.mongodb.net/PVZDB
JWT_SECRET=tu_clave_secreta
VITE_API_URL=http://localhost:3000
```

## 4. Ejecutar servidor

```bash
npm run nodemon
```

Servidor disponible en:

```
http://localhost:3000/api
```

---

# 🌐 Instalación del Frontend (React)

## 1. Ejecutar proyecto

```bash
npm run dev
```

La aplicación se ejecutará en:

```
http://localhost:5173
```

---

# 🎮 Instalación del Juego (Unity)

## 1. Abrir el proyecto

* Abrir Unity Hub
* Seleccionar "Open Project"
* Elegir la carpeta del juego

## 2. Configurar URL de la API (por si queres cambiar la IP manualmente. Por defecto: localhost)

En el script `APIManager.cs`:
Tenes que cambiar todas manualmente

⚠️ Si usás otro dispositivo, reemplazar `localhost` por la IP local.

---

## 3. Ejecutar el juego

* Presionar Play en Unity
* O hacer build para PC

---

## ⚠️ Consideraciones

* El backend debe estar corriendo antes de usar el juego o la web
* Unity no funciona con `localhost` en dispositivos externos
* Asegurarse de que MongoDB Atlas permita conexiones

---

## 👨‍💻 Autor

Proyecto desarrollado por Mateo Noba como proyecto final de segundo año de una tecnicatura en desarrollo de software. Entregado en las materias: desarrollo de sistemas orientados a objetos (Clon pvz) y programción (Página web).

---

## 📄 Licencia

Uso educativo y demostrativo.
