GO
IF EXISTS (SELECT * FROM sys.xml_schema_collections WHERE name = 'ASVS_SchemaCollection' ) BEGIN
  DROP XML SCHEMA COLLECTION ASVS_SchemaCollection
END
CREATE XML SCHEMA COLLECTION ASVS_SchemaCollection AS
-- Das vorgeschlagene UTF-8 encoding ist wird nicht unterstützt (nur UTF16).
-- encoding="UTF-8"
N'<?xml version="1.0"?>
<schema attributeFormDefault="unqualified" elementFormDefault="qualified"
    targetNamespace="http://asvs.jgk.be.ch/schemas/evok/20090708/SozialhilfeMeldungImport"
    xmlns="http://www.w3.org/2001/XMLSchema"
    xmlns:tns="http://asvs.jgk.be.ch/schemas/evok/20090708/SozialhilfeMeldungImport">
    <element name="SozialfallMeldungen" type="tns:SozialfallMeldungen">
        <annotation>
            <documentation>Basis-Element der Meldungen</documentation>
        </annotation>
    </element>
    <complexType name="SozialfallMeldungen">
        <annotation>
            <documentation>Basis-Typ</documentation>
        </annotation>
        <choice maxOccurs="1" minOccurs="1">
            <sequence maxOccurs="1" minOccurs="1">
                <element maxOccurs="unbounded" minOccurs="1" name="Sozialfall" type="tns:Sozialfall">
                    <annotation>
                        <documentation>Sozialfall</documentation>
                    </annotation>
                </element>
            </sequence>
        </choice>
    </complexType>
    <complexType name="Sozialfall">
        <sequence>
            <element maxOccurs="1" minOccurs="1" name="UserIdErstellt" type="string"> </element>
            <element maxOccurs="1" minOccurs="1" name="TimestampErstellt" type="dateTime"> </element>
            <element maxOccurs="unbounded" minOccurs="1" name="Mitglieder" type="tns:Person">
                <annotation>
                    <documentation> Mitglieder der Haushaltstruktur </documentation>
                </annotation>
            </element>
        </sequence>
    </complexType>
    <complexType name="Person">
        <annotation>
            <documentation> Person der Haushaltstruktur </documentation>
        </annotation>
        <sequence>
            <element maxOccurs="1" minOccurs="1" name="Name" type="string"> </element>
            <element maxOccurs="1" minOccurs="1" name="Vorname" type="string"> </element>
            <element maxOccurs="1" minOccurs="0" name="Strasse" type="string"> </element>
            <element maxOccurs="1" minOccurs="1" name="Postleitzahl" type="int"> </element>
            <element maxOccurs="1" minOccurs="1" name="Wohnort" type="string"> </element>
            <element maxOccurs="1" minOccurs="1" name="NeueVersichertenNummer">
                <simpleType>
                    <restriction base="string">
                        <pattern value="\d{3}\.\d{4}\.\d{4}\.\d{2}"/>
                    </restriction>
                </simpleType>
            </element>
            <element maxOccurs="1" minOccurs="1" name="Geburtsdatum" type="date"> </element>
            <element maxOccurs="1" minOccurs="1" name="BeginnSozialhilfe" type="date"> </element>
            <element maxOccurs="1" minOccurs="1" name="EndeSozialhilfe" type="date"> </element>
        </sequence>
    </complexType>
</schema>
'
GO