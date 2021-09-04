# Gato Negro

Hola! mi nombre es Braian y me dedico a crear software.

En este proyecto voy a crear un eCommerce y documentar el proceso a través de videos separados en _Sessions_.

Espero que pueda ser util.

---

## Stack

Por el momento en este repositorio vamos a llevar el control del código fuente correspondiente al backend.

Vamos a construirlo con .net 5 (A.K.A. netcore hasta la version anterior) y algunas librerías que nos facilitaran algunas funciones. Ademas agregamos soporte para Docker para que al momento de poder funcional el mismo nos sea mas fácil.

Base de datos: Mongo DB

Hosting/cloud service: TBD

---

## Indice

- [Session #1: Arquitectura, Configuración de IDE, DockerFile.](#session-1-arquitectura-configuración-de-ide-dockerfile)
- [Session #2: Comunicación de Api con Application usando Mediatr.](#session-2-comunicación-de-api-con-application-usando-mediatr)
- [Session #3: Inyección de Dependencias para IoC con Autofac](#session-3-inyección-de-dependencias-para-ioc-con-autofac)
- [Session #4: Conexión con DB - MongoDB](#conexión-con-db-mongodb)
- [Session #5: Unit Tests - XUnit Moq Bogus](#session-#5-unit-tests-xunit-moq-bogus)
- [Session #5 Bonus Coverage y OpenCover](#session-#5-bonus-coverage-y-opencover)

---

### Session #1: Arquitectura, Configuración de IDE, DockerFile.

Video: https://youtu.be/I7CdBYwgENY

Creamos los distintos proyectos para seguir el arquetipo de [DDD (Domain-Driven Design)](https://es.wikipedia.org/wiki/Dise%C3%B1o_guiado_por_el_dominio). Para facilitar esta tarea [usamos este script](https://gist.github.com/bcariaga/60e2f368ebba86713c99e98d6263103c).

Configuramos algunas tasks de vscode para hacernos mas fácil el desarrollo, _subimos_ la capeta `.vscode` para poder compartir la configuración.

Movemos la clase `Startup.cs` al proyecto `Bootstrap`.

Configuramos `ApplicationKey` apuntando al _assembly_ del proyecto Api, para que detecte los `Controllers`.

Finalmente agregamos el `Dockerfile` solo con el resultado del publish de `Api.csproj, ya que ese es nuestro proyecto de _entrada_.

---

### Session #2: Comunicación de Api con Application usando Mediatr

Video: https://youtu.be/ofK-2vNYjKg

Implementamos [Mediatr](https://github.com/jbogard/MediatR) para comunicar la capa Api con Aplicación.

Con esta librería desacoplamos ambas capas, ademas a futuro podemos beneficiarnos de otras funcionalidades (behaviors o notifications).

Asi quedaría la comunicación con la implementación:

![uso de mediatr](https://github.com/bcariaga/gato-negro/blob/serie/SE01E02/docs/Mediatr/mediatr.png?raw=true)

---

### Session #3: Inyección de Dependencias para IoC con Autofac

Video: https://youtu.be/q0kUTI3yWt4

Usamos [Autofac](https://autofac.org/) para resolver las dependencias de los distintos colaboradores dentro del proyecto.

Aplicar DI (Dependency injection) es una manera de lograr la Inversión del Control (IoC).
Como principal ventaja obtenemos un código **desacoplado**, fácilmente _testable_ y reutilizable.

![DI](https://github.com/bcariaga/gato-negro/blob/serie/SE01E03/docs/IoC/IoC.png?raw=true)

---

### Session #4: Conexión con DB - MongoDB

Video: https://youtu.be/I8tn7ETECGo

Usamos [MongoDb.Driver](https://www.nuget.org/packages/mongodb.driver) para conectarnos a un Mongo db y recuperar datos. Ademas de filtrarlos por nombre agregamos un paginado y orden de documentos.

Como implementamos esta conexión:

![MongoDb en Gato Negro](https://github.com/bcariaga/gato-negro/blob/serie/SE01E04/docs/Services-Repositories/Infrastructure.png?raw=true)

**_Nota_** usamos esta config de `docker-compose` para levantar el servicio de MongoDb: https://github.com/bcariaga/mongodb-docker-seed

### Session #5: Unit Tests - XUnit Moq Bogus

Video: https://youtu.be/7myjSHLe8rE

Usamos XUnit para crear pruebas de unidad (Unit Test) y mos apoyamos en [Moq](https://github.com/moq/moq4) para crear objetos que nos permitan "simular" el comportamiento de nuestros _colaboradores_ a traves de su interfaz.

Ademas usamos [Bogus](https://github.com/bchavez/Bogus) para crear datos _fake_.

### Session #5 Bonus Coverage y OpenCover

Con [OpenCover](https://github.com/OpenCover/opencover) generamos un reporte html para analizar el **Code Coverge** de nuestro proyecto.
