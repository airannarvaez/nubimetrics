# Nubimetrics

Se compone de una Solucion llamada Nubimetrics con dos proyectos de ejecucion
1. Nubimetrics.WebApi (WebApi Net 6)
2. Nubimetrics.ETL (Worker Net 6)


El proyecto de WebApi tiene Entity Framework con migraciones que incluye la carga de datos inicial en la tabla 'Users'.
Para su funcionamiento se requiere que se corra la migracion posterior a colocar los datos de acceso a la base de datos (MySQL) en el archivo appsettings.json.

Para ejecutar la migracion correr el comando desde la raiz de la Solucion:
``dotnet ef database update --project Nubimetrics.Repositories --startup-project Nubimetrics.WebApi``

El proyecto de Worker tiene datos configurables como la ubicacion de las descargas, frecuencia en la que se quiere correr el servicio (los archivos usan por nombre la fecha y hora de la generacion).

El resto de proyectos son librerias comunes para las dos aplicaciones, para mostrar el uso del Patron Repositorio, Patron de Unit Of Work.