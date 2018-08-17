CREATE TABLE [dbo].[SstIKAuszug](
	[SstIKAuszugID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[AnforderungDatum] [datetime] NOT NULL,
	[SstIKAuszugAnforderungCode] [int] NOT NULL,
	[AnforderungUserID] [int] NULL,
	[Versichertennummer] [varchar](20) NULL,
	[JahrVon] [int] NOT NULL,
	[JahrBis] [int] NOT NULL,
	[MessageID] [varchar](21) NULL,
	[ExportDatum] [datetime] NULL,
	[ExportXML] [varchar](max) NULL,
	[ImportDatum] [datetime] NULL,
	[ImportXML] [varchar](max) NULL,
	[ImportFehlermeldung] [varchar](max) NULL,
	[DocumentID] [int] NULL,
	[Deaktiviert] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [varchar](50) NOT NULL,
	[SstIKAuszugTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstIKAuszug] PRIMARY KEY CLUSTERED 
(
	[SstIKAuszugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_SstIKAuszug_AnforderungUserID]    Script Date: 03/22/2012 10:29:53 ******/
CREATE NONCLUSTERED INDEX [IX_SstIKAuszug_AnforderungUserID] ON [dbo].[SstIKAuszug] 
(
	[AnforderungUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_SstIKAuszug_BaPersonID]    Script Date: 03/22/2012 10:29:53 ******/
CREATE NONCLUSTERED INDEX [IX_SstIKAuszug_BaPersonID] ON [dbo].[SstIKAuszug] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SstIKAuszug]  WITH CHECK ADD  CONSTRAINT [FK_SstIKAuszug_BaPerson_BaPersonID] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[SstIKAuszug] CHECK CONSTRAINT [FK_SstIKAuszug_BaPerson_BaPersonID]
GO

ALTER TABLE [dbo].[SstIKAuszug]  WITH CHECK ADD  CONSTRAINT [FK_SstIKAuszug_XUser_AnforderungUserID] FOREIGN KEY([AnforderungUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[SstIKAuszug] CHECK CONSTRAINT [FK_SstIKAuszug_XUser_AnforderungUserID]
GO

ALTER TABLE [dbo].[SstIKAuszug] ADD  CONSTRAINT [DF_SstIKAuszug_AnforderungDatum]  DEFAULT (getdate()) FOR [AnforderungDatum]
GO

ALTER TABLE [dbo].[SstIKAuszug] ADD  CONSTRAINT [DF_SstIKAuszug_Deaktiviert]  DEFAULT ((0)) FOR [Deaktiviert]
GO

ALTER TABLE [dbo].[SstIKAuszug] ADD  CONSTRAINT [DF_SstIKAuszug_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[SstIKAuszug] ADD  CONSTRAINT [DF_SstIKAuszug_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

