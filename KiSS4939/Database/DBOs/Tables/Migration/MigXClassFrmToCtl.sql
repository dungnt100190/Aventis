

CREATE TABLE [dbo].[MigXClassFrmToCtl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [varchar](255) NOT NULL,
	[ControlName] [varchar](255) NOT NULL,
  [IsFormClassItemInKiSS5] BIT NOT NULL -- bedeutet dass während der Migration KiSS4ToKiSS5 der xClass Eintrag bleiben wird
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


