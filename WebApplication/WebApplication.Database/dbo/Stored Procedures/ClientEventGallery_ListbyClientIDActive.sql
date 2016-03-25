﻿-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ClientEventGallery_ListbyClientIDActive]
	-- Add the parameters for the stored procedure here
	@ClientID int,
	@Active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT [ClientEventGalleryID]
      ,[ClientID]
      ,[ClientEventGalleryName]
      ,[ClientEventGalleryPath]
      ,[ClientEventGalleryEndDate]
      ,[ClientEventGallerySortOrder]
      ,[ClientEventGalleryActive]
  FROM [ClientEventGallery]
  WHERE
	ClientID = @ClientID AND
	[ClientEventGalleryActive] = @Active
	
END