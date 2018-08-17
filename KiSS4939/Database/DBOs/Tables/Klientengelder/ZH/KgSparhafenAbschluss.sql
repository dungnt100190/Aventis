CREATE TABLE [dbo].[KgSparhafenAbschluss](
	[KgSparhafenAbschlussID] [int] IDENTITY(1,1) NOT NULL,
	[KtoNr] [varchar](20) NULL,
	[Klient] [varchar](100) NULL,
	[Geburt] [varchar](10) NULL,
	[BDatum] [datetime] NULL,
	[Text] [varchar](100) NULL,
	[Betrag] [money] NULL,
	[Code] [int] NULL,
	[Name] [varchar](50) NULL,
	[Vorname] [varchar](50) NULL,
	[NameMitUmlaut] [varchar](50) NULL,
	[VornameMitUmlaut] [varchar](50) NULL,
	[Geburtsdatum] [datetime] NULL,
	[Geburtsjahr] [int] NULL,
	[BaPersonID] [int] NULL,
	[TeilKtoNr] [varchar](10) NULL,
	[KgBuchungID] [int] NULL,
	[Fehlermeldung] [varchar](2000) NULL,
	[ungueltig] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[KgSparhafenAbschlussID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON