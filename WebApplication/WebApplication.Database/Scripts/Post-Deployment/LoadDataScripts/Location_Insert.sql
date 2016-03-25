-- =============================================
-- Script Template
-- =============================================
SET IDENTITY_INSERT [dbo].[Location] ON
INSERT INTO [dbo].[Location] ([LocationID], [LocationName], [LocationDescription], [LocationHours], [Latitude], [Longitude], [WebAddress], [ClientID]) VALUES (1, 'Garden Room - Faculty Dining', 'Garden Room - Faculty Dining', NULL, 40.222393, -75.228856, 'http://www.campusdish.com/en-US/CSMW/NorthwestMissouri/LocationsMenus/', 1)
INSERT INTO [dbo].[Location] ([LocationID], [LocationName], [LocationDescription], [LocationHours], [Latitude], [Longitude], [WebAddress], [ClientID]) VALUES (2, 'Poolside Cafe', 'Poolside Cafe', NULL, 40.322393, -75.328856, 'http://www.campusdish.com/en-us/CSE/JohnsHopkinsUniv', 1)
INSERT INTO [dbo].[Location] ([LocationID], [LocationName], [LocationDescription], [LocationHours], [Latitude], [Longitude], [WebAddress], [ClientID]) VALUES (3, 'Fine Arts Cafe', 'Fine Arts Cafe', NULL, 40.422393, -75.428856, 'http://www.campusdish.com/en-US/HE-IE/Queens', 2)
INSERT INTO [dbo].[Location] ([LocationID], [LocationName], [LocationDescription], [LocationHours], [Latitude], [Longitude], [WebAddress], [ClientID]) VALUES (4, 'Domino''s', 'Domino''s', NULL, 40.522393, -75.528856, 'http://www.campusdish.com/en-US/CSNE/NorthernMaine', 2)
INSERT INTO [dbo].[Location] ([LocationID], [LocationName], [LocationDescription], [LocationHours], [Latitude], [Longitude], [WebAddress], [ClientID]) VALUES (5, 'Summer Cafe', 'Summer Cafe', NULL, 39.522393, -74.528856, 'http://www.campusdish.com/en-US/CSS/UnivSouthFlorida', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF