-- =============================================
-- Script Template
-- =============================================
SET IDENTITY_INSERT [dbo].[EPSAccount] ON
INSERT [dbo].[EPSAccount] ([EPSAccountID], [ClientID], [EPSAccountDisplayName], [EPSAccountAccountName], [EPSAccountOrder], [EPSAccountActive], [EPSAccountWebServicePath], [EPSAccountKey1], [EPSAccountKey2], [EPSAccountTimeOut], [EPSAccountEncryptActive]) VALUES (1, 1, N'Residential Plans', N'1_MBM_AllTenders', 1, 1, N'http://www.spquantum.net/RelayWebService/RelayService.asmx', N'XIb0BH/4X8JY707/rlpZ5LMO', N'rg2WIOWS', 10, 1)
INSERT [dbo].[EPSAccount] ([EPSAccountID], [ClientID], [EPSAccountDisplayName], [EPSAccountAccountName], [EPSAccountOrder], [EPSAccountActive], [EPSAccountWebServicePath], [EPSAccountKey1], [EPSAccountKey2], [EPSAccountTimeOut], [EPSAccountEncryptActive]) VALUES (2, 2, N'Commuter Plans', N'1_MBM_AllTenders', 2, 1, N'http://www.spquantum.net/RelayWebService/RelayService.asmx', N'XIb0BH/4X8JY707/rlpZ5LMO', N'rg2WIOWS', 10, 1)
SET IDENTITY_INSERT [dbo].[EPSAccount] OFF
