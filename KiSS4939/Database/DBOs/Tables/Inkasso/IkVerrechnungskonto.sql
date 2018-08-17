CREATE TABLE [dbo].[IkVerrechnungskonto](
	[IkVerrechnungskontoID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Grundforderung] [money] NOT NULL,
	[VereinbarungVom] [datetime] NULL,
	[BetragProMonat] [money] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NOT NULL,
	[LetzterMonat] [money] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[IstErledigt] [bit] NOT NULL,
	[IstAnnulliert] [bit] NOT NULL,
	[AnnulliertAm] [datetime] NULL,
	[IkVerrechnungsartCode] [int] NULL,
	[IkVerrechnungskontoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkVerrechnungskonto] PRIMARY KEY CLUSTERED 
(
	[IkVerrechnungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkVerrechnungskonto_BaPersonID] ON [dbo].[IkVerrechnungskonto] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_IkVerrechnungskonto_IkRechtstitelID] ON [dbo].[IkVerrechnungskonto] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkVerrechnungskonto Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkVerrechnungskonto', @level2type=N'COLUMN',@level2name=N'IkVerrechnungskontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkVerrechnungskonto_IkRechtstitel) => IkRechtstitel.IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkVerrechnungskonto', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkVerrechnungskonto_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkVerrechnungskonto', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

ALTER TABLE [dbo].[IkVerrechnungskonto]  WITH CHECK ADD  CONSTRAINT [FK_IkVerrechnungskonto_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkVerrechnungskonto] CHECK CONSTRAINT [FK_IkVerrechnungskonto_BaPerson]
GO

ALTER TABLE [dbo].[IkVerrechnungskonto]  WITH CHECK ADD  CONSTRAINT [FK_IkVerrechnungskonto_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkVerrechnungskonto] CHECK CONSTRAINT [FK_IkVerrechnungskonto_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkVerrechnungskonto] ADD  CONSTRAINT [DF_IkVerrechnungskonto_IstErledigt]  DEFAULT ((0)) FOR [IstErledigt]
GO

ALTER TABLE [dbo].[IkVerrechnungskonto] ADD  CONSTRAINT [DF_IkVerrechnungskonto_IstAnnulliert]  DEFAULT ((0)) FOR [IstAnnulliert]
GO