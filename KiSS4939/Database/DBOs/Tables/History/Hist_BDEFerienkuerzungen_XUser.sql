CREATE TABLE [dbo].[Hist_BDEFerienkuerzungen_XUser](
	[UserID] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[FerienkuerzungStd] [money] NOT NULL,
	[ManualEdit] [bit] NOT NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BDEFerienkuerzungen_XUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[Jahr] ASC,
	[VerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO