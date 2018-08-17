CREATE TABLE [dbo].[OLD_30_ShNrmVerrechnungsbasis](
	[ShNrmVerrechnungsbasisID] [int] IDENTITY(1,1) NOT NULL,
	[NrmKontoCode] [int] NOT NULL,
	[NrmVerrechnungsbasisCode] [int] NOT NULL,
	[ShNrmVerrechnungsbasisTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShNrmVerrechnungsbasis] PRIMARY KEY CLUSTERED 
(
	[ShNrmVerrechnungsbasisID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO