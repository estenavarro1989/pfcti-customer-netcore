# pfcti-customers-core

## Prueba Técnica para PFCTI (.Net Core)

### Stack Tecnológico

* .NET 8.0 SDK 
* PostgreSQL 16.3
* Postman 11.6.1
* Docker 27.1.1
* Visual Studio Code 1.92

### Visual Studio Code Extensions

* [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
* [Rest Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)

### Pasos para ejecutar el proyecto

1. Desde la raíz del proyecto, ejecutar el siguiente comando en consola:

    `docker compose up`

    Al finalizar levantará el postgres con la estructura necesaria en el puerto 5434 y el API de Customers en el puerto 5244

2. Ejecutar las pruebas desde Postman o utilizando la extensión Rest Cliente de VS Code

* Utilizar el archivo Postman-core e importarlo en el programa Postman
* Utilizar el archivo test-customers.http directamente desde VS Code utilizando la extensión Rest Client

### Ejecutar Pruebas Unitarias

1. Ir a directorio de Tests
2. Ejecutar el siguiente comando:

    `dotnet test`

