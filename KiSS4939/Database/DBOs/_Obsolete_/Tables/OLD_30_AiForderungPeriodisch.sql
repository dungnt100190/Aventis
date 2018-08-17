CREATE TABLE [dbo].[OLD_30_AiForderungPeriodisch](
	[AiForderungPeriodischID] [int] IDENTITY(1,1) NOT NULL,
	[AiForderungID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[Bemerkung] [varchar](1024) NULL,
	[IsMaxBetragConfirmed] [bit] NOT NULL CONSTRAINT [DF_tdfKissAiForderungPeriodisch_IsMaxBetragConfirmed]  DEFAULT (0),
	[AiForderungPeriodischTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiForderungPeriodisch] PRIMARY KEY NONCLUSTERED 
(
	[AiForderungPeriodischID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiForderungPeriodisch] ON [dbo].[OLD_30_AiForderungPeriodisch] 
(
	[AiForderungID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiForderungPeriodisch]  WITH CHECK ADD  CONSTRAINT [FK_AiForderungPeriodisch_AiForderung] FOREIGN KEY([AiForderungID])
REFERENCES [OLD_30_AiForderung] ([AiForderungID])
GO