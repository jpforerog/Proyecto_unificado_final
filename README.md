# Sistema de Gestión de Armas y Municiones

## Descripción del Proyecto

Este proyecto implementa una API REST para la gestión de armas y municiones, desarrollada con **Spring Boot 3.4.4** y **Java 17**. El sistema permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre armas tipo rifle y sus municiones asociadas, implementando eliminación lógica para mantener la integridad de los datos históricos.

### Arquitectura del Sistema

La aplicación sigue una arquitectura en capas:
- **Controladores**: Manejan las peticiones HTTP y respuestas
- **Servicios**: Contienen la lógica de negocio
- **Repositorios**: Gestionan el acceso a datos usando Spring Data JPA
- **Modelos**: Definen las entidades del dominio

## Tecnologías Utilizadas

- **Spring Boot 3.4.4**
- **Java 17**
- **Spring Data JPA**
- **Oracle Database** (OJDBC11)
- **Jackson** para serialización JSON
- **Lombok** para reducir código boilerplate
- **Maven** como gestor de dependencias

## Modelo de Datos

### Entidades Principales

#### Arma (Clase Abstracta)
- `id`: Identificador único
- `nombre`: Nombre del arma (único)
- `daño`: Cantidad de daño que inflige
- `municion`: Munición actual
- `vida`: Puntos de vida del arma
- `capMunicion`: Capacidad máxima de munición
- `fechaCreacion`: Timestamp de creación
- `activo`: Flag para eliminación lógica

#### Rifle (Hereda de Arma)
- `velocidad`: Velocidad del rifle
- `tipoMunicion`: Relación con la entidad Munición

#### Municion
- `id`: Identificador único
- `nombre`: Nombre de la munición (único)
- `cadencia`: Cadencia de disparo
- `dañoArea`: Indica si causa daño en área
- `activo`: Flag para eliminación lógica

### Relaciones
- **Rifle ↔ Municion**: Relación Many-to-One (Un rifle usa un tipo de munición)

## Configuración y Ejecución

### Prerrequisitos
- Java 17 o superior
- Maven 3.6+
- Oracle Database (configuración en application.properties)

### Instalación
```bash
git clone https://github.com/jpforerog/Proyecto_unificado_final
cd Servidor/Empresariales_2
./mvnw spring-boot:run
```

### Configuración de Base de Datos
La aplicación está configurada para usar Oracle Database. Asegúrate de configurar los parámetros de conexión en `application.properties`.

## API Endpoints

### Armas Controller (`/Arma`)

#### Endpoints Principales

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/Arma/` | Obtiene todas las armas activas |
| POST | `/Arma/` | Crea una nueva arma |
| PUT | `/Arma/` | Actualiza una arma existente |
| DELETE | `/Arma/` | Elimina (desactiva) una arma |
| GET | `/Arma/healthCheck` | Verificación de estado del servicio |

#### Endpoints de Búsqueda

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| GET/POST | `/Arma/buscar` | Busca arma por ID | `{"id": number}` |
| GET/POST | `/Arma/buscarNombre` | Busca arma por nombre | `{"nombre": "string"}` |
| GET | `/Arma/tipo` | Filtra armas por tipo | `{"tipo": "rifle"}` |
| GET | `/Arma/vida` | Filtra por vida mínima | `{"vida_minima": number}` |
| POST | `/Arma/filtrar` | Filtro combinado | `{"vida_minima": number, "dano_minimo": number}` |

#### Endpoints de Gestión

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/Arma/inactivas` | Lista armas inactivas |
| PUT | `/Arma/reactivar` | Reactiva un arma eliminada |
| GET | `/Arma/estadisticas` | Obtiene estadísticas del sistema |

### Municiones Controller (`/Municion`)

#### Endpoints Principales

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/Municion/` | Obtiene todas las municiones activas |
| POST | `/Municion/` | Crea una nueva munición |
| PUT | `/Municion/` | Actualiza una munición existente |
| DELETE | `/Municion/` | Elimina (desactiva) una munición |

#### Endpoints de Búsqueda

| Método | Endpoint | Descripción | Parámetros |
|--------|----------|-------------|------------|
| GET/POST | `/Municion/buscar/` | Busca munición por ID | `{"id": number}` |
| GET/POST | `/Municion/buscarNombre/` | Busca munición por nombre | `{"nombre": "string"}` |
| POST | `/Municion/filtrarMunicion` | Filtro por criterios | `{"cadencia_minima": number, "danoArea": boolean}` |

#### Endpoints de Gestión

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/Municion/inactivas` | Lista municiones inactivas |
| PUT | `/Municion/reactivar` | Reactiva una munición eliminada |

## Ejemplos de Uso

### Crear una nueva arma
```json
POST /Arma/
{
  "nombre": "AK-47",
  "daño": 35,
  "municion": 30,
  "vida": 100,
  "velocidad": 715.0,
  "fechaCreacion": "2024-01-15T10:30:00",
  "tipoMunicion": {
    "nombre": "7.62x39mm"
  }
}
```

### Crear una nueva munición
```json
POST /Municion/
{
  "nombre": "7.62x39mm",
  "cadencia": 600,
  "danoArea": false
}
```

### Filtrar armas por criterios
```json
POST /Arma/filtrar
{
  "vida_minima": 80,
  "dano_minimo": 30
}
```

## Características Especiales

### Eliminación Lógica
- Las armas y municiones no se eliminan físicamente de la base de datos
- Se utiliza un campo `activo` para marcar elementos como eliminados
- Permite mantener integridad referencial e historial

### Munición Predeterminada
- El sistema crea automáticamente una munición "Predeterminada" al iniciar
- Esta munición no puede ser eliminada
- Se asigna automáticamente a rifles que no especifican tipo de munición

### Gestión de Relaciones
- Al eliminar una munición, todos los rifles que la usan se actualizan automáticamente a la munición predeterminada
- Validaciones para evitar nombres duplicados en elementos activos

### Validaciones de Negocio
- Verificación de campos obligatorios
- Validación de tipos de datos
- Control de duplicados por nombre
- Gestión de estados activo/inactivo

## Clientes de la Aplicación

Este servidor API es consumido por dos aplicaciones cliente:

### Cliente .NET
Aplicación de escritorio desarrollada en .NET que consume los endpoints REST para proporcionar una interfaz de usuario nativa para Windows.

### Cliente React.js
Aplicación web moderna desarrollada en React.js que ofrece una interfaz web para la gestión de armas y municiones.

Ambos clientes se comunican con este servidor a través de las APIs REST documentadas anteriormente.

## Estructura del Proyecto

```
src/main/java/com/ProyectoEmpresariales/Arma/
├── config/          # Configuraciones (DatabaseConfig)
├── controller/      # Controladores REST
├── model/          # Entidades JPA
├── repository/     # Repositorios Spring Data
└── servicios/      # Servicios de negocio
```

## Logging y Monitoreo

- Configuración de logging para conexiones a base de datos
- Health check endpoints para monitoreo
- Manejo de excepciones centralizado

## Cors Configuration

La API está configurada con `@CrossOrigin(origins = "*")` para permitir peticiones desde cualquier origen, facilitando el desarrollo de los clientes web y de escritorio.

---

**Nota**: Este README describe específicamente la funcionalidad del servidor backend. 