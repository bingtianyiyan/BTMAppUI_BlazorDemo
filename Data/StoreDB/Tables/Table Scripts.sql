
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'BTMDatabase')
BEGIN
    CREATE DATABASE BTMDatabase;
END;


USE BTMDatabase
Go

/* Product TABLE */
DROP TABLE IF EXISTS [dbo].[Products];
GO
CREATE TABLE [dbo].[Products](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 4) NULL,
	[Date_Added] [datetime2](7) NULL,
	[Date_Modified] [datetime2](7) NULL,
	[Description] [nvarchar](max) NULL,
	[QuantityPerUnit] [int] NULL,
	[Date_Removed] [datetime2](7) NULL
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/* Product Images TABLE */
/****** Object:  Table [dbo].[ProductImages]    Script Date: 9/30/2023 3:51:40 PM ******/
DROP TABLE IF EXISTS [dbo].[ProductImages];
GO
CREATE TABLE [dbo].[ProductImages](
	[Image_Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[File_Name] [nvarchar](150) NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Image_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/* Users TABLE */
/****** Object:  Table [dbo].[Users]    Script Date: 9/30/2023 4:53:33 PM ******/
DROP TABLE IF EXISTS [dbo].[Users];
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Role] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- [MonthlyReportAuditLog]
DROP TABLE IF EXISTS [dbo].[MonthlyReportAuditLog];
GO
CREATE TABLE [dbo].[MonthlyReportAuditLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime] NULL,
	[MessageLog] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--CREATE ADMIN USER
IF NOT EXISTS (SELECT 1 FROM Users WHERE username = 'admin')
	BEGIN
	INSERT INTO dbo.Users(Username, Password, Role) VALUES ('admin','admin','Administrator')
	END
ELSE	
	RAISERROR('User already exists.', 0, 1) WITH NOWAIT;
