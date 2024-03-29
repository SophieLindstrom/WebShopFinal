USE [ShoeShop]
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([id], [payment_name]) VALUES (1, N'Swish')
INSERT [dbo].[Payment] ([id], [payment_name]) VALUES (2, N'VISA')
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1, N'Testiana', N'Testsson', N'testgatan', N'12639', N'Testholm', N'Testland', N'7012345', N'test@test.test', 1, 17)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (2, N'Sophie', N'Lindstrom', N'vägen 11', NULL, NULL, NULL, NULL, N'sophie.lindstrom@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1002, N'Mats', N'Mårtensson', N'Östen undens gata 144', NULL, NULL, NULL, NULL, N'grappe@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1004, N'Anna', N'Andersson', N'Hallonvagen 11', NULL, NULL, NULL, NULL, N'anna.andersson@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1006, N'Hanna', N'Hansson', N'Testgatan', NULL, NULL, NULL, NULL, N'hanna.hansson@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1007, N'Anna', N'Berglund', N'Storgatan', N'22230', N'Lund', N'Sverige', N'0705828347', N'annaberglund@gmail.com', 1, 35)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1008, N'Erik', N'Hansson', N'Lillgatan', N'11349', N'Stockholm', N'Sverige', N'070435647', N'erik.hansson@gmail.com', 0, 55)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1009, N'Henning', N'Karlsson', N'Kängevägen', N'12634', N'Stockholm', N'Sverige', N'0705828123', N'karlsson@gmail.com', 0, 21)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1010, N'Johanna', N'Lundberg', N'Lundagatan', N'12644', N'Stockholm', N'Sverige', N'0725828437', N'jojjobanan@gmail.com', 1, 32)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1011, N'Carmen', N'Mendoza', N'Åsögatan', N'13245', N'Stockholm', N'Sverige', N'0735844447', N'carmen@gmail.com', 1, 44)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1012, N'Lukas', N'Lejon', N'Lejongatan', N'23456', N'Göteborg', N'Sverige', N'0705834247', N'lejonmannen@gmail.com', 0, 18)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1013, N'Jenny', N'Dyews', N'Toffelbacken', N'12936', N'Hägersten', N'Sverige', N'0705828388', N'jennydyews@gmail.com', 1, 35)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1014, N'Sophie', N'Lindgren', N'Hägerstensvägen', N'12649', N'Hägersten', N'Sverige', N'0705828683', N'sophie.lindgren@gmail.com', 1, 31)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1015, N'Josef', N'Fares', N'Aspvägen', N'23450', N'Skövde', N'Sverige', N'0705408347', N'josef@gmail.com', 0, 78)
INSERT [dbo].[Customer] ([id], [first_name], [last_name], [adress], [zip_code], [city], [country], [phone_number], [email_adress], [gender], [age]) VALUES (1016, N'Teo', N'Fredriksson', N'Grangatan', N'14329', N'Stockholm', N'Sverige', N'0735845747', N'teo@gmail.com', 0, 26)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Shipper] ON 

