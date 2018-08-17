CREATE TABLE [dbo].[Hist_BDESollStundenProJahr_XUser](
  [BDESollStundenProJahr_XUserID] [int] NOT NULL,
  [UserID] [int] NOT NULL,
  [Jahr] [int] NOT NULL,
  [JanuarStd] [money] NOT NULL,
  [FebruarStd] [money] NOT NULL,
  [MaerzStd] [money] NOT NULL,
  [AprilStd] [money] NOT NULL,
  [MaiStd] [money] NOT NULL,
  [JuniStd] [money] NOT NULL,
  [JuliStd] [money] NOT NULL,
  [AugustStd] [money] NOT NULL,
  [SeptemberStd] [money] NOT NULL,
  [OktoberStd] [money] NOT NULL,
  [NovemberStd] [money] NOT NULL,
  [DezemberStd] [money] NOT NULL,
  [TotalStd] [money] NOT NULL,
  [ManualEdit] [bit] NOT NULL,
  [VerID] [int] NOT NULL,
  [VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BDESollStundenProJahr_XUser] PRIMARY KEY CLUSTERED 
(
  [BDESollStundenProJahr_XUserID] ASC,
  [VerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO