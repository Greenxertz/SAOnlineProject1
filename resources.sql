USE [aspnet-SAOnlineProject1-7e70178c-44d9-4661-baa2-3885d54e7888]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (15, N'Electronics')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (16, N'Clothes')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (17, N'Food')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (18, N'Furniture')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (19, N'Glassware')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (29, N'Samsung s2', 400, N'utilized for calls', 15, N'482791c4-2adf-4ed7-837e-44589f121488_43737554_62d19afa-c3da-4e97-8ae3-85e6fe33b25e.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (30, N'Sushi', 20, N'Raw fish in a delish way', 17, N'94a6a933-e1f1-4c6a-909c-e8a5793242db_625Wx625H-recipe-40.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (31, N'LazyChair', 600, N'The LazyChair has two sitting positions: reclining position and upright position and it also folds up for storage and is practically maintenance free. ', 18, N'cf67b30d-2268-4d4c-accf-d3ec32b7a6bf_21175104_1439503796097256_1138125616_n.webp')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (32, N'Mens TS ', 134, N'Everyday V-Neck Black Tee', 16, N'63d4f561-f920-4d5b-bcf6-d89ec15ed401_157251447-1200-1600.webp')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (33, N'Boys Stripe Crew T-Shirt', 160, N'Buy 2 kids'' t-shirts for R99 each.', 16, N'8ea91aa5-cf8c-4d93-805d-f11333a4c062_157091349-1200-1600.webp')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (34, N'Apple iPhone 15 Pro Max (1 TB) ', 999, N'- Black Titanium', 15, N'6e8814da-b6e7-438f-8d67-02531ac7966e_iphone-15-pro-finish-select-202309-6-7inch-blacktitanium.webp')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (35, N'Pizza', 20, N'Tasty!', 17, N'f62aa5af-a753-4bcb-9a9f-c8f57c18649c_images (1).jpeg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (36, N'Sealy Paloma 152cm (Queen) Firm Bed Set', 999, N'Support Top
10 Year Warranty
Dual Spring System
Comfort layers', 18, N'3f15390b-cf0c-4211-9c2b-a8e8fe8d4ea1_10127427_sealy_paloma_152cm_bs_ecommerce_81d0.png')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (37, N'Bohemia Cristal No. 1 Wine Glass 6-Piece Set', 200, N'Fancy', 19, N'f4756c00-236e-4fef-96d3-bb7f832bd67f_57515486_1-zoom.jpg')
INSERT [dbo].[Products] ([Id], [Name], [Price], [Description], [CategoryId], [HomeImgUrl]) VALUES (38, N'Antique hlass green wine glas', 600, N'Wine glass, green with trumpet bowl and knopped stem. Pontil scar to underside of foot. English c1830. 

Bowl dia: 6.7 cm.

Foot dia:  6.5 cm. 

Condition Very good. ', 19, N'106d8589-238c-4806-ba5b-457f80402d39_antique-hlass-green-wine-glass-english-c1830_11849_pic4_size2.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[PImages] ON 

INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (99, 29, N'482791c4-2adf-4ed7-837e-44589f121488_43737554_62d19afa-c3da-4e97-8ae3-85e6fe33b25e.jpg', N'Samsung s2')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (100, 29, N'4104b675-3c8a-415e-ac67-c1153c7d4d10_download.jpeg', N'Samsung s2')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (101, 29, N'91baa524-76cb-41a7-9d8b-1550aea3e0ea_africa-en_GT-I9100LKJXFA_001_Front_black.avif', N'Samsung s2')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (102, 30, N'94a6a933-e1f1-4c6a-909c-e8a5793242db_625Wx625H-recipe-40.jpg', N'Sushi')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (103, 30, N'5414b211-2c5d-43d5-b086-9a6480c061a3_Maki-zushi.webp', N'Sushi')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (104, 30, N'7d653fe7-d35a-422a-9ff2-bf1329287b25_19511smoked-salmon-sushi-rollfabeveryday4x3-159a22b4d3ac49fe9a146db94b53c930.jpg', N'Sushi')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (105, 31, N'cf67b30d-2268-4d4c-accf-d3ec32b7a6bf_21175104_1439503796097256_1138125616_n.webp', N'LazyChair')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (106, 31, N'bc348805-07a3-4154-ab0a-80698c4b9f4a_21175147_1439502442764058_1721888692_n.webp', N'LazyChair')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (107, 31, N'a5076e8f-1f1d-40cf-a974-f8a0bedcdca2_pilt3-560x500.webp', N'LazyChair')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (109, 32, N'e6ee59e6-b19e-4d1b-a650-774faa8ad842_157251455-1200-1600.webp', N'Mens TS ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (110, 32, N'63d4f561-f920-4d5b-bcf6-d89ec15ed401_157251447-1200-1600.webp', N'Mens TS ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (112, 33, N'c01ba9d6-a54c-4911-b168-82b758f31283_157091355-1200-1600.webp', N'Boys Stripe Crew T-Shirt')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (113, 33, N'8ea91aa5-cf8c-4d93-805d-f11333a4c062_157091349-1200-1600.webp', N'Boys Stripe Crew T-Shirt')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (114, 32, N'cfeaf468-c626-4f74-b8d9-ff2ef7abf7a2_157251462-1200-1600.webp', N'Mens TS ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (115, 33, N'61e4efae-5c50-46cd-97ed-f851c9515fb5_157091362-1200-1600.webp', N'Boys Stripe Crew T-Shirt')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (119, 34, N'6e8814da-b6e7-438f-8d67-02531ac7966e_iphone-15-pro-finish-select-202309-6-7inch-blacktitanium.webp', N'Apple iPhone 15 Pro Max (1 TB) ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (120, 34, N'ecbfa1f8-bd41-4e50-86ad-b0d74d9152b7_iphone-15-pro-finish-select-202309-6-7inch-blacktitanium_AV2.webp', N'Apple iPhone 15 Pro Max (1 TB) ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (121, 34, N'169a7640-4dd3-4d36-ad59-55fa79ae44db_iphone-15-pro-finish-select-202309-6-7inch-blacktitanium_AV3.webp', N'Apple iPhone 15 Pro Max (1 TB) ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (122, 34, N'ec3e8b9e-e329-4ea6-bdcc-c03140df65b6_iphone-15-pro-finish-select-202309-6-7inch-blacktitanium_AV1_GEO_US.webp', N'Apple iPhone 15 Pro Max (1 TB) ')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (123, 35, N'f62aa5af-a753-4bcb-9a9f-c8f57c18649c_images (1).jpeg', N'Pizza')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (124, 35, N'832e4358-c481-4488-ac76-5633b41f1a3a_images.jpeg', N'Pizza')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (125, 35, N'7c52fec3-41e2-4a85-a3cc-de6d5c7859e6_classic-cheese-pizza-FT-RECIPE0422-31a2c938fc2546c9a07b7011658cfd05.jpg', N'Pizza')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (126, 36, N'3f15390b-cf0c-4211-9c2b-a8e8fe8d4ea1_10127427_sealy_paloma_152cm_bs_ecommerce_81d0.png', N'Sealy Paloma 152cm (Queen) Firm Bed Set')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (127, 36, N'9c2dcfe5-7a11-4d30-9598-99d0b9855bf3_paloma_fab_ecommerce_44da.png', N'Sealy Paloma 152cm (Queen) Firm Bed Set')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (128, 37, N'f4756c00-236e-4fef-96d3-bb7f832bd67f_57515486_1-zoom.jpg', N'Bohemia Cristal No. 1 Wine Glass 6-Piece Set')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (129, 37, N'2f120c57-ffb7-4977-a751-c9f1949656e6_57515486_2A-zoom.jpg', N'Bohemia Cristal No. 1 Wine Glass 6-Piece Set')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (130, 38, N'106d8589-238c-4806-ba5b-457f80402d39_antique-hlass-green-wine-glass-english-c1830_11849_pic4_size2.jpg', N'Antique hlass green wine glas')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (131, 38, N'84d71312-7ee1-4715-8cc1-06b6770dc201_antique-hlass-green-wine-glass-english-c1830_11849_pic2_size2.jpg', N'Antique hlass green wine glas')
INSERT [dbo].[PImages] ([Id], [ProductId], [ImageUrl], [ProductName]) VALUES (132, 38, N'cd2e7cff-0797-47ac-91b7-134773ca91b0_antique-hlass-green-wine-glass-english-c1830_11849_main_size3.jpg', N'Antique hlass green wine glas')
SET IDENTITY_INSERT [dbo].[PImages] OFF
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [City], [Discriminator], [FirstName], [LastName], [PostalCode], [Province]) VALUES (N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'greenbean', N'GREENBEAN', N'2@gmail.com', N'2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELd7eaDGQOdK8IJUiCuQOt161skz6RINKLmuwzb1oqGGX+9uLI4VR3WNPRrwzzG2KA==', N'4KUNS4ZXJRHI2YGWASLIKB6G5DUSLHTK', N'24867aa6-204f-43bf-a0da-7590c562a712', NULL, 0, 0, NULL, 1, 0, N'52 vresway', N'pta', N'ApplicationUser', N'james', N'lambard', N'5314', N'gauteng')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Address], [City], [Discriminator], [FirstName], [LastName], [PostalCode], [Province]) VALUES (N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'miniMina', N'MINIMINA', N'22@gmail.com', N'22@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEB74UPXg1Y0nJ6rHr1lEe3vU8cnkUUVmgPLVeMkDxGCfKg7kw+i8FXs0p4DEIpAj7w==', N'4E377F2MP5V2JUW6GHTFM5BGCOLULPG6', N'3f859969-b87f-48d2-9a85-f7410fe72504', NULL, 0, 0, NULL, 1, 0, N'83 broadway', N'East london', N'ApplicationUser', N'Mina', N'lewers', N'5368', N'easterncape')
GO
SET IDENTITY_INSERT [dbo].[orderHeaders] ON 

INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1019, N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', CAST(N'2024-09-02T02:29:01.9179357' AS DateTime2), CAST(N'2024-09-09T02:29:01.9180089' AS DateTime2), 2468, N'Completed', N'Paid', CAST(N'2024-09-02T02:29:01.9182077' AS DateTime2), N'card', N'52 vresway', N'pta', N'gauteng', N'5314', N'james lambard')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1020, N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', CAST(N'2024-09-02T02:29:09.2577652' AS DateTime2), CAST(N'2024-09-09T02:29:09.2577721' AS DateTime2), 600, N'Shipped', N'Paid', CAST(N'2024-09-02T02:29:09.2577736' AS DateTime2), N'card', N'52 vresway', N'pta', N'gauteng', N'5314', N'james lambard')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1021, N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', CAST(N'2024-09-02T02:29:27.3999361' AS DateTime2), CAST(N'2024-09-09T02:29:27.3999483' AS DateTime2), 1039, N'Pending', N'Paid', CAST(N'2024-09-02T02:29:27.3999511' AS DateTime2), N'card', N'52 vresway', N'pta', N'gauteng', N'5314', N'james lambard')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1022, N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', CAST(N'2024-09-02T02:29:38.9783701' AS DateTime2), CAST(N'2024-09-09T02:29:38.9783764' AS DateTime2), 400, N'Pending', N'Paid', CAST(N'2024-09-02T02:29:38.9783778' AS DateTime2), N'card', N'52 vresway', N'pta', N'gauteng', N'5314', N'james lambard')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1023, N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', CAST(N'2024-09-02T02:30:33.2048505' AS DateTime2), CAST(N'2024-09-09T02:30:33.2048573' AS DateTime2), 120, N'Shipped', N'Paid', CAST(N'2024-09-02T02:30:33.2048587' AS DateTime2), N'card', N'83 broadway', N'East london', N'easterncape', N'5368', N'Mina lewers')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1024, N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', CAST(N'2024-09-02T02:30:42.3665902' AS DateTime2), CAST(N'2024-09-09T02:30:42.3665966' AS DateTime2), 400, N'Pending', N'Paid', CAST(N'2024-09-02T02:30:42.3665983' AS DateTime2), N'card', N'83 broadway', N'East london', N'easterncape', N'5368', N'Mina lewers')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1025, N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', CAST(N'2024-09-02T02:31:19.5841855' AS DateTime2), CAST(N'2024-09-09T02:31:19.5841931' AS DateTime2), 2080, N'Completed', N'Paid', CAST(N'2024-09-02T02:31:19.5841945' AS DateTime2), N'card', N'83 broadway', N'East london', N'easterncape', N'5368', N'Mina lewers')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1026, N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', CAST(N'2024-09-02T02:31:30.0632514' AS DateTime2), CAST(N'2024-09-09T02:31:30.0632582' AS DateTime2), 268, N'Shipped', N'Paid', CAST(N'2024-09-02T02:31:30.0632596' AS DateTime2), N'card', N'83 broadway', N'East london', N'easterncape', N'5368', N'Mina lewers')
INSERT [dbo].[orderHeaders] ([Id], [UserId], [ApplicationUserId], [DateOfOrder], [DateOfShipped], [TotalOrderAmount], [OrderStatus], [PaymentStatus], [PaymentProccessDate], [TransactionId], [DeliveryStreetAddress], [City], [Province], [PostalCode], [Name]) VALUES (1027, N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', CAST(N'2024-09-02T02:33:18.5567396' AS DateTime2), CAST(N'2024-09-09T02:33:18.5567467' AS DateTime2), 400, N'Pending', N'Paid', CAST(N'2024-09-02T02:33:18.5567484' AS DateTime2), N'card', N'83 broadway', N'East london', N'easterncape', N'5368', N'Mina lewers')
SET IDENTITY_INSERT [dbo].[orderHeaders] OFF
GO
SET IDENTITY_INSERT [dbo].[orderDetails] ON 

INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (9, 1019, 29, 4, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (10, 1019, 32, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (11, 1019, 38, 1, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (12, 1020, 31, 1, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (13, 1021, 36, 1, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (14, 1021, 30, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (15, 1022, 37, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (16, 1023, 30, 6, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (17, 1024, 29, 1, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (18, 1025, 37, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (19, 1025, 38, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (20, 1025, 33, 3, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (21, 1026, 32, 2, 0)
INSERT [dbo].[orderDetails] ([Id], [OrderHeaderId], [ProductId], [Count], [Price]) VALUES (22, 1027, 29, 1, 0)
SET IDENTITY_INSERT [dbo].[orderDetails] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'123', N'Admin', NULL, NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'456', N'Customer', NULL, NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58c3b5a3-b15f-4a64-8c13-d6fedb027c99', N'123')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b5f2d1e5-e43a-42d4-8109-eaf9daf18f01', N'456')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240828222842_initialSetup', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829113628_PushChangesToAspNetUser', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829114215_categorytablefix', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240830111726_AddViewClassToDB', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240831163014_addUserCart', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901004216_addOrderHeader', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901005812_userOrderHeadersFix', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901050355_dbFix', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901120032_CartUpdate', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901190933_OrderheaderUpdate', N'8.0.8')
GO
