﻿-- craear la base de datos CRMDB
CREATE DATABASE CRMDB
GO

-- UTILIZAR LA BASE DE DATOS
USE CRMDB
GO

-- CREAR LA TABLA CUSTOMERS (ANTERIORMENTE CLIENTS)

CREATE TABLE Customers
(
id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
Address VARCHAR (255)
)
GO
