CREATE TABLE [dbo].[OLD_30_AiForderungEinmalig](
	[AiForderungEinmaligID] [int] IDENTITY(1,1) NOT NULL,
	[AiForderungID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[Bemerkung] [varchar](1024) NULL,
	[AiForderungEinmaligTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiForderungEinmalig] PRIMARY KEY NONCLUSTERED 
(
	[AiForderungEinmaligID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiForderungEinmalig] ON [dbo].[OLD_30_AiForderungEinmalig] 
(
	[AiForderungID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiForderungEinmalig]  WITH CHECK ADD  CONSTRAINT [FK_AiForderungEinmalig_AiForderung] FOREIGN KEY([AiForderungID])
REFERENCES [OLD_30_AiForderung] ([AiForderungID])
GO