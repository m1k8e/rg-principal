Hola, los proyectos fueron creados como lo solicitaron con la versión de .Net core 7.0

En la solución del ejercicio práctico adjunté algunas buenas practicas como:
- Pruebas unitarias (un ejemplo basico con el patrón AAA, por temas personales no alcancé a implementar de otras clases, sin embargo al usar interfaces es facilmente testeable)
- inyección de dependencias
- Reglas de negocio.
- patrón repositorio para la capa de acceso a datos
- patrón unidad de trabajo para evitar redundancia de código en acceso a datos
- Interfaces para garantizar responsabilidad única
- nombramiento adecuado de parametros y variables. 
- Manejo de retorno de codigos http en respuestas.
- Hubiese querido poder alcanzar adjuntar un middleware para control de excepciones unificado.

Porfavor restaurar la base de datos para poder probar.

Dejo un body de ejemplo para crear una orden:

{
  "customer": "Mike",
  "products": [
    {
      "idProduct": 1,
      "quantity": 1
    },
    {
      "idProduct": 4,
      "quantity": 1
    },
    {
      "idProduct": 5,
      "quantity": 1
    }
  ]
}