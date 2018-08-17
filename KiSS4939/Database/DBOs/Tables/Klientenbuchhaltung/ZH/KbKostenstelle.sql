CREATE TABLE [dbo].[KbKostenstelle](
	[KbKostenstelleID] [int] IDENTITY(1,1) NOT NULL,
	[Nr] [varchar](20) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[BaPersonID] [int] NULL,
	[Aktiv] [bit] NOT NULL,
	[KbKostenstelleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbKostenstelle] PRIMARY KEY CLUSTERED 
(
	[KbKostenstelleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbKostenstelle_BaPersonID]    Script Date: 11/23/2011 15:56:56 ******/
CREATE NONCLUSTERED INDEX [IX_KbKostenstelle_BaPersonID] ON [dbo].[KbKostenstelle] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KbKostenstelle]  WITH CHECK ADD  CONSTRAINT [FK_KbKostenstelle_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbKostenstelle] CHECK CONSTRAINT [FK_KbKostenstelle_BaPerson]