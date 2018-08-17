CREATE TABLE [dbo].[BaPerson_NewodPerson] (
	[BaPersonID] [int] NOT NULL ,
	[NewodPersonID] [int] NOT NULL ,
	[AuslaenderAktiveSozialhilfe] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_AS] DEFAULT ((0)),
	[SchweizerAktiveSozialhilfe] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_CHS] DEFAULT ((0)),
	[SchweizerAktiveVormundschaft] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_CHV] DEFAULT ((0)),
	[Aktualisiert] [datetime] NULL ,
	CONSTRAINT [UQ_BaPerson_NewodPerson_BaPerson] Unique  NONCLUSTERED
	(
		[BaPersonID]
	)  ON [PRIMARY] ,
	CONSTRAINT [UQ_BaPerson_NewodPerson_NewodPerson] Unique  NONCLUSTERED
	(
		[NewodPersonID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_BaPerson_NewodPerson_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
