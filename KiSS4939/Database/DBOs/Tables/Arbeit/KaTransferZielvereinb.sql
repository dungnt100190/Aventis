CREATE TABLE [dbo].[KaTransferZielvereinb](
	[KaTransferZielvereinbID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[FeinzielDat] [datetime] NULL,
	[Feinziel] [varchar](max) NULL,
	[ErreichenBis] [varchar](100) NULL,
	[ProzessAuftrag] [varchar](max) NULL,
	[Ergebnis] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaTransferZielvereinbTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaTransferZielvereinb] PRIMARY KEY CLUSTERED 
(
	[KaTransferZielvereinbID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaTransferZielvereinb_FaLeistungID] ON [dbo].[KaTransferZielvereinb] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaTransferZielvereinb Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransferZielvereinb', @level2type=N'COLUMN',@level2name=N'KaTransferZielvereinbID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaTransferZielvereinb_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransferZielvereinb', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransferZielvereinb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enthält die Daten für KA - Transfer - Prozess - Zielvereinbarung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransferZielvereinb'
GO

ALTER TABLE [dbo].[KaTransferZielvereinb]  WITH CHECK ADD  CONSTRAINT [FK_KaTransferZielvereinb_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaTransferZielvereinb] CHECK CONSTRAINT [FK_KaTransferZielvereinb_FaLeistung]
GO

ALTER TABLE [dbo].[KaTransferZielvereinb] ADD  CONSTRAINT [DF_KaTransferZielvereinb_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaTransferZielvereinb] ADD  CONSTRAINT [DF_KaTransferZielvereinb_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaTransferZielvereinb] ADD  CONSTRAINT [DF_KaTransferZielvereinb_Modified]  DEFAULT (getdate()) FOR [Modified]
GO