# Gato Negro

Hola! mi nombre es Braian y me dedico a crear software.

En este proyecto voy a crear un eCommerce y documentar el proceso a través de videos separados en _Sessions_.

Espero que pueda ser util.

----------

## Stack

Por el momento en este repositorio vamos a llevar el control del código fuente correspondiente al backend.

Vamos a construirlo con .net 5 (A.K.A. netcore hasta la version anterior) y algunas librerías que nos facilitaran algunas funciones. Ademas agregamos soporte para Docker para que al momento de poder funcional el mismo nos sea mas fácil.

Base de datos: TBD

Hosting/cloud service: TBD

----------

## Indice

- [Session #1: Arquitectura, Configuración de IDE, DockerFile.](#Session-#1:-Arquitectura,-Configuración-de-IDE,-DockerFile.)
- [Session #2: Session #2: Comunicación de Api con Application usando Mediatr.](#Session-#2:-Comunicación-de-Api-con-Application-usando-Mediatr)




----------


### Session #1: Arquitectura, Configuración de IDE, DockerFile.

Video: https://youtu.be/I7CdBYwgENY

Creamos los distintos proyectos para seguir el arquetipo de [DDD (Domain-Driven Design)](https://es.wikipedia.org/wiki/Dise%C3%B1o_guiado_por_el_dominio). Para facilitar esta tarea [usamos este script](https://gist.github.com/bcariaga/60e2f368ebba86713c99e98d6263103c).

Configuramos algunas tasks de vscode para hacernos mas fácil el desarrollo, _subimos_ la capeta `.vscode` para poder compartir la configuración.

Movemos la clase `Startup.cs` al proyecto `Bootstrap`.

Configuramos `ApplicationKey` apuntando al _assembly_ del proyecto Api, para que detecte los `Controllers`.

Finalmente agregamos el `Dockerfile` solo con el resultado del publish de `Api.csproj, ya que ese es nuestro proyecto de _entrada_.

----------

### Session #2: Comunicación de Api con Application usando Mediatr

Video: https://youtu.be/ofK-2vNYjKg

Implementamos [Mediatr](https://github.com/jbogard/MediatR) para comunicar la capa Api con Aplicación.

Con esta librería desacoplamos ambas capas, ademas a futuro podemos beneficiarnos de otras funcionalidades (behaviors o notifications).

Asi quedaría la comunicación con la implementación:

![uso de mediatr](https://github.com/bcariaga/gato-negro/blob/serie/SE01E02/docs/Mediatr/mediatr.png?raw=true)
