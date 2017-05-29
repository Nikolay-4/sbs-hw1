
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2017 22:09:51
-- Generated from EDMX file: C:\Users\Admin\test\sbs-hw1\sbs_hw1\sbs_hw1\GameStatsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\ADMIN\DOCUMENTS\STATSDB.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StatsSet'
CREATE TABLE [dbo].[StatsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [result] nvarchar(max)  NOT NULL,
    [userSteps] int  NOT NULL,
    [userSign] nvarchar(max)  NOT NULL,
    [date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StatsSet'
ALTER TABLE [dbo].[StatsSet]
ADD CONSTRAINT [PK_StatsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------