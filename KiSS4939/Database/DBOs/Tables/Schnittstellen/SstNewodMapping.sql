/****** Object:  Table [dbo].[SstNewodMapping]    Script Date: 11/21/2012 16:18:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SstNewodMapping](
	[NewodMappingID] [int] IDENTITY(1,1) NOT NULL,
	[Attribut] [nvarchar](50) NOT NULL,
	[KissWert] [nvarchar](50) NOT NULL,
	[NewodWert] [nvarchar](50) NOT NULL,
	[KissBedeutung] [nvarchar](max) NULL,
	[NewodBedeutung] [nvarchar](max) NULL,
	[NewodAttribut] [nvarchar](50) NULL,
 CONSTRAINT [PK_SstNewodMapping] PRIMARY KEY CLUSTERED 
(
	[NewodMappingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO