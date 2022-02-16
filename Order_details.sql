USE [ShoeShop]
GO

/****** Object:  Table [dbo].[Order_details]    Script Date: 2022-02-16 22:21:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order_details](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Order_details] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order_details]  WITH CHECK ADD  CONSTRAINT [FK1_Order_details] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([id])
GO

ALTER TABLE [dbo].[Order_details] CHECK CONSTRAINT [FK1_Order_details]
GO

ALTER TABLE [dbo].[Order_details]  WITH CHECK ADD  CONSTRAINT [FK2_Order_details] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO

ALTER TABLE [dbo].[Order_details] CHECK CONSTRAINT [FK2_Order_details]
GO

