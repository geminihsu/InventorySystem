
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2017 12:01:58
-- Generated from EDMX file: C:\Users\gemini\source\repos\InventorySample\InventorySample\Entities\SampleDBContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sample];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Item_history]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Item_history];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[SampleModelStoreContainer].[Item_transcation_inventory]', 'U') IS NOT NULL
    DROP TABLE [SampleModelStoreContainer].[Item_transcation_inventory];
GO
IF OBJECT_ID(N'[SampleModelStoreContainer].[Model]', 'U') IS NOT NULL
    DROP TABLE [SampleModelStoreContainer].[Model];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Item_history'
CREATE TABLE [dbo].[Item_history] (
    [Seq] int  NOT NULL,
    [SN] varchar(16)  NOT NULL,
    [Location] varchar(3)  NOT NULL,
    [DateIn] datetime  NOT NULL,
    [DateOut] datetime  NOT NULL,
    [SaleOrderNo] varchar(50)  NULL,
    [TrakingNo] varchar(20)  NULL,
    [ModelNo] varchar(6)  NOT NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Code] varchar(3)  NOT NULL,
    [ZoneCode] smallint  NULL
);
GO

-- Creating table 'Models'
CREATE TABLE [dbo].[Models] (
    [MODELNO] varchar(6)  NOT NULL,
    [VERSION] int  NOT NULL,
    [FG] nvarchar(255)  NULL,
    [MODEL1] nvarchar(255)  NULL,
    [SOLE] bit  NULL,
    [DESC] nvarchar(255)  NULL,
    [FP_DATE] datetime  NULL,
    [LABOR_W] bit  NULL,
    [SNBegin] int  NULL,
    [SNEnd] int  NULL,
    [ViewFile] varbinary(max)  NULL,
    [SPFile] varbinary(max)  NULL,
    [Commercial] bit  NULL,
    [Brand] nvarchar(50)  NULL,
    [MinQuantity] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'FGItemIns'
CREATE TABLE [dbo].[FGItemIns] (
    [Seq] int  NOT NULL,
    [SN] varchar(16)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [Location] nchar(3)  NOT NULL,
    [ModelNo] nchar(6)  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory1'
CREATE TABLE [dbo].[C__MigrationHistory1] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Item_transcation_inventory'
CREATE TABLE [dbo].[Item_transcation_inventory] (
    [Seq] int  NOT NULL,
    [SN] varchar(16)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Location] nchar(3)  NOT NULL,
    [ModelNo] nchar(6)  NOT NULL
);
GO

-- Creating table 'Model1'
CREATE TABLE [dbo].[Model1] (
    [MODELNO] varchar(6)  NOT NULL,
    [VERSION] int  NOT NULL,
    [FG] nvarchar(255)  NULL,
    [MODEL1] nvarchar(255)  NULL,
    [SOLE] bit  NULL,
    [DESC] nvarchar(255)  NULL,
    [FP_DATE] datetime  NULL,
    [LABOR_W] bit  NULL,
    [SNBegin] int  NULL,
    [SNEnd] int  NULL,
    [ViewFile] varbinary(max)  NULL,
    [SPFile] varbinary(max)  NULL,
    [Commercial] bit  NULL,
    [Brand] nvarchar(50)  NULL,
    [MinQuantity] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Seq], [SN] in table 'Item_history'
ALTER TABLE [dbo].[Item_history]
ADD CONSTRAINT [PK_Item_history]
    PRIMARY KEY CLUSTERED ([Seq], [SN] ASC);
GO

-- Creating primary key on [Code] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [MODELNO] in table 'Models'
ALTER TABLE [dbo].[Models]
ADD CONSTRAINT [PK_Models]
    PRIMARY KEY CLUSTERED ([MODELNO] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Seq] in table 'FGItemIns'
ALTER TABLE [dbo].[FGItemIns]
ADD CONSTRAINT [PK_FGItemIns]
    PRIMARY KEY CLUSTERED ([Seq] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory1'
ALTER TABLE [dbo].[C__MigrationHistory1]
ADD CONSTRAINT [PK_C__MigrationHistory1]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Seq], [SN], [Date], [Location], [ModelNo] in table 'Item_transcation_inventory'
ALTER TABLE [dbo].[Item_transcation_inventory]
ADD CONSTRAINT [PK_Item_transcation_inventory]
    PRIMARY KEY CLUSTERED ([Seq], [SN], [Date], [Location], [ModelNo] ASC);
GO

-- Creating primary key on [MODELNO], [VERSION] in table 'Model1'
ALTER TABLE [dbo].[Model1]
ADD CONSTRAINT [PK_Model1]
    PRIMARY KEY CLUSTERED ([MODELNO], [VERSION] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Location] in table 'Item_history'
ALTER TABLE [dbo].[Item_history]
ADD CONSTRAINT [FK_Item_history_Location]
    FOREIGN KEY ([Location])
    REFERENCES [dbo].[Locations]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_history_Location'
CREATE INDEX [IX_FK_Item_history_Location]
ON [dbo].[Item_history]
    ([Location]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------