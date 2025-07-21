# Proyecto: Autenticación PlacetoPay (Backend C#)

Este proyecto implementa la lógica de autenticación para consumir los servicios de la API de PlacetoPay. Está diseñado para ejecutarse localmente como parte de una prueba técnica o simulación de integración.

---

## 🔐 Endpoint de autenticación

Este endpoint es el **punto de entrada obligatorio** para iniciar cualquier operación contra la API de PlacetoPay.

Forma parte de un **proyecto backend en C# que debe estar corriendo localmente**, el cual simula la lógica real de autenticación que normalmente se implementaría del lado del servidor en producción.

---

### 🔧 ¿Qué hace?

Genera todos los datos necesarios para autenticarse correctamente ante PlacetoPay. La respuesta incluye:

| Campo           | Descripción                                                                 |
|------------------|------------------------------------------------------------------------------|
| `transactionKey` | Hash generado con `SHA256(nonce + seed + secretKey)`, luego codificado en Base64. |
| `nonce`          | Valor aleatorio único por transacción, codificado en Base64.               |
| `seed`           | Fecha y hora actual en formato ISO 8601.                                   |
| `expiration`     | Tiempo de expiración de la sesión (actual + 10 minutos).                   |
| `reference`      | Referencia única y dinámica para la transacción.                           |
| `amount`         | Valor total de la transacción, recibido como parámetro vía query.          |

---

### 📥 Query Params

| Param       | Descripción                                                       |
|-------------|-------------------------------------------------------------------|
| `secretKey` | Clave privada del sitio para firmar la autenticación (`tranKey`). |
| `amount`    | Valor monetario que se desea pagar (por ejemplo: `50`, `100`).    |

---

### 🚀 Ejemplo de uso

```http
GET https://localhost:44345/TransactionKey?secretKey=TU_SECRET_KEY&amount=100
