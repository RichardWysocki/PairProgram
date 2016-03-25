-- =============================================
-- Script Template
-- =============================================
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([ProductID], [ProductName], [ProductDescription], [ProductPrice], [ProductActive], [ProductStartDate], [ProductEndDate]) VALUES (1, 'Cokes', 'Great Product too', 2.0000, 1, '2011-10-01', '2013-01-01')
INSERT INTO [dbo].[Product] ([ProductID], [ProductName], [ProductDescription], [ProductPrice], [ProductActive], [ProductStartDate], [ProductEndDate]) VALUES (3, 'Pepsi', 'OK Product', 1.9900, 0, '2012-01-01', '2013-01-01')
SET IDENTITY_INSERT [dbo].[Product] OFF