INSERT [dbo].[Shipper] ([id], [shipper_name], [freight_price]) VALUES (1, N'DHL', CAST(49 AS Decimal(18, 0)))
INSERT [dbo].[Shipper] ([id], [shipper_name], [freight_price]) VALUES (2, N'PostNord', CAST(59 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Shipper] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (1, 2, CAST(N'2022-02-13T19:27:24.510' AS DateTime), 1, 1, CAST(472 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (2, 1002, CAST(N'2022-02-14T23:20:00.990' AS DateTime), 2, 1, CAST(9542 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (3, 1004, CAST(N'2022-02-15T00:12:21.523' AS DateTime), 2, 1, CAST(7593 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (4, 1004, CAST(N'2022-02-15T00:22:08.447' AS DateTime), 1, 2, CAST(3095 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (5, 1006, CAST(N'2022-02-15T00:30:32.727' AS DateTime), 1, 1, CAST(848 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (6, 1015, CAST(N'2022-02-15T12:38:52.950' AS DateTime), 1, 2, CAST(2948 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (7, 1014, CAST(N'2022-02-15T13:25:17.843' AS DateTime), 1, 1, CAST(1847 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (8, 1013, CAST(N'2022-02-15T14:28:19.183' AS DateTime), 1, 2, CAST(2447 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (9, 1012, CAST(N'2022-02-15T14:30:54.613' AS DateTime), 1, 2, CAST(2447 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (10, 1012, CAST(N'2022-02-15T14:32:45.467' AS DateTime), 1, 2, CAST(2447 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (11, 1013, CAST(N'2022-02-15T14:41:19.720' AS DateTime), 1, 1, CAST(798 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (12, 1015, CAST(N'2022-02-15T14:43:32.147' AS DateTime), 1, 1, CAST(1544 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (13, 1011, CAST(N'2022-02-15T14:55:14.517' AS DateTime), 1, 1, CAST(1948 AS Decimal(18, 0)))
INSERT [dbo].[Order] ([id], [order_customer_id], [order_date], [order_shipper_id], [order_payment_id], [total_price]) VALUES (14, 1011, CAST(N'2022-02-15T15:00:01.533' AS DateTime), 1, 2, CAST(472 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [category_name]) VALUES (1, N'Sneakers')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (2, N'Wintershoes')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (3, N'Sandals')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (4, N'Boots')
INSERT [dbo].[Category] ([id], [category_name]) VALUES (5, N'Slippers')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (1, N'Nike Air Max 90', 1, CAST(1495 AS Decimal(18, 0)), N'One of the most popular Air Max sneakers of all-time, the Nike Air Max 90 was originally released in 1990.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (2, N'Adidas Superstar', 1, CAST(1199 AS Decimal(18, 0)), N'The adidas Superstar is a low-top basketball shoe that first released in 1969.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (3, N'Puma Smash', 1, CAST(423 AS Decimal(18, 0)), N'Tennis inspired silhouette features and soft suede upper with a smooth fit.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (4, N'Converse All Star', 1, CAST(749 AS Decimal(18, 0)), N'Most iconic sneaker in the world, that was initially developed as a basketball shoe in the early 20th century.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (5, N'Vans Old Skool', 1, CAST(649 AS Decimal(18, 0)), N'Originally a skate shoe, constructed with durable suede and canvas uppers in a range of fresh colorways.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (6, N'Timberland Premium', 2, CAST(1399 AS Decimal(18, 0)), N'A water proof hiking boot, perfect for the nordic winter conditions.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (7, N'Moon boot ICON', 2, CAST(1495 AS Decimal(18, 0)), N'A water proof fashion boot with great fit, perfect for the all kinds of weather.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (8, N'Dr Martens Serena', 2, CAST(2599 AS Decimal(18, 0)), N'Iconic shoes, originally from the UK. Lined shoes, that keep you warm during the winter.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (9, N'Inuikii classic', 2, CAST(2499 AS Decimal(18, 0)), N'Make a personal statement by wearing this cool winterboot, surface in leather och waterproof suede')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (10, N'Tretorn Apollo Hybrid', 2, CAST(1200 AS Decimal(18, 0)), N'Apollo Hybrid is an urban premium boot with a surface in vegan and waterproof suede, inner lining in a warming and cozy pile and decorative shoelaces.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (11, N'Birkenstock', 3, CAST(899 AS Decimal(18, 0)), N'Sandals of the highest quality, designed and produced with a focus on details.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (12, N'Vagabond Erin', 3, CAST(799 AS Decimal(18, 0)), N'Sandal Erin is an updated version of the classic sports sandal with trend-proof details such as a higher sole and wide straps with Velcro.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (13, N'ECCO Ofroad', 3, CAST(819 AS Decimal(18, 0)), N'Lightweight and equally strong supportive sandals that provide ultimate running comfort every day, in and out of terrain.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (14, N'Scholl Rio', 3, CAST(854 AS Decimal(18, 0)), N'Sandals with ergonomic soles with support in the hollow foot and at the toes that provide stability and better posture.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (15, N'Monki Slingback', 3, CAST(300 AS Decimal(18, 0)), N'A pair of adjustable slingback sandals with straps made from recycled micro suede. Featuring a 4 cm statement sole of layered cork, twine and rubber. ')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (16, N'Dr Martens 2976 Chelsea Black', 4, CAST(1899 AS Decimal(18, 0)), N'Dr Martens Chelsea is perfect for you who want unique and durable shoes that give you a well-dressed look.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (17, N'Kavat Moda EP Reddish brown', 4, CAST(2000 AS Decimal(18, 0)), N'Moda is a tough and stylish boot with an urban look. It is made of environmentally friendly and chrome-free leather of European origin.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (18, N'Vagabond Kenova Chelseaboots', 4, CAST(1099 AS Decimal(18, 0)), N'Classic chelsea boots with robust sole. Made of black leather with ankle-high shaft.The strong sole and rough heel give a modern look.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (19, N'Shepard Sanna Outdoor Brown', 4, CAST(1499 AS Decimal(18, 0)), N'Classic and stylish shoe. The shoes have two large loops at the top of the shaft, which makes it easier for you to put on the shoes.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (20, N'Bianco Biadeb Laced Up Boot', 4, CAST(599 AS Decimal(18, 0)), N'Soft leather with a high shaft and high sole. Lacing at the front and zipper on the inside of the shaft. ')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (21, N'Shepherd Moa Asphalt', 5, CAST(799 AS Decimal(18, 0)), N'Soft and warming slippers in 100% sheepskin. Ankle-high model with a wide sheepskin collar and a decorative edging in textile at the front.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (22, N'Rhode', 5, CAST(499 AS Decimal(18, 0)), N'Classic design with buckles in gold that allows you to adjust the to your rapids shape for optimal comfort and fit.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (23, N'Bullboxer', 5, CAST(399 AS Decimal(18, 0)), N'Warm slippers with low ankle and very nice comfort.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (24, N'Muji', 5, CAST(199 AS Decimal(18, 0)), N'Soft light foot pads. Flexible for extra comfort.')
INSERT [dbo].[Product] ([id], [product_name], [product_category_id], [product_price], [product_info]) VALUES (25, N'Kasti Studios', 5, CAST(1800 AS Decimal(18, 0)), N'All-round slipper in leather, calfskin lining and rubber sole. A model that can be used indoors but also outdoors. ')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (1, 3, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (2, 1, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (2, 9, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (3, 1, 3)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (3, 7, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (4, 5, 3)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (4, 18, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (5, 12, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (6, 18, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (6, 25, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (7, 11, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (8, 2, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (9, 2, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (10, 2, 2)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (11, 4, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (12, 1, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (13, 16, 1)
INSERT [dbo].[Order_details] ([order_id], [product_id], [quantity]) VALUES (14, 3, 1)
GO
