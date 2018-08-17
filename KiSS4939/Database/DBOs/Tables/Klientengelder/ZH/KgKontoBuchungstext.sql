/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
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
CREATE TABLE [dbo].[KgKontoBuchungstext](
  [KgKontoBuchungstextID] [int] IDENTITY(1, 1) NOT NULL,
  [KontoNr] [varchar](10) NOT NULL,
  [Buchungstext] [varchar](100) NOT NULL,
  [IsDefault] [bit] NOT NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KgKontoBuchungstextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgKontoBuchungstext] PRIMARY KEY CLUSTERED 
(
  [KgKontoBuchungstextID] ASC
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
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Thomas Abegglen' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Textbausteine für Buchungstexte in Klientengelder-Modul.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'KG' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'KgKontoBuchungstextID';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Konto-Nr des Kontos, für welches dieser Textbaustein gilt.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'KontoNr';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Textbaustein für dieses Konto.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'Buchungstext';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Flag, ob der Textbaustein standardmässig gesetzt werden soll.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'IsDefault';
GO



EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KgKontoBuchungstext', 
                                @level2type = N'COLUMN', @level2name = N'KgKontoBuchungstextTS';
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[KgKontoBuchungstext] ADD  CONSTRAINT [DF_KgKontoBuchungstext_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO

ALTER TABLE [dbo].[KgKontoBuchungstext] ADD CONSTRAINT [DF_KgKontoBuchungstext_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[KgKontoBuchungstext] ADD CONSTRAINT [DF_KgKontoBuchungstext_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO

-------------------------------------------------------------------------------
-- check constraint
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[KgKontoBuchungstext] WITH CHECK ADD  CONSTRAINT [CK_KgKontoBuchungstext_MaxOneDefaultPerKontoNr] CHECK  (([dbo].[fnKgCKKgKontoBuchungstext_MaxOneDefaultPerKontoNr]([KontoNr])=(0)))
GO

ALTER TABLE [dbo].[KgKontoBuchungstext] CHECK CONSTRAINT [CK_KgKontoBuchungstext_MaxOneDefaultPerKontoNr]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks if there is maximum one Buchungstext marked as default per KontoNr.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgKontoBuchungstext', @level2type=N'CONSTRAINT',@level2name=N'CK_KgKontoBuchungstext_MaxOneDefaultPerKontoNr'
GO
