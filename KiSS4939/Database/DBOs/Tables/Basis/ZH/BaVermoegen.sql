CREATE TABLE [dbo].[BaVermoegen](
	[BaVermoegenID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[StandAm] [datetime] NULL,
	[BaVermoegenSchuldCode] [int] NOT NULL,
	[Betrag] [money] NULL,
	[Liquid] [bit] NOT NULL CONSTRAINT [DF_BaVermoegen_Liquid]  DEFAULT ((1)),
	[Nr] [int] NOT NULL CONSTRAINT [DF_BaVermoegen_Nr]  DEFAULT ((0)),
	[Bemerkung] [text] NULL,
	[BaVermoegenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaVermoegen] PRIMARY KEY CLUSTERED 
(
	[BaVermoegenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_BaVermoegen_BaPersonID]    Script Date: 11/23/2011 10:47:40 ******/
CREATE NONCLUSTERED INDEX [IX_BaVermoegen_BaPersonID] ON [dbo].[BaVermoegen] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaVermoegen]  WITH CHECK ADD  CONSTRAINT [FK_BaVermoegen_BaVermoegen] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaVermoegen] CHECK CONSTRAINT [FK_BaVermoegen_BaVermoegen]