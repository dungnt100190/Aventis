 -- Bis Release 4.1.39 nur iBE
 CREATE TABLE [dbo].[BaKopfquote] (
	[BaKopfquoteID] [int] IDENTITY (1, 1) NOT NULL ,
	[BaPersonID] [int] NULL ,
	[RechnungDatum] [datetime] NOT NULL ,
	[Betrag] [money] NULL ,
	[Zeitspanne] [varchar] (200) NULL ,
	[Bemerkung] [nchar] (500) NULL ,
	[BaKopfquoteTS] [timestamp] NULL ,
	CONSTRAINT [PK_BaKopfquote] PRIMARY KEY  Clustered
	(
		[BaKopfquoteID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_BaKopfquote_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	)
) ON [PRIMARY]
GO
