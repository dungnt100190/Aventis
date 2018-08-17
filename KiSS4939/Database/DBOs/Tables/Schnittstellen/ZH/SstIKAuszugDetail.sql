CREATE TABLE [dbo].[SstIKAuszugDetail](
	[SstIKAuszugDetailID] [int] IDENTITY(1,1) NOT NULL,
	[SstIKAuszugID] [int] NOT NULL,
	[Versichertennummer] [varchar](16) NOT NULL,
	[Kassennummer] [varchar](7) NOT NULL,
	[Abrechnungsnummer] [varchar](16) NULL,
	[Einkommenscode] [varchar](2) NULL,
	[BruchteilBG] [varchar](2) NULL,
	[BeitragsmonatVon] [varchar](2) NULL,
	[BeitragsmonatBis] [varchar](2) NULL,
	[BeitragsJahr] [varchar](4) NULL,
	[Einkommen] [money] NULL,
	[Arbeitgeber] [varchar](100) NULL,
	[Einkommensart] [varchar](50) NULL,
	[Bezeichnung] [varchar](100) NULL,
	[SstIKAuszugDetailTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstIKAuszugDetail] PRIMARY KEY CLUSTERED 
(
	[SstIKAuszugDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_SstIKAuszugDetail_SstIKAuszugID]    Script Date: 03/22/2012 10:38:12 ******/
CREATE NONCLUSTERED INDEX [IX_SstIKAuszugDetail_SstIKAuszugID] ON [dbo].[SstIKAuszugDetail] 
(
	[SstIKAuszugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SstIKAuszugDetail]  WITH CHECK ADD  CONSTRAINT [FK_SstIKAuszugDetail_SstIKAuszug_SstIKAuszugID] FOREIGN KEY([SstIKAuszugID])
REFERENCES [dbo].[SstIKAuszug] ([SstIKAuszugID])
GO

ALTER TABLE [dbo].[SstIKAuszugDetail] CHECK CONSTRAINT [FK_SstIKAuszugDetail_SstIKAuszug_SstIKAuszugID]
GO

