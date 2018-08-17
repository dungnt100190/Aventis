CREATE TABLE [dbo].[MigMessage](
	[MigMessageID] [int] IDENTITY(1,1) NOT NULL,
	[MigMessageTypeID] [int] NOT NULL,
	[MigHerkunftCode] [int] NULL,
	[FallNrAlt] [int] NULL,
	[PersonNrAlt] [int] NULL,
	[ExpPerson] [int] NULL,
	[ExpLeistung] [int] NULL,
	[ExpMitarbeiterID] [int] NULL,
	[ExpMitarbeiter] [varchar](20) NULL,
	[ExpValue1] [varchar](500) NULL,
	[ExpValue2] [varchar](500) NULL,
	[ExpValue3] [varchar](500) NULL,
	[ExpValue4] [varchar](500) NULL,
	[ExpValue5] [varchar](500) NULL,
	[ExpValue6] [varchar](500) NULL,
	[ExpValue7] [varchar](500) NULL,
	[ExpValue8] [varchar](500) NULL,
	[ExpValue9] [varchar](500) NULL,
	[ExpValue10] [varchar](500) NULL,
	[ExpValue11] [varchar](500) NULL,
	[FaFallID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[MigLeistungID] [int] NULL,
	[MigAlteFallNr] [int] NULL,
	[BaPersonID] [int] NULL,
	[UserID] [int] NULL,
	[OrgUnitID] [int] NULL,
 CONSTRAINT [PK_MigMessage] PRIMARY KEY CLUSTERED 
(
	[MigMessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON