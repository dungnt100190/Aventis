/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this template to add a new table with default columns. 
           Replace the following tags:
           ----
           - Replace <TableFile> with the filegroup of the new table (e.g. DATEN1, PRIMARY, ...)
           ----
           - Replace <Author> with your "Firstname LastName"
           - Replace <TableDesc> with the description/purpose of the table
           - Replace <UsedIn> with the list of modules the table is used in
=================================================================================================*/

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_PADDING ON;
GO

-------------------------------------------------------------------------------
-- table structure
-------------------------------------------------------------------------------
CREATE TABLE [dbo].[KbuErwarteteEinnahmeAusgleich](
  [KbuErwarteteEinnahmeAusgleichID] [int] IDENTITY(1, 1) NOT NULL,
  [KbuBelegID] [int] NOT NULL,
  [WshPositionID] [int] NOT NULL,  -- NULLABLE, sobald ein weiterer FK zu einer erwarteten Einnahme dazukommt -> constraint
  [Betrag] [money] NOT NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KbuErwarteteEinnahmeAusgleichTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuErwarteteEinnahmeAusgleich] PRIMARY KEY CLUSTERED 
(
  [KbuErwarteteEinnahmeAusgleichID] ASC
)WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [DATEN1]
) ON [DATEN1];
GO

-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
-- table
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Mathias Minder' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Zuordnung von Zahlungseingängen zu erwarteten Einnahmen' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'KBU,WSH' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'KbuErwarteteEinnahmeAusgleichID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Der Beleg, welcher den Zahlungseingang verbucht. Dieser hat wiederum einen FK auf den Zahlungseingang' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'KbuBelegID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Die erwartete Einnahme aus einem WSH-Budget' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'WshPositionID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Der ausgeglichene Betrag' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'Betrag';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuErwarteteEinnahmeAusgleich', 
                                @level2type = N'COLUMN', @level2name = N'KbuErwarteteEinnahmeAusgleichTS';
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich] ADD CONSTRAINT [DF_KbuErwarteteEinnahmeAusgleich_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich] ADD CONSTRAINT [DF_KbuErwarteteEinnahmeAusgleich_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO


-------------------------------------------------------------------------------
-- foreign keys
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbuErwarteteEinnahmeAusgleich_KbuBeleg] FOREIGN KEY([KbuBelegID])
REFERENCES [dbo].[KbuBeleg] ([KbuBelegID])
GO

ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich] CHECK CONSTRAINT [FK_KbuErwarteteEinnahmeAusgleich_KbuBeleg]
GO

ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbuErwarteteEinnahmeAusgleich_WshPosition] FOREIGN KEY([WshPositionID])
REFERENCES [dbo].[WshPosition] ([WshPositionID])
GO

ALTER TABLE [dbo].[KbuErwarteteEinnahmeAusgleich] CHECK CONSTRAINT [FK_KbuErwarteteEinnahmeAusgleich_WshPosition]
GO

-------------------------------------------------------------------------------
-- indices
-------------------------------------------------------------------------------
CREATE NONCLUSTERED INDEX [IX_KbuErwarteteEinnahmeAusgleich_KbuBelegID] ON [dbo].[KbuErwarteteEinnahmeAusgleich] 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

CREATE NONCLUSTERED INDEX [IX_KbuErwarteteEinnahmeAusgleich_WshPositionID] ON [dbo].[KbuErwarteteEinnahmeAusgleich] 
(
	[WshPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO
