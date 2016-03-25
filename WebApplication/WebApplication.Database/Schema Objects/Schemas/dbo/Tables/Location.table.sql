CREATE TABLE [dbo].[Location] (
    [LocationID]          INT           IDENTITY (1, 1) NOT NULL,
    [LocationName]        VARCHAR (50)  NULL,
    [LocationDescription] VARCHAR (100) NULL,
    [Latitude]            FLOAT         NULL,
    [Longitude]           FLOAT         NULL,
	[WebAddress]          VARCHAR(150)  NULL,
    [ClientID]            INT           NULL, 
    [LocationHours] VARCHAR(100) NULL
);


