CREATE TABLE [dbo].[VmPriMa](
	[VmPriMaID] [int] IDENTITY(1,1) NOT NULL,
	[Titel] [varchar](50) NULL,
	[Name] [varchar](100) NOT NULL,
	[Vorname] [varchar](100) NULL,
	[Telefon_P] [varchar](100) NULL,
	[Telefon_G] [varchar](100) NULL,
	[MobilTel] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[Beruf] [varchar](100) NULL,
	[SprachCode] [int] NULL,
	[BankName] [varchar](70) NULL,
	[BankKontoNr] [varchar](50) NULL,
	[Bemerkung] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[VmPriMaTS] [timestamp] NOT NULL,
	[VerID] [int] NULL,
	[AHVNummer] [varchar](16) NULL,
	[Versichertennummer] [varchar](18) NULL,
	[Geburtsdatum] [datetime] NULL,
 CONSTRAINT [PK_VmPriMa] PRIMARY KEY CLUSTERED 
(
	[VmPriMaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmPriMa Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPriMa', @level2type=N'COLUMN',@level2name=N'VmPriMaID'
GO

ALTER TABLE [dbo].[VmPriMa] ADD  CONSTRAINT [DF__VmPrima__IsActiv__2E91A8E5]  DEFAULT ((1)) FOR [IsActive]
GO