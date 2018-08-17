CREATE TABLE [dbo].[NewodPerson](
	[NewodPersonID] [int] NOT NULL,
	[Vorname] [varchar](100) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[AHVNummer] [varchar](20) NOT NULL,
	[Versichertennummer] [varchar](20) NOT NULL,
	[GeburtsdatumString] [varchar](50) NOT NULL,
	[Geburtsdatum] [datetime] NULL,
	[Strasse] [varchar](60) NOT NULL,
	[HausNr] [varchar](10) NOT NULL,
	[HausNrZusatz] [varchar](10) NOT NULL,
	[PLZ] [varchar](10) NOT NULL,
	[Ort] [varchar](60) NOT NULL,
 CONSTRAINT [PK_NewodPerson] PRIMARY KEY CLUSTERED 
(
	[NewodPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO