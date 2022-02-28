[E-Carvajal Store][API]:convenience_store: — Proyecto para especialista de desarollo 
==================================================

![Google Chrome](https://img.shields.io/badge/Google%20Chrome-4285F4?style=for-the-badge&logo=GoogleChrome&logoColor=white)
![Firefox](https://img.shields.io/badge/Firefox-FF7139?style=for-the-badge&logo=Firefox-Browser&logoColor=white)
![Safari](https://img.shields.io/badge/Safari-000000?style=for-the-badge&logo=Safari&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?style=for-the-badge&logo=redis&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)




General :computer:
--------------------------------------

E-Carvajal store [API]  es un proyecto desarollado en c# en el marco de trabajo NET 5 en arquitectura de Clean Architecture / Microservicios . a Este proyecto le fue modificado su metodo principal para Despliegue e intregacion continua. 


### Bases de datos :file_folder:

E-Carvajal store [API] implementa CodeFirst + Repository Pattern lo que permite manipular diferentes bases motores de bases de datos.

1)Sql Server [Relationa]

2)Redis [Key,Value]

### Aquitectura

Con el fin de exponer arquitecturas altamente escalable se emplea una combinacion de las siguiente arquitecturas para la administracion de una solución de 10 proyectos

1)Clean Architecture
2)Microservices


![arquitectura_back](https://firebasestorage.googleapis.com/v0/b/storeapp-c5f8a.appspot.com/o/repo%2Farquitectura.gif?alt=media&token=ea3f5fc2-e825-4756-9377-752a902a27e3)


### Patrones de Diseño

En pro de cumplir con el objetivo de mantener las mejores practicas de desarollo se implementan los siguientes patrones de diseño:

1)Repositoy Pattern

2)Chain Responsability Pattern

3)CQRS Pattern

4)Event Sourcing Pattern

5)Singleton Pattern ( Redis)


##Implementacion

Para implementar el proyecto es necesario instalar ambiente de SQL SERVER , REDIS . Para este caso se usuaron las siguientes imagenes de docker 

1) https://hub.docker.com/_/microsoft-mssql-server

2) https://hub.docker.com/_/redis

### Ejecución

Para ejecutar el proyecto se debe configurar las cadenas de ejecución a las 3 bases de datos ,ejecutar el proyecto, el se encarga de crear las bases de datos e insertar los datos semilla



![_firebaseback](https://firebasestorage.googleapis.com/v0/b/storeapp-c5f8a.appspot.com/o/repo%2Fstrings.gif?alt=media&token=f181750a-75bd-4be8-8aff-712c927406c5)
