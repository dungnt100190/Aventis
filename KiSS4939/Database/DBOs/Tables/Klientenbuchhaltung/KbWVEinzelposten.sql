CREATE TABLE [dbo].[KbWVEinzelposten] (
	[KbWVEinzelpostenID] [int] IDENTITY (1, 1) NOT NULL ,
	[StorniertKbWVEinzelpostenID] [int] NULL ,
	[KbWVLaufID] [int] NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[BaWVCodeID] [int] NOT NULL ,
	[BaWVCode] [int] NOT NULL ,
	[KbBuchungKostenartID] [int] NOT NULL ,
	[KbKostenstelleID] [int] NOT NULL ,
	[BgKostenartID] [int] NULL ,
	[BgSplittingArtCode] [int] NOT NULL ,
	[Betrag] [money] NOT NULL ,
	[DatumVon] [datetime] NOT NULL ,
	[DatumBis] [datetime] NOT NULL ,
	[SplittingDurchWVLaufDatumBis] [bit] NOT NULL CONSTRAINT [DF_KbWVEinzelposten_AbgeschnittenDurchWVLauf] DEFAULT ((0)),
	[KbWVEinzelpostenStatusCode] [int] NOT NULL ,
	[Fakturiert] [bit] NOT NULL CONSTRAINT [DF_KbWVEinzelposten_Fakturiert] DEFAULT ((0)),
	[Ungueltig] [bit] NOT NULL CONSTRAINT [DF_KbWVEinzelposten_Ungueltig] DEFAULT ((0)),
	[Buchungstext] [varchar] (200) NULL ,
	[HeimatkantonNr] [varchar] (50) NULL ,
	[WohnKantonNr] [varchar] (50) NULL ,
	[KantonKuerzel] [varchar] (50) NULL ,
	[Auslandschweizer] [bit] NULL ,
	[Bemerkungen] [varchar] (2000) NULL ,
	[KbWVEinzelpositionTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbWVEinzelposten] PRIMARY KEY  Clustered
	(
		[KbWVEinzelpostenID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KbWVEinzelposten_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_BaWVCode] FOREIGN KEY
	(
		[BaWVCodeID]
	) REFERENCES [dbo].[BaWVCode] (
		[BaWVCodeID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_BgKostenart] FOREIGN KEY
	(
		[BgKostenartID]
	) REFERENCES [dbo].[BgKostenart] (
		[BgKostenartID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_KbBuchungKostenart] FOREIGN KEY
	(
		[KbBuchungKostenartID]
	) REFERENCES [dbo].[KbBuchungKostenart] (
		[KbBuchungKostenartID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_KbKostenstelle] FOREIGN KEY
	(
		[KbKostenstelleID]
	) REFERENCES [dbo].[KbKostenstelle] (
		[KbKostenstelleID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_KbWVEinzelposten] FOREIGN KEY
	(
		[StorniertKbWVEinzelpostenID]
	) REFERENCES [dbo].[KbWVEinzelposten] (
		[KbWVEinzelpostenID]
	),
	CONSTRAINT [FK_KbWVEinzelposten_KbWVLauf] FOREIGN KEY
	(
		[KbWVLaufID]
	) REFERENCES [dbo].[KbWVLauf] (
		[KbWVLaufID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_StorniertKbWVEinzelpostenID] ON [dbo].[KbWVEinzelposten]([StorniertKbWVEinzelpostenID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_KbWVLaufID] ON [dbo].[KbWVEinzelposten]([KbWVLaufID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_BaPersonID] ON [dbo].[KbWVEinzelposten]([BaPersonID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_BaWVCodeID] ON [dbo].[KbWVEinzelposten]([BaWVCodeID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_KbBuchungKostenartID] ON [dbo].[KbWVEinzelposten]([KbBuchungKostenartID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_KbKostenstelleID] ON [dbo].[KbWVEinzelposten]([KbKostenstelleID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_KbWVEinzelposten_BgKostenartID] ON [dbo].[KbWVEinzelposten]([BgKostenartID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbWVEinzelposten Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'KbWVEinzelpostenID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_KbWVEinzelposten) => KbWVEinzelposten.KbWVEinzelpostenID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'StorniertKbWVEinzelpostenID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_KbWVLauf) => KbWVLauf.KbWVLaufID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'KbWVLaufID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'BaPersonID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_BaWVCode) => BaWVCode.BaWVCodeID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'BaWVCodeID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_KbBuchungKostenart) => KbBuchungKostenart.KbBuchungKostenartID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'KbBuchungKostenartID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_KbKostenstelle) => KbKostenstelle.KbKostenstelleID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'KbKostenstelleID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelposten_BgKostenart) => BgKostenart.BgKostenartID', N'user', N'dbo', N'table', N'KbWVEinzelposten', N'column', N'BgKostenartID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
