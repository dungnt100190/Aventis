CREATE TABLE [dbo].[FaPhase] (
	[FaPhaseID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[FaPhaseCode] [int] NOT NULL ,
	[UserID] [int] NULL ,
	[DatumVon] [datetime] NOT NULL ,
	[DatumBis] [datetime] NULL ,
	[AbschlussGrundCode] [int] NULL ,
	[Bemerkung] [text] NULL ,
	[FaPhaseTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaPhase] PRIMARY KEY  Clustered
	(
		[FaPhaseID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_FaPhase_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	),
	CONSTRAINT [FK_FaPhase_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	)
) ON [PRIMARY]
GO
 CREATE  INDEX [IX_FaPhase_FaLeistungID] ON [dbo].[FaPhase]([FaLeistungID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO
 CREATE  INDEX [IX_FaPhase_UserID] ON [dbo].[FaPhase]([UserID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO
