CREATE TABLE [dbo].[BaPraemienverbilligung](
	[BaPraemienverbilligungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Jahr] [int] NULL,
	[Folgenummer] [int] NULL,
	[BetragAnspruch] [money] NULL,
	[BetragAuszahlung] [money] NULL,
	[ZahlungAn] [varchar](100) NULL,
	[ZahlungAn_Krankenkassennummer] [varchar](10) NULL,
	[LetzteMutation] [datetime] NULL,
	[Grund] [varchar](100) NULL,
	[BaPraemienverbilligungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPraemienverbilligung] PRIMARY KEY CLUSTERED 
(
	[BaPraemienverbilligungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaPraemienverbilligungID_BaPersonID]    Script Date: 05/20/2015 09:41:03 ******/
CREATE NONCLUSTERED INDEX [IX_BaPraemienverbilligungID_BaPersonID] ON [dbo].[BaPraemienverbilligung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BAG-Nummer der Krankenkasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPraemienverbilligung', @level2type=N'COLUMN',@level2name=N'ZahlungAn_Krankenkassennummer'
GO

ALTER TABLE [dbo].[BaPraemienverbilligung]  WITH CHECK ADD  CONSTRAINT [FK_BaPraemienverbilligung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaPraemienverbilligung] CHECK CONSTRAINT [FK_BaPraemienverbilligung_BaPerson]
GO

