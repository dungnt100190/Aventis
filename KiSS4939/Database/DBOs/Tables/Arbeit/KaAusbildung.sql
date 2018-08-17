/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
=================================================================================================*/

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
/****** Object:  Table [dbo].[KaAusbildung]    Script Date: 06/10/2016 17:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KaAusbildung](
	[KaAusbildungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,	
	[Andere] [varchar](max) NULL,
	[KaAusbildungVorbildungCode] [int] NULL,
	[KaBecoErlernterBerufCode] [int] NULL,
	[KaVermittlBiBerufsbilCode] [int] NULL,
	[KaVermittlBiBerufserfCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaAusbildungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAusbildung] PRIMARY KEY CLUSTERED 
(
	[KaAusbildungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KaAusbildung_FaLeistungID]    Script Date: 06/10/2016 17:08:39 ******/
CREATE NONCLUSTERED INDEX [IX_KaAusbildung_FaLeistungID] ON [dbo].[KaAusbildung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaAusbildung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'KaAusbildungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaAusbildung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Andere' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'Andere'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV Ausbildung Vorbildung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'KaAusbildungVorbildungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BECO erlenter Beruf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'KaBecoErlernterBerufCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BIAS Ausbildung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'KaVermittlBiBerufsbilCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV BIAS Berufserfahrung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung', @level2type=N'COLUMN',@level2name=N'KaVermittlBiBerufserfCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nathanaël Rossel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaAusbildung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAusbildung'
GO

ALTER TABLE [dbo].[KaAusbildung]  WITH CHECK ADD  CONSTRAINT [FK_KaAusbildung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaAusbildung] ADD  CONSTRAINT [DF_KaAusbildung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaAusbildung] ADD  CONSTRAINT [DF_KaAusbildung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


