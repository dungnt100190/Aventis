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
CREATE TABLE [dbo].[SstPscdBelegPosition](
  [SstPscdBelegPositionID] [int] IDENTITY(1, 1) NOT NULL,
  [KbuBelegPositionID] [int] NOT NULL,
  [Sachkonto] [varchar](10) NOT NULL,
  [Innenauftrag] [varchar](12) NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [SstPscdBelegPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstPscdBelegPosition] PRIMARY KEY CLUSTERED 
(
  [SstPscdBelegPositionID] ASC
)WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [DATEN1],
 CONSTRAINT [UK_SstPscdBelegPositionID_KbuBelegPositionID] UNIQUE NONCLUSTERED 
(
	[KbuBelegPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1];
GO

-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
-- table
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Mathias Minder' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'PSCD-Attribute von Belegpositionen' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'SST/KBU' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'SstPscdBelegPositionID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Buchungsposition, die attributiert wird' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'KbuBelegPositionID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Sachkonto' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Sachkonto';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'SAP-Innenauftrag' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Innenauftrag';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'SstPscdBelegPosition', 
                                @level2type = N'COLUMN', @level2name = N'SstPscdBelegPositionTS';
GO

-------------------------------------------------------------------------------
-- foreign keys
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[SstPscdBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_SstPscdBelegPosition_KbuBelegPosition] FOREIGN KEY([KbuBelegPositionID])
REFERENCES [dbo].[KbuBelegPosition] ([KbuBelegPositionID])
GO

ALTER TABLE [dbo].[SstPscdBelegPosition] CHECK CONSTRAINT [FK_SstPscdBelegPosition_KbuBelegPosition]
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[SstPscdBelegPosition] ADD CONSTRAINT [DF_SstPscdBelegPosition_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[SstPscdBelegPosition] ADD CONSTRAINT [DF_SstPscdBelegPosition_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO