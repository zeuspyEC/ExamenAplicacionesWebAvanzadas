# Recetas de Cocina · Examen 1

Aplicaciones Web Avanzadas (ISWDBL3) · Costa Erick

Aplicación web para registrar y consultar recetas de cocina: id, nombre, país de origen, ingredientes,
tiempo de preparación (minutos) y si es vegetariana.

| | |
|---|---|
| Presentación | ASP.NET Web Forms (C#) |
| Arquitectura | N-Layer: Presentación → Lógica de negocio → Acceso a datos → SQL Server, con entidades compartidas |
| Framework | .NET Framework 2.0 en todos los proyectos |
| Base de datos | SQL Server 2017 o superior · BDD_RecetasCocina · login y usuario CostaErickEx1 (db_owner) |

## Estructura

```
BaseDatos/Costa.Erick.Ex1.sql                 Login, base de datos, usuario, tabla Receta e inserts
Costa.Erick.Ex1.sln                           Solución (4 proyectos, uno por capa)
Costa.Erick.Ex1.Entidades/Receta.cs           Entidad que viaja entre capas
Costa.Erick.Ex1.AccesoDatos/RecetaDAL.cs      CRUD con ADO.NET y consultas parametrizadas
Costa.Erick.Ex1.LogicaNegocio/RecetaBL.cs     Validaciones antes de guardar
Costa.Erick.Ex1/Default.aspx                  Read (tabla) y Delete
Costa.Erick.Ex1/RecetaFormulario.aspx         Create y Update
Costa.Erick.Ex1/Web.config                    Cadena de conexión
```

## Ejecución

1. SQL Server con autenticación **SQL Server y Windows** (modo mixto).
2. Ejecutar `BaseDatos/Costa.Erick.Ex1.sql` en SQL Server Management Studio.
3. Abrir `Costa.Erick.Ex1.sln` en Visual Studio y ejecutar con IIS Express (F5).
