
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/01/2018 22:21:48
-- Generated from EDMX file: C:\Users\Ataberk\source\repos\EFComparison\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[TestModelStoreContainer].[Kullanıcılar]', 'U') IS NOT NULL
    DROP TABLE [TestModelStoreContainer].[Kullanıcılar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kullanıcılar'
CREATE TABLE [dbo].[Kullanıcılar] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Surname] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id], [Name], [Surname] in table 'Kullanıcılar'
ALTER TABLE [dbo].[Kullanıcılar]
ADD CONSTRAINT [PK_Kullanıcılar]
    PRIMARY KEY CLUSTERED ([Id], [Name], [Surname] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------