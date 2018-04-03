USE [master]
GO

IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL 
DROP TABLE [dbo].[Orders]
GO


IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL 
DROP TABLE [dbo].[Customer]
GO


IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL 
DROP TABLE [dbo].[Product]

IF OBJECT_ID('dbo.TEMP_TABLE', 'U') IS NOT NULL 
DROP TABLE [dbo].[TEMP_TABLE]


CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	CONSTRAINT PK_Customer PRIMARY KEY (Id)

) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[Name] [nvarchar](255) NOT NULL,
	CONSTRAINT PK_Product PRIMARY KEY (Id)
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] VARCHAR(100) NULL
	CONSTRAINT PK_Order PRIMARY KEY (Id),
	CustomerId int FOREIGN KEY REFERENCES Customer(Id),
	ProductId int FOREIGN KEY REFERENCES Product(Id),
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[TEMP_TABLE](
	[CustomerName] [varchar](255) NULL,
	[ProductName] [varchar](255) NULL,
	[Quantity] [int] NULL,
	[DateOfOrder] [varchar](255) NULL
) ON [PRIMARY]
GO


