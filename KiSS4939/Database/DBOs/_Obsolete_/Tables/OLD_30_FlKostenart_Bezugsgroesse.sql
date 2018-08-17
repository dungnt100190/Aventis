CREATE TABLE [dbo].[OLD_30_FlKostenart_Bezugsgroesse](
	[FlKostenartID] [int] NOT NULL,
	[FlBezugsgroesseID] [int] NOT NULL,
	[FlKostenart_BezugsgroesseTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlKostenart_Bezugsgroesse] PRIMARY KEY CLUSTERED 
(
	[FlKostenartID] ASC,
	[FlBezugsgroesseID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OLD_30_FlKostenart_Bezugsgroesse]  WITH CHECK ADD  CONSTRAINT [FK_tcoKissFbBezugsgroesseVsKostenart_tcoKissFbBezugsgroesse] FOREIGN KEY([FlBezugsgroesseID])
REFERENCES [OLD_30_FlBezugsgroesse] ([FlBezugsgroesseID])
GO

ALTER TABLE [dbo].[OLD_30_FlKostenart_Bezugsgroesse] CHECK CONSTRAINT [FK_tcoKissFbBezugsgroesseVsKostenart_tcoKissFbBezugsgroesse]
GO