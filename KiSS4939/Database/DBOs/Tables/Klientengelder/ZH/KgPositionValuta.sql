CREATE TABLE [dbo].[KgPositionValuta](
	[KgPositionValutaID] [int] IDENTITY(1,1) NOT NULL,
	[KgPositionID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[KgPositionValutaTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgPositionValuta] PRIMARY KEY CLUSTERED 
(
	[KgPositionValutaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO

/****** Object:  Index [IX_KgPositionValuta_]    Script Date: 11/23/2011 16:03:50 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KgPositionValuta_] ON [dbo].[KgPositionValuta] 
(
	[KgPositionID] ASC,
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[KgPositionValuta]  WITH CHECK ADD  CONSTRAINT [FK_KgPositionValuta_KgBudgetPosition] FOREIGN KEY([KgPositionID])
REFERENCES [dbo].[KgPosition] ([KgPositionID])
GO
ALTER TABLE [dbo].[KgPositionValuta] CHECK CONSTRAINT [FK_KgPositionValuta_KgBudgetPosition]