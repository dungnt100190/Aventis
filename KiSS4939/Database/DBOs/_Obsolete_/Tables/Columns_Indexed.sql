CREATE TABLE [dbo].[Columns_Indexed](
	[Table_Name] [varchar](128) NOT NULL,
	[Column_Name] [varchar](128) NOT NULL,
	[Indexed] [char](1) NOT NULL DEFAULT ('N')
) ON [PRIMARY]

GO