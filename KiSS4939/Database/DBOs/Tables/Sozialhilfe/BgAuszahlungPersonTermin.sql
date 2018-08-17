CREATE TABLE [dbo].[BgAuszahlungPersonTermin](
	[BgAuszahlungPersonTerminID] [int] IDENTITY(1,1) NOT NULL,
	[BgAuszahlungPersonID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BgAuszahlungPersonTerminTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgAuszahlungPersonTermin] PRIMARY KEY CLUSTERED 
(
	[BgAuszahlungPersonTerminID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPersonTermin_BgAuszahlungPersonID_Datum] ON [dbo].[BgAuszahlungPersonTermin] 
(
	[BgAuszahlungPersonID] ASC,
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgAuszahlungPersonTermin Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPersonTermin', @level2type=N'COLUMN',@level2name=N'BgAuszahlungPersonTerminID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgAuszahlungPersonTermin_BgAuszahlungPerson) => BgAuszahlungPerson.BgAuszahlungPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPersonTermin', @level2type=N'COLUMN',@level2name=N'BgAuszahlungPersonID'
GO


GO


GO


GO


GO


GO


GO


GO

ALTER TABLE [dbo].[BgAuszahlungPersonTermin]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPersonTermin_BgAuszahlungPerson] FOREIGN KEY([BgAuszahlungPersonID])
REFERENCES [dbo].[BgAuszahlungPerson] ([BgAuszahlungPersonID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgAuszahlungPersonTermin] CHECK CONSTRAINT [FK_BgAuszahlungPersonTermin_BgAuszahlungPerson]
GO