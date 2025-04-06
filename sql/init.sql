-- Criação do banco de dados se não existir
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'LifeTrackDB')
BEGIN
    CREATE DATABASE LifeTrackDB;
END
GO

-- Usar o banco
USE LifeTrackDB;
GO

-- Tabela TransactionStatus
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TransactionStatus' AND xtype='U')
BEGIN
    CREATE TABLE TransactionStatus (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL
    );
END
GO

-- Tabela TransactionType
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TransactionType' AND xtype='U')
BEGIN
    CREATE TABLE TransactionType (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL
    );
END
GO

-- Tabela TransactionCategory
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TransactionCategory' AND xtype='U')
BEGIN
    CREATE TABLE TransactionCategory (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL,
        TypeId INT NOT NULL,
        FOREIGN KEY (TypeId) REFERENCES TransactionType(Id)
    );
END
GO

-- Tabela Transaction
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Transaction' AND xtype='U')
BEGIN
    CREATE TABLE [Transaction] (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Description NVARCHAR(255) NOT NULL,
        CategoryId INT NOT NULL,
        Value DECIMAL(18, 2) NOT NULL,
        StatusId INT NOT NULL,
        TransactionDate DATE NOT NULL,
        FOREIGN KEY (CategoryId) REFERENCES TransactionCategory(Id),
        FOREIGN KEY (StatusId) REFERENCES TransactionStatus(Id)
    );
END
GO

-- Seed para TransactionStatus
IF NOT EXISTS (SELECT 1 FROM TransactionStatus WHERE Name = 'Ativo')
BEGIN
    INSERT INTO TransactionStatus (Name) VALUES ('Ativo');
END

IF NOT EXISTS (SELECT 1 FROM TransactionStatus WHERE Name = 'Inativo')
BEGIN
    INSERT INTO TransactionStatus (Name) VALUES ('Inativo');
END
GO

-- Seed para TransactionType
IF NOT EXISTS (SELECT 1 FROM TransactionType WHERE Name = 'Entrada')
BEGIN
    INSERT INTO TransactionType (Name) VALUES ('Entrada');
END

IF NOT EXISTS (SELECT 1 FROM TransactionType WHERE Name = 'Saída')
BEGIN
    INSERT INTO TransactionType (Name) VALUES ('Saída');
END
GO

-- Seed para TransactionCategory

-- Saída
IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Saúde')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Saúde', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Transporte')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Transporte', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Alimentação')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Alimentação', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Moradia')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Moradia', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Higiene pessoal')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Higiene pessoal', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Presentes')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Presentes', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Educação')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Educação', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Gastos comigo')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Gastos comigo', Id FROM TransactionType WHERE Name = 'Saída';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Entretenimento')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Entretenimento', Id FROM TransactionType WHERE Name = 'Saída';
END

IF EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Investimentos')
BEGIN
    UPDATE TransactionCategory
    SET TypeId = (SELECT Id FROM TransactionType WHERE Name = 'Saída')
    WHERE Name = 'Investimentos';
END
ELSE
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Investimentos', Id FROM TransactionType WHERE Name = 'Saída';
END

-- Entrada
IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Salário')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Salário', Id FROM TransactionType WHERE Name = 'Entrada';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Retorno investimentos')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Retorno investimentos', Id FROM TransactionType WHERE Name = 'Entrada';
END

IF NOT EXISTS (SELECT 1 FROM TransactionCategory WHERE Name = 'Benefícios')
BEGIN
    INSERT INTO TransactionCategory (Name, TypeId)
    SELECT 'Benefícios', Id FROM TransactionType WHERE Name = 'Entrada';
END
GO
