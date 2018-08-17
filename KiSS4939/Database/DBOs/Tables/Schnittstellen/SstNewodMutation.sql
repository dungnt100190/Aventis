CREATE TABLE [dbo].[SstNewodMutation](
	[NewodMutationID] [int] IDENTITY(1,1) NOT NULL,
	[NewodNummer] [int] NOT NULL,
	[Data] [varchar](max) NULL,
	[Mutationsart] [varchar](4) NULL,
	[DatumVon] [datetime] NOT NULL,
	[Imported] [datetime] NOT NULL,
	[Processed] [bit] NOT NULL,
 CONSTRAINT [PK_NewodMutation] PRIMARY KEY CLUSTERED 
(
	[NewodMutationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[SstNewodMutation] ADD  CONSTRAINT [DF_NewodMutation_GueltigAb]  DEFAULT (getdate()) FOR [DatumVon]
GO

ALTER TABLE [dbo].[SstNewodMutation] ADD  CONSTRAINT [DF_NewodMutation_ImportDatum]  DEFAULT (getdate()) FOR [Imported]
GO

ALTER TABLE [dbo].[SstNewodMutation] ADD  CONSTRAINT [DF_NewodMutation_Processed]  DEFAULT ((0)) FOR [Processed]
GO


