/* ==========================================================================
   Examen 1 - Aplicaciones Web Avanzadas (ISWDBL3)
   Estudiante : Costa Erick
   Aplicación : Recetas de cocina
   Motor      : Microsoft SQL Server 2017 o superior
   Requisito  : autenticación "SQL Server y Windows" (modo mixto)
   ========================================================================== */

USE master;
GO

-- 1. Login del servidor
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'CostaErickEx1')
    CREATE LOGIN CostaErickEx1 WITH PASSWORD = 'CostaErickEx1', CHECK_POLICY = OFF;
GO

-- 2. Base de datos (si ya existe se recrea)
IF DB_ID('BDD_RecetasCocina') IS NOT NULL
BEGIN
    ALTER DATABASE BDD_RecetasCocina SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BDD_RecetasCocina;
END
GO
CREATE DATABASE BDD_RecetasCocina;
GO

USE BDD_RecetasCocina;
GO

-- 3. Usuario mapeado al login, miembro de db_owner
CREATE USER CostaErickEx1 FOR LOGIN CostaErickEx1;
ALTER ROLE db_owner ADD MEMBER CostaErickEx1;
GO

-- 4. Tabla
CREATE TABLE Receta
(
    RecetaId             INT IDENTITY(1,1) NOT NULL,
    Nombre               NVARCHAR(100)     NOT NULL,
    PaisOrigen           NVARCHAR(60)      NOT NULL,
    Ingredientes         NVARCHAR(500)     NOT NULL,
    TiempoPreparacion    INT               NOT NULL,   -- minutos
    Vegetariana          BIT               NOT NULL,   -- 1 = sí, 0 = no
    CONSTRAINT PK_Receta PRIMARY KEY (RecetaId),
    CONSTRAINT CK_Receta_Tiempo CHECK (TiempoPreparacion > 0)
);
GO

-- 5. Datos de prueba
INSERT INTO Receta (Nombre, PaisOrigen, Ingredientes, TiempoPreparacion, Vegetariana) VALUES
(N'Locro de papa',      N'Ecuador',  N'Papa, queso fresco, leche, cebolla, achiote, aguacate', 45, 1),
(N'Ceviche de pescado', N'Perú',     N'Corvina, limón, cebolla morada, ají, cilantro, camote', 30, 0),
(N'Tacos al pastor',    N'México',   N'Carne de cerdo, piña, chile guajillo, tortillas de maíz', 90, 0),
(N'Pizza margarita',    N'Italia',   N'Harina, levadura, salsa de tomate, mozzarella, albahaca', 60, 1),
(N'Tortilla española',  N'España',   N'Huevos, papas, cebolla, aceite de oliva, sal', 40, 1);
GO

SELECT * FROM Receta;
GO
