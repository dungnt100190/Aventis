CREATE TABLE [dbo].[BgAuszahlungPersonTermin](
	[BgAuszahlungPersonTerminID] [int] IDENTITY(1,1) NOT NULL,
	[BgAuszahlungPersonID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BgAuszahlungsTerminTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgAuszahlungPersonTermin] PRIMARY KEY CLUSTERED 
(
	[BgAuszahlungPersonTerminID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

/****** Object:  Index [IX_BgAuszahlungPersonTermin_BgAuszahlungPersonID]    Script Date: 11/23/2011 11:44:48 ******/
CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPersonTermin_BgAuszahlungPersonID] ON [dbo].[BgAuszahlungPersonTermin] 
(
	[BgAuszahlungPersonID] ASC
)
INCLUDE ( [Datum]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[BgAuszahlungPersonTermin]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPersonTermin_BgAuszahlungPerson] FOREIGN KEY([BgAuszahlungPersonID])
REFERENCES [dbo].[BgAuszahlungPerson] ([BgAuszahlungPersonID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgAuszahlungPersonTermin] CHECK CONSTRAINT [FK_BgAuszahlungPersonTermin_BgAuszahlungPerson]