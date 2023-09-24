

CREATE TABLE [dbo].[Products](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 4) NULL,
	[Date_Added] [datetime2](7) NULL,
	[Date_Modified] [datetime2](7) NULL,
	[Description] [nvarchar](max) NULL,
	[QuantityPerUnit] [int] NULL,
	[Date_Removed] [datetime2](7) NULL,
	[Category_id] [int] NOT NULL,
	[Subcategory_id] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_Category_id] FOREIGN KEY([Category_id])
REFERENCES [dbo].[Categories] ([Category_Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_Category_id]
GO

ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Subcategories_Subcategory_id] FOREIGN KEY([Subcategory_id])
REFERENCES [dbo].[Subcategories] ([Subcategory_Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Subcategories_Subcategory_id]
GO


