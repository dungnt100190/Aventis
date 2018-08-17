CREATE TABLE [dbo].[KaBetrieb](
	[KaBetriebID] [int] IDENTITY(1,1) NOT NULL,
	[BetriebName] [varchar](100) NOT NULL,
	[OrganisationTypCode_OBSOLETE] [int] NULL,
	[DmgAdresseID_OBSOLETE] [int] NULL,
	[Telefon] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[SprachCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Aktiv] [bit] NOT NULL,
	[Homepage] [varchar](100) NULL,
	[KontaktPerson_OBSOLETE] [varchar](150) NULL,
	[KaBetriebTS] [timestamp] NOT NULL,
	[TeilbetriebID] [int] NULL,
	[CharakterCode] [int] NULL,
	[InAusbildungsverbund] [bit] NULL,
	[MigrationKA] [int] NULL,
 CONSTRAINT [PK_KaBetrieb] PRIMARY KEY CLUSTERED 
(
	[KaBetriebID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaBetrieb_BetriebName] ON [dbo].[KaBetrieb] 
(
	[BetriebName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaBetrieb Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaBetrieb', @level2type=N'COLUMN',@level2name=N'KaBetriebID'
GO

ALTER TABLE [dbo].[KaBetrieb] ADD  CONSTRAINT [DF_KaBetrieb_Aktiv]  DEFAULT ((1)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[KaBetrieb] ADD  CONSTRAINT [DF_KaBetrieb_InAusbildungsverbund]  DEFAULT ((0)) FOR [InAusbildungsverbund]
GO

ALTER TABLE [dbo].[KaBetrieb] ADD  CONSTRAINT [DF_KaBetrieb_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO