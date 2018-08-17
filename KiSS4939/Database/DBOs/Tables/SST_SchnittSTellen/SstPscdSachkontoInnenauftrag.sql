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
CREATE TABLE [dbo].[SstPscdSachkontoInnenauftrag](
  [SstPscdSachkontoInnenauftragID] [int] IDENTITY(1, 1) NOT NULL,
  [KbuKontoID] [int] NOT NULL, 
  [Sachkonto] [varchar](10) NULL,
  [SachkontoErtragOhneGeldfluss] [varchar](10) NULL,
  [Innenauftrag] [varchar](12) NULL,
  [InnenauftragErtragOhneGeldfluss] [varchar](12) NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [SstPscdSachkontoInnenauftragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstPscdSachkontoInnenauftrag] PRIMARY KEY CLUSTERED 
(
  [SstPscdSachkontoInnenauftragID] ASC
)WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [DATEN3],
 CONSTRAINT [UK_SstPscdSachkontoInnenauftrag_KbuKontoID] UNIQUE NONCLUSTERED 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
)
 ON [DATEN3];
GO

-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
-- table
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Mathias Minder' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'PSCD-Attribute eines KbuKontos' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'SST/KBU' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'SstPscdSachkontoInnenauftragID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'KbuKonto, zu dem die Attribute gehören' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'KbuKontoID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Sachkonto für Ausgaben und Einnahmen mit Geldfluss',
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Sachkonto';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Sachkonto für Einnahmen ohne Geldfluss (z.B. nicht an SD abgetretene Einnahmen, Verrechnungen)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'SachkontoErtragOhneGeldfluss';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Innenauftrag für Ausgaben und Einnahmen mit Geldfluss)', 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Innenauftrag';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Innenauftrag für Einnahmen ohne Geldfluss',
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'InnenauftragErtragOhneGeldfluss';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdSachkontoInnenauftrag', 
                                @level2type = N'COLUMN', @level2name = N'SstPscdSachkontoInnenauftragTS';
GO


-------------------------------------------------------------------------------
-- foreign keys
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[SstPscdSachkontoInnenauftrag]  WITH CHECK ADD  CONSTRAINT [FK_SstPscdSachkontoInnenauftrag_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[SstPscdSachkontoInnenauftrag] CHECK CONSTRAINT [FK_SstPscdSachkontoInnenauftrag_KbuKonto]
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[SstPscdSachkontoInnenauftrag] ADD CONSTRAINT [DF_SstPscdSachkontoInnenauftrag_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[SstPscdSachkontoInnenauftrag] ADD CONSTRAINT [DF_SstPscdSachkontoInnenauftrag_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO