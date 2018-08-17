CREATE TABLE [dbo].[XConfig](
	[DBName] [varchar](50) NOT NULL,
	[XConfigID] [int] NOT NULL,
	[XNamespaceExtensionID] [int] NULL,
	[KeyPath] [varchar](500) NOT NULL,
	[System] [bit] NOT NULL,
	[DatumVon] [datetime] NULL,
	[ValueCode] [int] NOT NULL,
	[LOVName] [varchar](100) NULL,
	[Description] [varchar](1000) NULL,
	[ValueBit] [bit] NULL,
	[OriginalValueBit] [bit] NULL,
	[ValueDateTime] [datetime] NULL,
	[OriginalValueDateTime] [datetime] NULL,
	[ValueDecimal] [decimal](19, 4) NULL,
	[OriginalValueDecimal] [decimal](19, 4) NULL,
	[ValueInt] [int] NULL,
	[OriginalValueInt] [int] NULL,
	[ValueMoney] [money] NULL,
	[OriginalValueMoney] [money] NULL,
	[ValueVarchar] [varchar](max) NULL,
	[OriginalValueVarchar] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XConfigTS] [timestamp] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XConfig Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'XConfigID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XNamespaceExtension.XNamespaceExtensionID, Verweis auf die NamespaceExtension für den jeweiligen XConfig-Eintrag. Wenn gesetzt, wird der Eintrag nur für diesen Namespace verwendet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'XNamespaceExtensionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Konfigurationspfad, welcher als primäre Identifikation des Konfigurationswert dient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'KeyPath'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Config-Eintrag nur für BIAG Administratoren sichtbar und editierbar ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, ab wann ein Konfigurationswert gültig ist (kann mehrere gleiche KeyPath haben, wobei immer nur einer gültig sein kann)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datentyp des Eintrags (LOV ConfigValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der LOV, falls ValueCode = CSV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'LOVName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des Konfigurationswertes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Bit/Bool-Wert (ValueCode 5)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueBit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale Bit-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueBit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der DateTime-Wert (ValueCode 6)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueDateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale DateTime-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueDateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Decimal-Wert (ValueCode 3)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueDecimal'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale Decimal-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueDecimal'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Int-Wert (ValueCode 2)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueInt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale Int-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueInt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Money-Wert (ValueCode 4)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale Money-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueMoney'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Varchar-Wert (ValueCode 1; 7-11)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'ValueVarchar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der originale Varchar-Wert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'OriginalValueVarchar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XConfig', @level2type=N'COLUMN',@level2name=N'XConfigTS'
GO

ALTER TABLE [dbo].[XConfig] ADD  CONSTRAINT [DF_XConfig_System]  DEFAULT ((0)) FOR [System]
GO

ALTER TABLE [dbo].[XConfig] ADD  CONSTRAINT [DF_XConfig_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XConfig] ADD  CONSTRAINT [DF_XConfig_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
