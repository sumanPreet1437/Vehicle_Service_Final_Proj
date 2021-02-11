INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'02221027-c753-4b42-8bc9-3f867b6d2160', N'vehicle_owner', N'vehicle_owner', N'30984b8c-0526-4f79-9b0b-bec3a165f4df')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c0bc7a84-0e52-4bdc-949a-0d3528db4c84', N'vehicle_admin', N'vehicle_admin', N'143e0ea1-3d56-4166-89ef-9d752f4c9162')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3d5393e6-f0d9-470f-9de5-a354d36728d8', N'admin@service.com', N'ADMIN@SERVICE.COM', N'admin@service.com', N'ADMIN@SERVICE.COM', 1, N'AQAAAAEAACcQAAAAEJ/SjcfGKpt8NJ5f/eDY4LC3Fs+EEHCFJKOMxiWzsPHKNRh7+XhhT34LvnbGNe+I8Q==', N'26MUUXX3LN6Y2QBEVOZRMEBT3NVYXQST', N'c4d95177-06bd-4c3a-8480-e543a5f89668', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5cea0eee-1526-454e-a6c9-0384efd112ab', N'hans@service.com', N'HANS@SERVICE.COM', N'hans@service.com', N'HANS@SERVICE.COM', 1, N'AQAAAAEAACcQAAAAEFQtQ0kJFsxC6MOrC5aj+s13f3h1iyl/QWVD7jlwGVhzr042a2OYFYbZELa0bqPMvA==', N'I4TZZ6E4OECRSADGNFBENO4RV4F7EHET', N'c1d5e933-94d2-41a7-8243-b497b6833f22', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8369f6ab-b178-47d0-8a46-aa56cff0d814', N'john@service.com', N'JOHN@SERVICE.COM', N'john@service.com', N'JOHN@SERVICE.COM', 1, N'AQAAAAEAACcQAAAAEEUrJS7AXnwucqmu+MjerJIIZMwDupwmB8XxjkoikMiVvlctmrGztk3BF+5Rj2h8Lw==', N'FZQ44LY4JAB54S7AZ2POIZLH3GR3WDLE', N'01f96469-3d7a-47dd-bb48-04cdcf4d73a6', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5cea0eee-1526-454e-a6c9-0384efd112ab', N'02221027-c753-4b42-8bc9-3f867b6d2160')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8369f6ab-b178-47d0-8a46-aa56cff0d814', N'02221027-c753-4b42-8bc9-3f867b6d2160')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d5393e6-f0d9-470f-9de5-a354d36728d8', N'c0bc7a84-0e52-4bdc-949a-0d3528db4c84')
SET IDENTITY_INSERT [dbo].[Service] ON
INSERT INTO [dbo].[Service] ([Id], [ServiceName], [ServiceCharge], [Description]) VALUES (1, N'Body Paint', CAST(300.00 AS Decimal(18, 2)), N'Full Body paint with a wide range of color options ')
INSERT INTO [dbo].[Service] ([Id], [ServiceName], [ServiceCharge], [Description]) VALUES (2, N'Full Service ', CAST(800.00 AS Decimal(18, 2)), N'Full Car service including wheel alignment and Engine tune-up')
INSERT INTO [dbo].[Service] ([Id], [ServiceName], [ServiceCharge], [Description]) VALUES (3, N'Service - Electric Vehicles', CAST(700.00 AS Decimal(18, 2)), N'Full Service with motor repair and battery status check ')
SET IDENTITY_INSERT [dbo].[Service] OFF
SET IDENTITY_INSERT [dbo].[VehicleOwner] ON
INSERT INTO [dbo].[VehicleOwner] ([Id], [Name], [ContactNumber], [Email]) VALUES (1, N'John Gareth', N'0218883456', N'john@service.com')
INSERT INTO [dbo].[VehicleOwner] ([Id], [Name], [ContactNumber], [Email]) VALUES (2, N'Hans Miller', N'0214456789', N'hans@service.com')
SET IDENTITY_INSERT [dbo].[VehicleOwner] OFF
SET IDENTITY_INSERT [dbo].[ServiceBookingRecord] ON
INSERT INTO [dbo].[ServiceBookingRecord] ([Id], [ServiceId], [VehicleOwnerId]) VALUES (6, 3, 1)
INSERT INTO [dbo].[ServiceBookingRecord] ([Id], [ServiceId], [VehicleOwnerId]) VALUES (7, 3, 1)
INSERT INTO [dbo].[ServiceBookingRecord] ([Id], [ServiceId], [VehicleOwnerId]) VALUES (8, 2, 2)
SET IDENTITY_INSERT [dbo].[ServiceBookingRecord] OFF
