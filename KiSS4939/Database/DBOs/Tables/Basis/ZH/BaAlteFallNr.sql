CREATE TABLE [dbo].[BaAlteFallNr](
	[BaAlteFallNrID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[MigHerkunftCode] [int] NULL,
	[ResoNrAlt] [varchar](50) NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Info] [text] NULL,
	[Migriert] [bit] NOT NULL,
	[ProlePN_Nr] [varchar](50) NULL,
	[BaAlteFallNrTS] [timestamp] NOT NULL,
	[FallNrAlt] [int] NULL,
	[PersonNrAlt] [int] NULL,
 CONSTRAINT [PK_BaAlteFallNr] PRIMARY KEY CLUSTERED 
(
	[BaAlteFallNrID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaAlteFallNr_BaPersonID]    Script Date: 03/22/2012 10:21:39 ******/
CREATE NONCLUSTERED INDEX [IX_BaAlteFallNr_BaPersonID] ON [dbo].[BaAlteFallNr] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO

ALTER TABLE [dbo].[BaAlteFallNr]  WITH CHECK ADD  CONSTRAINT [FK_BaAlteFallNr_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaAlteFallNr] CHECK CONSTRAINT [FK_BaAlteFallNr_BaPerson]
GO

ALTER TABLE [dbo].[BaAlteFallNr] ADD  CONSTRAINT [DF_BaAlteFallNr_Migriert]  DEFAULT ((0)) FOR [Migriert]
GO

