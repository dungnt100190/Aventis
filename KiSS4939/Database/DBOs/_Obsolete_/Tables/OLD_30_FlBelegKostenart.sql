CREATE TABLE [dbo].[OLD_30_FlBelegKostenart](
	[FlBelegKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[FlBelegID] [int] NOT NULL,
	[FlKostenartID] [int] NOT NULL,
	[Intern] [varchar](120) NULL,
	[FlBelegKostenartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlBelegKostenart] PRIMARY KEY NONCLUSTERED 
(
	[FlBelegKostenartID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_FlBelegKostenart] ON [dbo].[OLD_30_FlBelegKostenart] 
(
	[FlBelegID] ASC
) ON [PRIMARY]
GO