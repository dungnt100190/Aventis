CREATE TABLE [dbo].[Import_ZkbKonto2](
	[ZkbKontoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Vorname] [varchar](50) NULL,
	[Geburtsdatum] [datetime] NULL,
	[ZkbKontoNr] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[ZIPNr] [int] NULL,
	[Invalid] [bit] NOT NULL CONSTRAINT [DF_Import_ZkbKonto2_Invalid]  DEFAULT ((0)),
 CONSTRAINT [PK_Import_ZkbKonto2] PRIMARY KEY CLUSTERED 
(
	[ZkbKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON