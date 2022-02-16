USE [ShoeShop]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 2022-02-16 22:21:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_customer_id] [int] NULL,
	[order_date] [datetime] NULL,
	[order_shipper_id] [int] NULL,
	[order_payment_id] [int] NULL,
	[total_price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK1_Order] FOREIGN KEY([order_customer_id])
REFERENCES [dbo].[Customer] ([id])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK1_Order]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK2_Order] FOREIGN KEY([order_shipper_id])
REFERENCES [dbo].[Shipper] ([id])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK2_Order]
GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK3_Order] FOREIGN KEY([order_payment_id])
REFERENCES [dbo].[Payment] ([id])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK3_Order]
GO

