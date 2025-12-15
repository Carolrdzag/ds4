-- Creación de la base de datos --
CREATE DATABASE AgendaDB;
GO

USE AgendaDB;
GO

-- Creación de la tabla --
CREATE TABLE Contactos (
    Id INT IDENTITY(1,1) PRIMARY KEY,   
    Nombre NVARCHAR(100) NOT NULL,     
    Telefono NVARCHAR(20) NOT NULL,     
    Correo NVARCHAR(100) NOT NULL,      
    FechaRegistro DATETIME DEFAULT GETDATE()  
);
GO

-- Verificar contenido de la tabla --
SELECT * FROM Contactos;
GO
