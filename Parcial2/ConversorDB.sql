-- Crear la base de datos 
CREATE DATABASE ConversorDB;
GO

-- Usar la base de datos
USE ConversorDB;
GO

CREATE TABLE HistorialConversiones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoConversion NVARCHAR(50),
    ValorEntrada FLOAT,
    ValorSalida FLOAT,
    Fecha DATETIME DEFAULT GETDATE()
);

SELECT * FROM HistorialConversiones;