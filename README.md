"# AN-N6A_TEC-Clase3"

## Branches:
- master: código en el cual estaremos trabajando las siguientes clases
- start: punto de partida para configurar EF

## EF Core
   Add EF Core   https://docs.microsoft.com/en-us/ef/core/index     

Nos ubicamos a nivel de la carpeta del proyecto CityInfo.API

```
	 dotnet add package Microsoft.EntityFrameworkCore	 
```

### DbContext

El puente entre nuestro dominio y la base de datos.
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/working-with-dbcontext

(si bien la definición esta dentro de la sección para ef6, sigue siendo útil)

En nuestro caso ya tenemos definida [CityInfoContext](https://github.com/ORT-DA2/AN-N6A_TEC-Clase3/blob/start/CityInfo.API/Entities/CityInfoContext.cs) que extiende de DBContext

Luego generamos una migration (snapshot del código que vimos)
```
	 dotnet ef migrations add migrationName
```

No podemos generar dos migrations con el mismo nombre, por lo tanto **migrationName** debe ser distinto cada vez que generemos una.

```
	 dotnet ef database update
```

Ahora si, tenemos una base. Anteriormente con migrations, lo que obtenemos son las instrucciones para generar el esquema de la base.

```
select * from __EFMigrationsHistory
```
EF utiliza esta tabla al momento de ejecutar el update database. Necesita saber cuales migrations no se han aplicado aún a la base existente.

### TDD con Moq

[MOQ quick start](https://github.com/Moq/moq4/wiki/Quickstart)

En el proyecto de test
```
dotnet add package Moq
```

```
dotnet watch test
``` 

[Unit test Microsoft Doc](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest?view=aspnetcore-2.1)


Microsoft.AspNetCore.Mvc.Abstractions 
```
dotnet add package Microsoft.AspNetCore.Mvc.Abstractions
```

Microsoft.AspNetCore.Mvc.Core
```
dotnet add package Microsoft.AspNetCore.Mvc.Core
```

