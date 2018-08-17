CREATE TABLE [dbo].[IkAnzeige](
	[IkAnzeigeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[IkAnzeigeTypCode] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[IkAnzeigeEroeffnungGrundCode] [int] NULL,
	[EroeffnungGrund] [varchar](64) NULL,
	[IkAnzeigeAbschlussGrundCode] [int] NULL,
	[Bemerkung] [varchar](1024) NULL,
	[IkAnzeigeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkAnzeige] PRIMARY KEY CLUSTERED 
(
	[IkAnzeigeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkAnzeige_FaLeistungID] ON [dbo].[IkAnzeige] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeile1  Zeile2  Zeile3  Zeile4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAnzeige', @level2type=N'COLUMN',@level2name=N'IkAnzeigeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkAnzeige_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAnzeige', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[IkAnzeige]  WITH CHECK ADD  CONSTRAINT [FK_IkAnzeige_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkAnzeige] CHECK CONSTRAINT [FK_IkAnzeige_FaLeistung]
GO

ALTER TABLE [dbo].[IkAnzeige] ADD  CONSTRAINT [DF_IkAnzeige_DatumVon]  DEFAULT (getdate()) FOR [DatumVon]
GO