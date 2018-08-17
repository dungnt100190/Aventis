CREATE TABLE [dbo].[KbWVEinzelpostenFehler](
	[KbWVEinzelpostenFehlerID] [int] IDENTITY(1,1) NOT NULL,
	[KbWVLaufID] [int] NOT NULL,
	[KbBuchungBruttoPersonID] [int] NOT NULL,
	[FaFallID] [int] NOT NULL,
	[WVFehlermeldung] [varchar](2000) NOT NULL,
	[KbWVEinzelpostenFehlerTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbWVEinzelpostenFehler] PRIMARY KEY CLUSTERED 
(
	[KbWVEinzelpostenFehlerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbWVEinzelpostenFehler_FaFallID]    Script Date: 03/22/2012 10:28:42 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelpostenFehler_FaFallID] ON [dbo].[KbWVEinzelpostenFehler] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbWVEinzelpostenFehler_KbBuchungBruttoPersonID]    Script Date: 03/22/2012 10:28:42 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelpostenFehler_KbBuchungBruttoPersonID] ON [dbo].[KbWVEinzelpostenFehler] 
(
	[KbBuchungBruttoPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbWVEinzelpostenFehler_KbWVLaufID]    Script Date: 03/22/2012 10:28:42 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelpostenFehler_KbWVLaufID] ON [dbo].[KbWVEinzelpostenFehler] 
(
	[KbWVLaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelpostenFehler_FaFall] FOREIGN KEY([FaFallID])
REFERENCES [dbo].[FaFall] ([FaFallID])
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler] CHECK CONSTRAINT [FK_KbWVEinzelpostenFehler_FaFall]
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelpostenFehler_KbBuchungBruttoPerson] FOREIGN KEY([KbBuchungBruttoPersonID])
REFERENCES [dbo].[KbBuchungBruttoPerson] ([KbBuchungBruttoPersonID])
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler] CHECK CONSTRAINT [FK_KbWVEinzelpostenFehler_KbBuchungBruttoPerson]
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelpostenFehler_KbWVLauf] FOREIGN KEY([KbWVLaufID])
REFERENCES [dbo].[KbWVLauf] ([KbWVLaufID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KbWVEinzelpostenFehler] CHECK CONSTRAINT [FK_KbWVEinzelpostenFehler_KbWVLauf]
GO

