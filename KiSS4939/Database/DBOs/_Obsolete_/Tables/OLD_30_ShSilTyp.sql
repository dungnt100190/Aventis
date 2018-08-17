CREATE TABLE [dbo].[OLD_30_ShSilTyp](
	[ShSilTypID] [int] IDENTITY(1,1) NOT NULL,
	[NameInTreeview] [varchar](100) NOT NULL,
	[NameInHeader] [varchar](100) NULL,
	[NameInButtonNew] [varchar](100) NULL,
	[NameInButtonDelete] [varchar](100) NULL,
	[NameInTotalFrame] [varchar](100) NULL,
	[NameInGridColumn] [varchar](100) NULL,
	[IsSkosSil] [bit] NOT NULL CONSTRAINT [DF_ShSilTyp_IsSkosSil]  DEFAULT (1),
	[SortKey] [int] NOT NULL,
	[ShSilTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShSilTyp] PRIMARY KEY CLUSTERED 
(
	[ShSilTypID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO