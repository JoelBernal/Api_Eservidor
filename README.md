Comanditos

Descargar .Net 6.0 https://dotnet.microsoft.com/es-es/download/dotnet/6.0

-Iniciar el programa y que esté disponible en el localhost- dotnet run

-Link del localhost pa que no tengas que hacer nada puto vago- https://localhost:7222/swagger/index.html

-Checkear que el código está bien- dotnet build

Para el entity: -Iniciar el Docker -En terminal siendo administrador:

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Mandangon123" -p 1434:1433 -d mcr.microsoft.com/mssql/server:2022-latest

Migraciones:

dotnet tool install --global dotnet-ef --> herramientas para entity framework

dotnet ef migrations add nombreMigracion --> para añadir la migracion

dotnet ef database update --> para subir la base de datos
