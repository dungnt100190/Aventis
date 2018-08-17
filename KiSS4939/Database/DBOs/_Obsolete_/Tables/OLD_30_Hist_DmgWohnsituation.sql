CREATE TABLE [dbo].[OLD_30_Hist_DmgWohnsituation](
	[DmgWohnsituationID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[WohnsituationTypCode] [int] NOT NULL,
	[WohnsituationStatusCode] [int] NULL,
	[WohnsituationSizeCode] [int] NULL,
	[DmgAdresseID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[DmgMietvertragID] [int] NULL,
	[Bemerkung] [varchar](7000) NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_DmgWohnsituation] PRIMARY KEY CLUSTERED 
(
	[DmgWohnsituationID] ASC,
	[VerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_Hist_DmgWohnsituation] ON [dbo].[OLD_30_Hist_DmgWohnsituation] 
(
	[BaPersonID] ASC,
	[WohnsituationTypCode] ASC,
	[VerID] ASC
) ON [PRIMARY]
GO