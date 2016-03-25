ALTER TABLE [dbo].[aspnet_Applications]
    ADD CONSTRAINT [DF__aspnet_Ap__Appli__014935CB] DEFAULT (newid()) FOR [ApplicationId];

