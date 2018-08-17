CREATE TABLE [dbo].[BaPerson_NewodPerson] (
	[BaPersonID] [int] NOT NULL ,
	[NewodPersonID] [int] NOT NULL ,
	[AS] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_AS] DEFAULT ((0)),
	[CHS] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_CHS] DEFAULT ((0)),
	[CHV] [bit] NOT NULL CONSTRAINT [DF_BaPerson_NewodPerson_CHV] DEFAULT ((0)),
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
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_BaPerson_NewodPerson_NewodPerson] FOREIGN KEY
	(
		[NewodPersonID]
	) REFERENCES [dbo].[NewodPerson] (
		[NewodPersonID]
	)
) ON [PRIMARY]
GO
