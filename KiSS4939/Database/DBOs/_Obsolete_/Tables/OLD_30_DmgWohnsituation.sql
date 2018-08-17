CREATE TABLE [dbo].[OLD_30_DmgWohnsituation](
	[DmgWohnsituationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[WohnsituationTypCode] [int] NOT NULL,
	[WohnsituationStatusCode] [int] NULL,
	[WohnsituationSizeCode] [int] NULL,
	[DmgAdresseID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[DmgMietvertragID] [int] NULL,
	[Bemerkung] [varchar](7000) NULL,
	[DmgWohnsituationTS] [timestamp] NOT NULL,
	[VerID] [int] NULL,
 CONSTRAINT [PK_DmgWohnsituation] PRIMARY KEY NONCLUSTERED 
(
	[DmgWohnsituationID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE UNIQUE CLUSTERED INDEX [IX_DmgWohnsituation] ON [dbo].[OLD_30_DmgWohnsituation] 
(
	[BaPersonID] ASC,
	[WohnsituationTypCode] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_DmgWohnsituation]  WITH CHECK ADD  CONSTRAINT [FK_DmgWohnsituation_DmgAdresse] FOREIGN KEY([DmgAdresseID])
REFERENCES [OLD_30_DmgAdresse] ([DmgAdresseID])
GO