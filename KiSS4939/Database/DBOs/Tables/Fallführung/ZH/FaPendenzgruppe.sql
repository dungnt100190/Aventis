CREATE TABLE [dbo].[FaPendenzgruppe](
	[FaPendenzgruppeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Beschreibung] [varchar](500) NULL,
	[FaPendenzgruppeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaPendenzgruppe] PRIMARY KEY CLUSTERED 
(
	[FaPendenzgruppeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON