﻿ALTER TABLE [dbo].[EPSAccount]
    ADD CONSTRAINT [FK_EPSAccount_Client] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Client] ([ClientID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

