CREATE TABLE [dbo].[OLD_30_ShBurgergemeinde](
	[BurgergemeindeID] [int] IDENTITY(1,1) NOT NULL,
	[NameBurgergemeinde] [varchar](100) NOT NULL,
	[Adresse] [varchar](50) NULL,
	[IdOrt] [int] NULL,
	[PLZ] [char](4) NULL,
	[Ort] [varchar](50) NULL,
	[Nummer] [int] NULL,
	[Beitrag] [money] NULL,
	[ShBurgergemeindeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShBurgergemeinde] PRIMARY KEY CLUSTERED 
(
	[BurgergemeindeID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO