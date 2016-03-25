ALTER TABLE [dbo].[aspnet_Users]
    ADD CONSTRAINT [DF__aspnet_Us__UserI__0519C6AF] DEFAULT (newid()) FOR [UserId];

