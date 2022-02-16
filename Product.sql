USE [ShoeShop]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 2022-02-16 22:23:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [varchar](50) NULL,
	[product_category_id] [int] NULL,
	[product_price] [decimal](18, 0) NULL,
	[product_info] [varchar](255) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Product] UNIQUE NONCLUSTERED 
(
	[product_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product] FOREIGN KEY([product_category_id])
REFERENCES [dbo].[Category] ([id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product]
GO

