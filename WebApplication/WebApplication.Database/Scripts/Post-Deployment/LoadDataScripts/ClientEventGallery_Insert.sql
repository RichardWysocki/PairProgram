-- =============================================
-- Script Template
-- =============================================
SET IDENTITY_INSERT [dbo].ClientEventGallery ON

INSERT ClientEventGallery(ClientEventGalleryID,ClientID,ClientEventGalleryName,ClientEventGalleryPath,ClientEventGalleryEndDate,ClientEventGallerySortOrder,ClientEventGalleryActive) VALUES('1','7','Welcome Back Pary','Drexel/Welcome','2013-04-01','1','1')
INSERT ClientEventGallery(ClientEventGalleryID,ClientID,ClientEventGalleryName,ClientEventGalleryPath,ClientEventGalleryEndDate,ClientEventGallerySortOrder,ClientEventGalleryActive) VALUES('2','7','School''s Cool Event','Drexel/School','2013-05-01','2','1')
INSERT ClientEventGallery(ClientEventGalleryID,ClientID,ClientEventGalleryName,ClientEventGalleryPath,ClientEventGalleryEndDate,ClientEventGallerySortOrder,ClientEventGalleryActive) VALUES('3','7','Valentines Event','Drexel/Valentines','2013-06-01','3','1')



SET IDENTITY_INSERT [dbo].ClientEventGallery OFF