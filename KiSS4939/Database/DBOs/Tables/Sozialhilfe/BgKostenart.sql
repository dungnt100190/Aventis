SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BgKostenart](
	[BgKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[ModulID] [int] NOT NULL,
	[KontoNr] [varchar](10) NULL,
	[Name] [varchar](100) NOT NULL,
	[NameTID] [int] NULL,
	[Quoting] [bit] NOT NULL,
	[BgSplittingArtCode] [int] NULL,
	[BaWVZeileCode] [int] NULL,
	[BgKostenartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgKostenart] PRIMARY KEY CLUSTERED 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BgKostenart_ModulID] ON [dbo].[BgKostenart] 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BgKostenart Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BgKostenart_XModul) => XModul.ModulID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID für die Übersetzung des Namen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart', @level2type=N'COLUMN',@level2name=N'NameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert in welcher Zeile die Kostenart im ZUG Report angezeigt werden soll.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgKostenart', @level2type=N'COLUMN',@level2name=N'BaWVZeileCode'
GO

ALTER TABLE [dbo].[BgKostenart]  WITH CHECK ADD  CONSTRAINT [FK_BgKostenart_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[BgKostenart] CHECK CONSTRAINT [FK_BgKostenart_XModul]
GO

ALTER TABLE [dbo].[BgKostenart] ADD  CONSTRAINT [DF_BgKostenart_ModulID]  DEFAULT ((3)) FOR [ModulID]
GO

ALTER TABLE [dbo].[BgKostenart] ADD  CONSTRAINT [DF_BgKostenart_Quoting]  DEFAULT ((0)) FOR [Quoting]
GO


