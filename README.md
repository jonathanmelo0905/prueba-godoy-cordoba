# 🐱 Cat GIF App – Prueba Técnica .NET + Angular

Aplicación web fullstack que consume dos APIs públicas ([Cat Facts](https://catfact.ninja/fact) y [Giphy](https://developers.giphy.com)) y muestra resultados visuales en una interfaz moderna.  
Toda la lógica pasa por un backend propio en **.NET**, el cual también **almacena el historial de búsquedas en MySQL**.

---

## 📁 Estructura del Proyecto

```
.
├── frontend/             # Proyecto Angular
│   └── cat-gif-app/      # Código fuente del frontend
│
├── backend/              # Proyecto ASP.NET Core Web API
│   └── CatGifBackend/    # Código fuente del backend
│
└── README.md             # Instrucciones generales (este archivo)
```

---

## 🚀 Instrucciones de Ejecución

### 🖥️ Frontend – Angular

1. Ir al directorio del frontend:

```bash
cd frontend/cat-gif-app
```

2. Instalar dependencias:

```bash
npm install
```

3. Ejecutar la aplicación:

```bash
npm run start
```

4. Abrir navegador en:

```
http://localhost:4200
```

> ⚠️ Asegúrate de que `src/environments/environment.ts` contenga la URL del backend:
```ts
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7135/api' // puede variar dependiendo del backend
};
```

---

### ⚙️ Backend – ASP.NET Core Web API

1. Ir al directorio del backend:

```bash
cd backend/CatGifBackend
```

2. Restaurar dependencias y ejecutar:

```bash
dotnet restore
dotnet run
```

3. La API estará disponible en:

```
https://localhost:7135
```

Puedes probar los endpoints con herramientas como **Postman**, **Insomnia**, o **curl**.

---

## 🛠️ Configuración de Base de Datos – MySQL

La aplicación utiliza **MySQL** como motor de base de datos.

📍 La cadena de conexión está en:  
`backend/CatGifBackend/appsettings.json`

Ejemplo:
```json
"ConnectionStrings": {
  "basedatos": "Server=localhost;Database=catgif;User Id=root;Password=1234;"
}
```

---

## 🛠️ Creación Automática de la Base de Datos

Esta aplicación está preparada para crear automáticamente la base de datos y la tabla `historial_catgif` si aún no existen, gracias a `EnsureCreated()`.

### 📌 ¿Qué debes hacer?

1. Verifica que tengas **MySQL Server** instalado localmente.
2. Crea una base de datos vacía en tu servidor MySQL (por ejemplo: `catgif`).
3. Ajusta tu cadena de conexión en `appsettings.json` con tu usuario y contraseña.
4. La base de datos se creará automáticamente al ejecutar el backend, gracias a esta línea en `Program.cs`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatGifContext>();
    db.Database.EnsureCreated(); // Crea la BD si no existe
}
```
## ✅ Funcionalidades

- Obtener un **Cat Fact aleatorio** desde API externa.
- Buscar un **GIF en Giphy** usando las primeras 3 palabras del fact.
- Refrescar el GIF sin cambiar el texto.
- Guardar en base de datos:
  - Fecha
  - Texto completo
  - Palabras usadas como query
  - URL del GIF
- Visualizar historial de búsquedas en una pestaña independiente.

---

## 🧱 Tecnologías Usadas

- **Frontend:** Angular 14, Angular Material, RxJS
- **Backend:** ASP.NET Core Web API
- **Base de datos:** MySQL
- **Estilo:** CSS personalizado + Angular Material

---

## 👨‍💻 Autor

**Jonathan Melo**  
[GitHub – jonathanmelo0905](https://github.com/jonathanmelo0905)
