USE [ShoeShop]
GO

/****** Object:  Table [dbo].[Shipper]    Script Date: 2022-02-16 22:23:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shipper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shipper_name] [varchar](50) NULL,
	[freight_price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Shipper] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

