CREATE TABLE [dbo].[BaBED](
	[BaBedID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Strasse] [varchar](100) NULL,
	[HausNr] [varchar](10) NULL,
	[Postfach] [varchar](50) NULL,
	[PLZ] [varchar](50) NULL,
	[Ort] [varchar](50) NULL,
	[Kanton] [varchar](50) NULL,
	[Kurztext] [varchar](10) NULL,
	[Weiterverrechenbar] [bit] NOT NULL CONSTRAINT [DF_BaBED_Weiterverrechenbar]  DEFAULT ((1)),
	[BaBEDTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaBED] PRIMARY KEY CLUSTERED 
(
	[BaBedID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON