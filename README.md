# Api_Eservidor

Comanditos

Descargar .Net 6.0
https://dotnet.microsoft.com/es-es/download/dotnet/6.0

-Iniciar el programa y que esté disponible en el localhost-
dotnet run 

-Link del localhost pa que no tengas que hacer nada puto vago-
https://localhost:7222/swagger/index.html

-Checkear que el código está bien-
dotnet build

Para el entity:
-Iniciar el Docker 
-En terminal siendo administrador:

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Mandangon123" -p 1434:1433 -d mcr.microsoft.com/mssql/server:2022-latest

Migraciones:

dotnet tool install --global dotnet-ef --> herramientas para entity framework

dotnet ef migrations add nombreMigracion --> para añadir la migracion

dotnet ef database update --> para subir la base de datos


---------------------------------------------------------------------------------------------------------------------------------------------------------------

Subir la Api a Azure

Nos metemos a https://portal.azure.com/#home
Nos metemos el servicio Web App
Creamos un Resource Group nuevo
Le damos el nombre que queramos, (va a ser la url publica del proyecto)
En publish selecciona code
En Runtime Stack ponemos lo que hemos usado para hacerlo .NET 6.0
Operating System Windows
Región pon la más cercana a ser posible
Windows Plan: Por Defecto
Pricing Plan: Free F1

MENÚ DEPLOYMENT 
Continuous Deployment: Enable
Metemos nuestra cuenta de Github
Elegimos el repositorio y la rama que queremos subir 

MENÚ NETWORKING
Por defecto

Monitoring
E nable Application Insights : NO

YA PUEDES CREARLO, CREALO 

TODO ESTO NOS HABRÁ CREADO UNA CARPETA CON UN FICHERO EN EL REPO DENTRO DE LA RAMA SELECCIONADA

ALTAMENTE PROBABLE QUE HAYA UN PROBLEMA DE COMPATIBILIDAD CON EL FICHERO NUEVO
--> Se mira dentro del repo en la Sección Actions

VAMOS A TENER QUE SOLUCIONAR ESTO EDITANDO EL FICHERO
-- Hay que señalar en el fichero la ruta exacta en la que se encuentra el .csproj

