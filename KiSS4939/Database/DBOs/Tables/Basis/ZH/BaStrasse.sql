﻿CREATE TABLE [dbo].[BaStrasse](
	[BaStrasseID] [int] NOT NULL,
	[OrtCode] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[StrasseKurz] [varchar](12) NOT NULL,
	[StrasseLang] [varchar](40) NOT NULL,
	[BaStrasseTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaStrasse] PRIMARY KEY CLUSTERED 
(
	[BaStrasseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaStrasse_StrasseLang]    Script Date: 11/23/2011 10:47:20 ******/
CREATE NONCLUSTERED INDEX [IX_BaStrasse_StrasseLang] ON [dbo].[BaStrasse] 
(
	[StrasseLang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]