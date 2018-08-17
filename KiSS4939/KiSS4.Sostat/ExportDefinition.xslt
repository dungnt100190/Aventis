<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:z='#RowsetSchema'>

<xsl:output method="xml"/>

<xsl:template name="Content" match="AnyThing">
	<xsl:for-each select="./@*">
		<xsl:attribute name="{name()}" />
	</xsl:for-each>
	<xsl:for-each select='./*'>
		<xsl:if test="(name()!='z:row' and name()!='dossier') or position()=1">
			<xsl:element name='{name()}'>
				<xsl:call-template name='Content'/>
			</xsl:element>
		</xsl:if>
	</xsl:for-each>
</xsl:template>


<xsl:template match="/xml">
	<xml xmlns:z='#RowsetSchema'>
	<xsl:call-template name='Content'/>
	</xml>
</xsl:template>

</xsl:stylesheet>