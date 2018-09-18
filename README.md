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

### Aclaración calse de hoy

cometi un error al mostrar como ejemplo, intentar hacer un mock de una clase que hereda de dbContext, como es el caso de CityInfoContext. Son tantas las dependencias que en inviable para moq generar un mock por eso existe el fake EF Core in memory.

[Testing with InMemory](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory)

Aclarado ese punto, subo en master los unit test que estuvimos haciendo con ICityService,

Recodar:

* mock.Setup -> Podemos definir el comportamiento necesario para generar el caso de prueba, inlcuso que dispare una exception.

* mockBehavior ->
por defecto Loose, nos permite obtener sin configuración que va intentar devolvre default cuando es invocado.
Strict -> nos exige que todo metodo y/o property que va ser invocada por la unidad bajo test, debe tener un comportamiento definido. En caso contrario el unit test falla.



```
            var mock = new Mock<ICityService>(MockBehavior.Strict);
            mock.Setup(m => m.GetCities(It.IsAny<string>()))
            .Returns(new List<City> { new City(), new City() });

            var sut = new CitiesController(mock.Object);
            var inputValue = "randomValue since it expect any string value, even null";

            var response = sut.GetCities(inputValue);

            mock.Verify(m => m.GetCities(inputValue), Times.Once);

            var result = response as OkObjectResult;
            var model = result.Value as List<City>;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, model.Count);
```
