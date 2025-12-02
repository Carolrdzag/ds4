-- 1. Crear la base de datos
CREATE DATABASE CarolinaRodriguez;
GO

USE CarolinaRodriguez;
GO

CREATE TABLE CR_Respuestas (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Pregunta NVARCHAR(500) NOT NULL,
    Respuesta NVARCHAR(MAX) NOT NULL
);
GO

-- Preguntas y Respuestas --

INSERT INTO CR_Respuestas (Pregunta, Respuesta)
VALUES 
('¿Cómo resolverías estos problemas con una solución tecnológica?', 'Implementaría un sistema de gestión de casos legales que centralice toda la información del bufete. Este sistema permitiría organizar clientes, abogados, documentos, citas y el estado de cada caso. También incluiría recordatorios automáticos y control de tareas para evitar retrasos. Con esta solución, el bufete mejoraría su organización y la atención al cliente.'),
('¿Qué pasos seguirías para desarrollar el sistema?', 'Primero levantaría los requerimientos con el personal del bufete para entender sus procesos. Luego diseñaría la base de datos y las interfaces. Después desarrollaría los módulos principales en C# conectados a SQL Server. Finalmente realizaría pruebas, capacitaría a los usuarios y pondría el sistema en producción.'),
('¿Qué estructura tendría la base de datos?', 'La base de datos tendría tablas para Clientes, Abogados, Casos, Documentos y Citas. Cada tabla estaría relacionada mediante claves foráneas, permitiendo identificar quién atiende un caso, qué documentos pertenecen a cada expediente y cuándo ocurren las citas. Esta estructura facilita el control completo del proceso legal.'),
('¿Por qué elegiste la estructura? Ventajas y desventajas', 'Elegí una estructura relacional porque permite organizar la información de forma clara y evitar duplicados. Su mayor ventaja es que facilita consultas eficientes y garantiza integridad entre los datos. Como desventaja, requiere planificación adecuada y puede ser más estricta cuando los procesos del bufete cambian.'),
('¿Qué interfaz gráfica utilizarías?', 'Utilizaría una interfaz sencilla y ordenada, basada en Web Forms con controles estándar y estilos de Bootstrap. Esto permite crear pantallas limpias, fáciles de navegar y compatibles con dispositivos modernos. Además, facilita el acceso rápido a casos, clientes y citas sin complicar al usuario.');

SELECT * FROM CR_Respuestas;
    

UPDATE CR_Respuestas
SET Respuesta = 'Primero levantaría los requerimientos con el personal del bufete para entender sus procesos. Luego diseñaría la base de datos y las interfaces. Después desarrollaría los módulos principales en C# conectados a SQL Server. Finalmente realizaría pruebas, capacitaría a los usuarios y pondría el sistema en producción.'
WHERE ID = 2;

UPDATE CR_Respuestas
SET Respuesta = 'La base de datos tendría tablas para Clientes, Abogados, Casos, Documentos y Citas. Cada tabla estaría relacionada mediante claves foráneas, permitiendo identificar quién atiende un caso, qué documentos pertenecen a cada expediente y cuándo ocurren las citas. Esta estructura facilita el control completo del proceso legal.'
WHERE ID = 3;

UPDATE CR_Respuestas
SET Respuesta = 'Elegí una estructura relacional porque permite organizar la información de forma clara y evitar duplicados. Su mayor ventaja es que facilita consultas eficientes y garantiza integridad entre los datos. Como desventaja, requiere planificación adecuada y puede ser más estricta cuando los procesos del bufete cambian.'
WHERE ID = 4;

UPDATE CR_Respuestas
SET Respuesta = 'Utilizaría una interfaz sencilla y ordenada, basada en Web Forms con controles estándar y estilos de Bootstrap. Esto permite crear pantallas limpias, fáciles de navegar y compatibles con dispositivos modernos. Además, facilita el acceso rápido a casos, clientes y citas sin complicar al usuario.'
WHERE ID = 5;