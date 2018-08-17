/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
=================================================================================================*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KaQJPZBericht](
	[KaQJPZBerichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,	
	[Datum] [datetime] NULL,
	[KaQJPZBerichtTypCode] [int] NULL,
	[DocumentID] [int] NULL,
  [SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaQJPZBerichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJPZBericht] PRIMARY KEY CLUSTERED 
(
	[KaQJPZBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KaAusbildung_FaLeistungID]    Script Date: 06/10/2016 17:08:39 ******/
CREATE NONCLUSTERED INDEX [IX_KaQJPZBericht_FaLeistungID] ON [dbo].[KaQJPZBericht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJPZBericht Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht', @level2type=N'COLUMN',@level2name=N'KaQJPZBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJPZBericht_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Berichts' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BerichtTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht', @level2type=N'COLUMN',@level2name=N'KaQJPZBerichtTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Referenz zum Document' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nathanaël Rossel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaQJPZBericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZBericht'
GO

ALTER TABLE [dbo].[KaQJPZBericht]  WITH CHECK ADD  CONSTRAINT [FK_KaQJPZBericht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJPZBericht] ADD  CONSTRAINT [DF_KaQJPZBericht_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaQJPZBericht] ADD  CONSTRAINT [DF_KaQJPZBericht_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[KaQJPZBericht] ADD  CONSTRAINT [DF_KaQJPZBericht_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO
