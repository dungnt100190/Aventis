CREATE TABLE [dbo].[Index_Information](
	[tablename] [varchar](128) NOT NULL,
	[index_name] [varchar](128) NOT NULL,
	[index_description] [varchar](210) NULL,
	[Index_keys] [varchar](2048) NULL
) ON [PRIMARY]

GO