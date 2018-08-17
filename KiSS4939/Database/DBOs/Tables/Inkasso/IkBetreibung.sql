CREATE TABLE [dbo].[IkBetreibung](
	[IkBetreibungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[IkRechtstitelID] [int] NULL,
	[IkBetreibungStatusCode] [int] NOT NULL,
	[IkVerlustscheinStatusCode] [int] NOT NULL,
	[IkVerlustscheinTypCode] [int] NOT NULL,
	[BetreibungAm] [datetime] NOT NULL,
	[BetreibungNummer] [varchar](20) NULL,
	[BetreibungAmt] [varchar](200) NULL,
	[BetreibungBetrag] [money] NULL,
	[BetreibungVon] [datetime] NULL,
	[BetreibungBis] [datetime] NULL,
	[BetreibungFortsetzungAm] [datetime] NULL,
	[BetreibungVerwertungAm] [datetime] NULL,
	[BetreibungRechtsoeffnungAm] [datetime] NULL,
	[Glaeubiger] [varchar](200) NULL,
	[VerlustscheinAm] [datetime] NOT NULL,
	[VerlustscheinNummer] [varchar](20) NULL,
	[VerlustscheinAmt] [varchar](200) NULL,
	[VerlustscheinBetrag] [money] NULL,
	[VerlustscheinZins] [money] NULL,
	[VerlustscheinKosten] [money] NULL,
	[VerlustscheinVerjaehrungAm] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[IkBetreibungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkBetreibung] PRIMARY KEY CLUSTERED 
(
	[IkBetreibungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkBetreibung_FaLeistungID] ON [dbo].[IkBetreibung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_IkBetreibung_IkRechtstitelID] ON [dbo].[IkBetreibung] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkBetreibung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkBetreibung', @level2type=N'COLUMN',@level2name=N'IkBetreibungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkBetreibung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkBetreibung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkBetreibung_IkRechtstitel) => IkRechtstitel.IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkBetreibung', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

ALTER TABLE [dbo].[IkBetreibung]  WITH CHECK ADD  CONSTRAINT [FK_IkBetreibung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkBetreibung] CHECK CONSTRAINT [FK_IkBetreibung_FaLeistung]
GO

ALTER TABLE [dbo].[IkBetreibung]  WITH CHECK ADD  CONSTRAINT [FK_IkBetreibung_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkBetreibung] CHECK CONSTRAINT [FK_IkBetreibung_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkBetreibung] ADD  CONSTRAINT [DF_IkBetreibung_IkBetreibungStatusCode]  DEFAULT ((1)) FOR [IkBetreibungStatusCode]
GO

ALTER TABLE [dbo].[IkBetreibung] ADD  CONSTRAINT [DF_IkBetreibung_IkVerlustscheinStatusCode]  DEFAULT ((1)) FOR [IkVerlustscheinStatusCode]
GO

ALTER TABLE [dbo].[IkBetreibung] ADD  CONSTRAINT [DF_IkBetreibung_IkVerlustscheinTypCode]  DEFAULT ((1)) FOR [IkVerlustscheinTypCode]
GO