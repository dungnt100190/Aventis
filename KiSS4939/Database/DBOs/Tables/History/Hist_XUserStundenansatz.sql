CREATE TABLE [dbo].[Hist_XUserStundenansatz](
	[XUserStundenansatzID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Lohnart1] [money] NULL,
	[Lohnart2] [money] NULL,
	[Lohnart3] [money] NULL,
	[Lohnart4] [money] NULL,
	[Lohnart5] [money] NULL,
	[Lohnart6] [money] NULL,
	[Lohnart7] [money] NULL,
	[Lohnart8] [money] NULL,
	[Lohnart9] [money] NULL,
	[Lohnart10] [money] NULL,
	[Lohnart11] [money] NULL,
	[Lohnart12] [money] NULL,
	[Lohnart13] [money] NULL,
	[Lohnart14] [money] NULL,
	[Lohnart15] [money] NULL,
	[Lohnart16] [money] NULL,
	[Lohnart17] [money] NULL,
	[Lohnart18] [money] NULL,
	[Lohnart19] [money] NULL,
	[Lohnart20] [money] NULL,
	[VerID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_XUserStundenansatz] PRIMARY KEY CLUSTERED 
(
	[XUserStundenansatzID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_XUserStundenansatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die History-Stundenansätze für die Benutzer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_XUserStundenansatz'
GO
