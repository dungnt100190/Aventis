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
CREATE TABLE [dbo].[XDeleteRule](
  [XDeleteRuleID] [int] IDENTITY(1, 1) NOT NULL,
  [TableName] [varchar](128) NOT NULL,
  [ColumnName] [varchar](128) NOT NULL,
  [XDeleteRuleCode] [int] NOT NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [XDeleteRuleTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDeleteRule] PRIMARY KEY CLUSTERED 
(
  [XDeleteRuleID] ASC
)WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
GO

-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
-- table
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Thomas Abegglen' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Definiert die Regel, die bei einer globalen Lösch-Operation angewendet werden soll. Vergleichbar mit der Delete_Rule bei einem Foreign Key im DB-Schema.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'KiSS Core' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'XDeleteRuleID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Der Name der Tabelle für die diese Regel gilt.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'TableName';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Der Name der FK-Spalte für die diese Regel gilt.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'ColumnName';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Code der die anzuwendende Regel definiert.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'XDeleteRuleCode';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'XDeleteRule', 
                                @level2type = N'COLUMN', @level2name = N'XDeleteRuleTS';
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[XDeleteRule] ADD CONSTRAINT [DF_XDeleteRule_XDeleteRuleCode] DEFAULT (0) FOR [XDeleteRuleCode];
GO

ALTER TABLE [dbo].[XDeleteRule] ADD CONSTRAINT [DF_XDeleteRule_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[XDeleteRule] ADD CONSTRAINT [DF_XDeleteRule_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO