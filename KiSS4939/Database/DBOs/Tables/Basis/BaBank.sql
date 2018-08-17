CREATE TABLE [dbo].[BaBank](
	[BaBankID] [int] IDENTITY(1,1) NOT NULL,
	[LandCode] [int] NULL,
	[Name] [varchar](70) NOT NULL,
	[Zusatz] [varchar](50) NULL,
	[Strasse] [varchar](50) NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[ClearingNr] [varchar](15) NOT NULL,
	[ClearingNrNeu] [varchar](15) NULL,
	[FilialeNr] [int] NOT NULL,
	[HauptsitzBCL] [varchar](15) NULL,
	[PCKontoNr] [varchar](50) NULL,
	[GueltigAb] [datetime] NOT NULL,
	[SicUpdated] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaBankTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaBank] PRIMARY KEY CLUSTERED 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaBank_BaBankID__AddCols]    Script Date: 06/29/2011 08:22:51 ******/
CREATE NONCLUSTERED INDEX [IX_BaBank_BaBankID__AddCols] ON [dbo].[BaBank] 
(
	[BaBankID] ASC
)
INCLUDE ( [Name],
[Strasse],
[PLZ],
[Ort],
[ClearingNr],
[PCKontoNr]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaBank_ClearingNr_FilialeNr]    Script Date: 06/29/2011 08:22:51 ******/
CREATE NONCLUSTERED INDEX [IX_BaBank_ClearingNr_FilialeNr] ON [dbo].[BaBank] 
(
	[ClearingNr] ASC,
	[FilialeNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaBank_LandCode]    Script Date: 06/29/2011 08:22:51 ******/
CREATE NONCLUSTERED INDEX [IX_BaBank_LandCode] ON [dbo].[BaBank] 
(
	[LandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaBank Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank', @level2type=N'COLUMN',@level2name=N'BaBankID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld auf Maske CtlBaBank entfernt. Wäre momentan also überflüssig. In nächstem Schritt entfernen?!?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank', @level2type=N'COLUMN',@level2name=N'LandCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld auf Maske CtlBaBank entfernt. Wäre momentan also überflüssig. In nächstem Schritt entfernen?!?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank', @level2type=N'COLUMN',@level2name=N'Zusatz'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bankenstamm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KliBu, WS, WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaBank'
GO

ALTER TABLE [dbo].[BaBank]  WITH CHECK ADD  CONSTRAINT [FK_BaBank_BaLand] FOREIGN KEY([LandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaBank] CHECK CONSTRAINT [FK_BaBank_BaLand]
GO

ALTER TABLE [dbo].[BaBank] ADD  CONSTRAINT [DF_BaBank_SicUpdated]  DEFAULT ((0)) FOR [SicUpdated]
GO

ALTER TABLE [dbo].[BaBank] ADD  CONSTRAINT [DF_BaBank_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaBank] ADD  CONSTRAINT [DF_BaBank_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


