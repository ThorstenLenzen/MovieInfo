﻿CREATE TABLE [dbo].[Actor]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
	[Key] VARCHAR(50) NOT NULL,
    [FirstName] VARCHAR(50) NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Bio] VARCHAR(4000) NULL,
)
