# Recetas de Cocina · Examen 1

Aplicaciones Web Avanzadas (ISWDBL3) · Costa Erick

Aplicación web para registrar y consultar recetas de cocina: id, nombre, país de origen, ingredientes,
tiempo de preparación (minutos) y si es vegetariana.

| | |
|---|---|
| Presentación | ASP.NET Web Forms (C#) |
| Arquitectura | N-Layer: Presentación → Lógica de negocio → Acceso a datos → SQL Server, con entidades compartidas |
| Framework | .NET Framework 2.0 en todos los proyectos (ASP.NET 2.0) |
| Base de datos | Microsoft SQL Server 2017 o superior |

## Estructura

```
BaseDatos/Costa.Erick.Ex1.sql         Login, base de datos, usuario db_owner, tablas e inserts
Costa.Erick.Ex1.sln                   Solución de Visual Studio
Costa.Erick.Ex1.Entidades/            Capa de entidades (objetos que viajan entre capas)
Costa.Erick.Ex1.AccesoDatos/          Capa de acceso a datos (ADO.NET, consultas parametrizadas)
Costa.Erick.Ex1.LogicaNegocio/        Capa de lógica de negocio (validaciones y reglas)
Costa.Erick.Ex1/                      Capa de presentación (ASP.NET Web Forms)
```

## Ejecución

1. SQL Server debe aceptar autenticación **SQL Server y Windows** (modo mixto).
2. Ejecutar `BaseDatos/Costa.Erick.Ex1.sql` en SQL Server Management Studio.
3. Abrir `Costa.Erick.Ex1.sln` en Visual Studio y ejecutar con IIS Express (F5).
