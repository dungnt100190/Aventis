﻿CREATE TABLE [dbo].[BFSWert](
	[BFSWertID] [int] IDENTITY(1,1) NOT NULL,
	[BFSDossierID] [int] NOT NULL,
	[BFSDossierPersonID] [int] NULL,
	[BFSFrageID] [int] NOT NULL,
	[Wert] [sql_variant] NULL,
	[PlausiFehler] [text] NULL,
	[BFSWertTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BFSWert] PRIMARY KEY CLUSTERED 
(
	[BFSWertID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_BFSWert] UNIQUE NONCLUSTERED 
(
	[BFSDossierID] ASC,
	[BFSDossierPersonID] ASC,
	[BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_BFSWert_BFSFrageID] ON [dbo].[BFSWert] 
(
	[BFSFrageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSDossier] FOREIGN KEY([BFSDossierID])
REFERENCES [dbo].[BFSDossier] ([BFSDossierID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSDossier]
GO
ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSDossierPerson] FOREIGN KEY([BFSDossierPersonID])
REFERENCES [dbo].[BFSDossierPerson] ([BFSDossierPersonID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSDossierPerson]
GO
ALTER TABLE [dbo].[BFSWert]  WITH CHECK ADD  CONSTRAINT [FK_BFSWert_BFSFrage] FOREIGN KEY([BFSFrageID])
REFERENCES [dbo].[BFSFrage] ([BFSFrageID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BFSWert] CHECK CONSTRAINT [FK_BFSWert_BFSFrage]