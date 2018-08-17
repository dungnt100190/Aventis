CREATE TABLE [dbo].[BgAuszahlungPerson](
	[BgAuszahlungPersonID] [int] IDENTITY(1,1) NOT NULL,
	[BgPositionID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[BgZahlungsmodusID] [int] NULL,
	[KbAuszahlungsArtCode] [int] NULL,
	[BgAuszahlungsTerminCode] [int] NULL,
	[BgWochentagCodes] [varchar](20) NULL,
	[BaZahlungswegID] [int] NULL,
	[Zahlungsgrund] [varchar](200) NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BgAuszahlungPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgAuszahlungPerson] PRIMARY KEY CLUSTERED 
(
	[BgAuszahlungPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BaPersonID] ON [dbo].[BgAuszahlungPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BaPersonIDBgPositionID_Unique] ON [dbo].[BgAuszahlungPerson] 
(
	[BaPersonID] ASC,
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BaZahlungswegID] ON [dbo].[BgAuszahlungPerson] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BgPositionID] ON [dbo].[BgAuszahlungPerson] 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BgPositionID_BgAuszahlungPersonID_BaPersonID] ON [dbo].[BgAuszahlungPerson] 
(
	[BgPositionID] ASC,
	[BgAuszahlungPersonID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BgZahlungsmodusID] ON [dbo].[BgAuszahlungPerson] 
(
	[BgZahlungsmodusID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgAuszahlungPerson Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPerson', @level2type=N'COLUMN',@level2name=N'BgAuszahlungPersonID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgAuszahlungPerson_BgPosition) => BgPosition.BgPositionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPerson', @level2type=N'COLUMN',@level2name=N'BgPositionID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgAuszahlungPerson_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgAuszahlungPerson_BgZahlungsmodus) => BgZahlungsmodus.BgZahlungsmodusID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPerson', @level2type=N'COLUMN',@level2name=N'BgZahlungsmodusID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgAuszahlungPerson_BaZahlungsweg) => BaZahlungsweg.BaZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgAuszahlungPerson', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BaPerson]
GO

ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BaZahlungsweg]
GO

ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BgPosition]
GO

ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BgZahlungsmodus] FOREIGN KEY([BgZahlungsmodusID])
REFERENCES [dbo].[BgZahlungsmodus] ([BgZahlungsmodusID])
GO

ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BgZahlungsmodus]
GO

ALTER TABLE [dbo].[BgAuszahlungPerson] ADD  CONSTRAINT [DF_BgAuszahlungPerson_BgAuszahlungsterminCode]  DEFAULT (1) FOR [BgAuszahlungsTerminCode]
GO