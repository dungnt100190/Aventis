GO
IF EXISTS (SELECT * FROM sys.xml_schema_collections WHERE name = 'IK_SchemaCollection' ) BEGIN
  DROP XML SCHEMA COLLECTION IK_SchemaCollection
END
CREATE XML SCHEMA COLLECTION IK_SchemaCollection AS
-- Das vorgeschlagene UTF-8 encoding ist wird nicht unterstützt (nur UTF16).
-- encoding="UTF-8"
-- Enthält alle IK-Schemas
N'<?xml version="1.0" ?>
<xs:schema xmlns:eCH-0058="http://www.ech.ch/xmlns/eCH-0058/2" xmlns:xs="http://www.w3.org/2001/XMLSchema" targetNamespace="http://www.ech.ch/xmlns/eCH-0058/2" elementFormDefault="qualified" attributeFormDefault="unqualified" version="2.0">
	<xs:annotation>
		<xs:documentation>Ausgabedatum: 28.03.2009</xs:documentation>
	</xs:annotation>
	<xs:complexType name="headerType">
		<xs:sequence>
			<xs:element name="senderId" type="eCH-0058:participantIdType"/>
			<xs:element name="originalSenderID" type="eCH-0058:participantIdType" minOccurs="0"/>
			<xs:element name="declarationLocalReference" type="eCH-0058:declarationLocalReferenceType" minOccurs="0"/>
			<xs:element name="recipientId" type="eCH-0058:participantIdType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="messageId" type="eCH-0058:messageIdType"/>
			<xs:element name="referenceMessageId" type="eCH-0058:messageIdType" minOccurs="0"/>
			<xs:element name="ourBusinessReferenceID" type="eCH-0058:businessReferenceIdType" minOccurs="0"/>
			<xs:element name="yourBusinessReferenceId" type="eCH-0058:businessReferenceIdType" minOccurs="0"/>
			<xs:element name="messageType" type="eCH-0058:messageTypeType"/>
			<xs:element name="subMessageType" type="eCH-0058:subMessageTypeType" minOccurs="0"/>
			<xs:element name="sendingApplication" type="eCH-0058:sendingApplicationType"/>
			<xs:element name="partialDelivery" minOccurs="0">
				<xs:complexType>
					<xs:sequence>
						<xs:element name="uniqueIDBusinessCase" type="eCH-0058:uniqueIDBusinessCaseType"/>
						<xs:element name="totalNumberOfPackages" type="eCH-0058:totalNumberOfPackagesType"/>
						<xs:element name="numberOfActualPackage" type="eCH-0058:numberOfActualPackageType"/>
					</xs:sequence>
				</xs:complexType>
			</xs:element>
			<xs:element name="subject" type="eCH-0058:subjectType" minOccurs="0"/>
			<xs:element name="object" type="xs:anyType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="comment" type="eCH-0058:commentType" minOccurs="0"/>
			<xs:element name="messageDate" type="xs:dateTime"/>
			<xs:element name="initialMessageDate" type="eCH-0058:initialMessageDateType" minOccurs="0"/>
			<xs:element name="eventDate" type="xs:dateTime"/>
			<xs:element name="modificationDate" type="xs:dateTime" minOccurs="0"/>
			<xs:element name="action">
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="2"/>
						<xs:enumeration value="1"/>
						<xs:enumeration value="3"/>
						<xs:enumeration value="4"/>
						<xs:enumeration value="5"/>
						<xs:enumeration value="6"/>
						<xs:enumeration value="7"/>
						<xs:enumeration value="10"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="attachment" type="xs:anyType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="testDeliveryFlag" type="eCH-0058:testDeliveryFlagType"/>
			<xs:element name="testData" type="xs:anyType" minOccurs="0"/>
			<xs:element name="extension" type="xs:anyType" minOccurs="0"/>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="reportHeaderType">
		<xs:sequence>
			<xs:element name="senderId" type="eCH-0058:participantIdType"/>
			<xs:element name="recipientId" type="eCH-0058:participantIdType" minOccurs="0"/>
			<xs:element name="messageId" type="eCH-0058:messageIdType"/>
			<xs:element name="referenceMessageId" type="eCH-0058:messageIdType" minOccurs="0"/>
			<xs:element name="ourBusinessReferenceID" type="eCH-0058:businessReferenceIdType" minOccurs="0"/>
			<xs:element name="yourBusinessReferenceId" type="eCH-0058:businessReferenceIdType" minOccurs="0"/>
			<xs:element name="messageType" type="eCH-0058:messageTypeType"/>
			<xs:element name="subMessageType" type="eCH-0058:subMessageTypeType" minOccurs="0"/>
			<xs:element name="sendingApplication" type="eCH-0058:sendingApplicationType"/>
			<xs:element name="object" type="xs:anyType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="initialMessageDate" type="eCH-0058:initialMessageDateType" minOccurs="0"/>
			<xs:element name="action">
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="2"/>
						<xs:enumeration value="8"/>
						<xs:enumeration value="9"/>
						<xs:enumeration value="11"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="testDeliveryFlag" type="eCH-0058:testDeliveryFlagType"/>
			<xs:element name="testData" type="xs:anyType" minOccurs="0"/>
			<xs:element name="extension" type="xs:anyType" minOccurs="0"/>
		</xs:sequence>
	</xs:complexType>
	<xs:simpleType name="messageIdType">
		<xs:restriction base="xs:string">
			<xs:minLength value="1"/>
			<xs:maxLength value="36"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="subMessageTypeType">
		<xs:restriction base="xs:string">
			<xs:minLength value="1"/>
			<xs:maxLength value="36"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="messageTypeType">
		<xs:restriction base="xs:int">
			<xs:minInclusive value="0"/>
			<xs:maxInclusive value="2699999"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="declarationLocalReferenceType">
		<xs:restriction base="xs:string">
			<xs:minLength value="1"/>
			<xs:maxLength value="100"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="participantIdType">
		<xs:restriction base="xs:string">
			<xs:maxLength value="50"/>
			<xs:minLength value="1"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="businessReferenceIdType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="50"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="subjectType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="100"/>
			<xs:minLength value="1"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="commentType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="250"/>
			<xs:minLength value="1"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="uniqueIDBusinessCaseType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="50"/>
			<xs:minLength value="1"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="totalNumberOfPackagesType">
		<xs:restriction base="xs:nonNegativeInteger"/>
	</xs:simpleType>
	<xs:simpleType name="numberOfActualPackageType">
		<xs:restriction base="xs:nonNegativeInteger"/>
	</xs:simpleType>
	<xs:simpleType name="testDeliveryFlagType">
		<xs:restriction base="xs:boolean"/>
	</xs:simpleType>
	<xs:simpleType name="initialMessageDateType">
		<xs:restriction base="xs:dateTime"/>
	</xs:simpleType>
	<xs:complexType name="sendingApplicationType">
		<xs:sequence>
			<xs:element name="manufacturer">
				<xs:simpleType>
					<xs:restriction base="xs:token">
						<xs:maxLength value="30"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="product">
				<xs:simpleType>
					<xs:restriction base="xs:token">
						<xs:maxLength value="30"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="productVersion">
				<xs:simpleType>
					<xs:restriction base="xs:token">
						<xs:maxLength value="10"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
	<xs:element name="eventReport">
		<xs:complexType>
			<xs:sequence>
				<xs:element name="reportHeader" type="eCH-0058:reportHeaderType"/>
				<xs:element name="report" type="eCH-0058:reportType"/>
			</xs:sequence>
		</xs:complexType>
	</xs:element>
	<xs:complexType name="reportType">
		<xs:choice>
			<xs:element name="positiveReport" type="xs:anyType"/>
			<xs:element name="negativeReport" type="xs:anyType"/>
		</xs:choice>
	</xs:complexType>
</xs:schema>


<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:eCH-0044="http://www.ech.ch/xmlns/eCH-0044/1" targetNamespace="http://www.ech.ch/xmlns/eCH-0044/1" elementFormDefault="qualified" attributeFormDefault="unqualified" version="1.1">
	<xs:annotation>
		<xs:documentation xml:lang="de">Ausgabedatum: 28.03.2009</xs:documentation>
	</xs:annotation>
	<xs:simpleType name="personIdCategoryType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="20"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:complexType name="namedPersonIdType">
		<xs:sequence>
			<xs:element name="personIdCategory" type="eCH-0044:personIdCategoryType"/>
			<xs:element name="personId">
				<xs:simpleType>
					<xs:restriction base="xs:token">
						<xs:maxLength value="20"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="personIdentificationType">
		<xs:sequence>
			<xs:element name="vn" type="eCH-0044:vnType" minOccurs="0"/>
			<xs:element name="localPersonId" type="eCH-0044:namedPersonIdType"/>
			<xs:element name="OtherPersonId" type="eCH-0044:namedPersonIdType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="EuPersonId" type="eCH-0044:namedPersonIdType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="officialName" type="eCH-0044:baseNameType"/>
			<xs:element name="firstName" type="eCH-0044:baseNameType"/>
			<xs:element name="sex" type="eCH-0044:sexType"/>
			<xs:element name="dateOfBirth" type="eCH-0044:datePartiallyKnownType"/>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="personIdentificationPartnerType">
		<xs:sequence>
			<xs:element name="vn" type="eCH-0044:vnType" minOccurs="0"/>
			<xs:element name="localPersonId" type="eCH-0044:namedPersonIdType"/>
			<xs:element name="OtherPersonId" type="eCH-0044:namedPersonIdType" minOccurs="0" maxOccurs="unbounded"/>
			<xs:element name="officialName" type="eCH-0044:baseNameType"/>
			<xs:element name="firstName" type="eCH-0044:baseNameType"/>
			<xs:element name="sex" type="eCH-0044:sexType" minOccurs="0"/>
			<xs:element name="dateOfBirth" type="eCH-0044:datePartiallyKnownType" minOccurs="0"/>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="datePartiallyKnownType">
		<xs:choice>
			<xs:element name="yearMonthDay" type="xs:date"/>
			<xs:element name="yearMonth" type="xs:gYearMonth"/>
			<xs:element name="year" type="xs:gYear"/>
		</xs:choice>
	</xs:complexType>
	<xs:simpleType name="baseNameType">
		<xs:restriction base="xs:token">
			<xs:maxLength value="100"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="officialFirstNameType">
		<xs:restriction base="xs:string">
			<xs:maxLength value="50"/>
			<xs:whiteSpace value="collapse"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="sexType">
		<xs:restriction base="xs:string">
			<xs:enumeration value="1"/>
			<xs:enumeration value="2"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:simpleType name="vnType">
		<xs:restriction base="xs:unsignedLong">
			<xs:minInclusive value="7560000000001"/>
			<xs:maxInclusive value="7569999999999"/>
		</xs:restriction>
	</xs:simpleType>
	<xs:element name="personIdentificationRoot">
		<xs:complexType>
			<xs:sequence>
				<xs:element name="personIdentification" type="eCH-0044:personIdentificationType"/>
			</xs:sequence>
		</xs:complexType>
	</xs:element>
</xs:schema>

<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:eCH-0044="http://www.ech.ch/xmlns/eCH-0044/1" xmlns:eCH-0058="http://www.ech.ch/xmlns/eCH-0058/2" xmlns:igs-0001="http://igs-gmbh.ch/xmlns/igs-0001/1" targetNamespace="http://igs-gmbh.ch/xmlns/igs-0001/1" elementFormDefault="qualified" attributeFormDefault="unqualified" version="0">
	<xs:annotation>
		<xs:documentation xml:lang="de">Ausgabedatum: 08.03.2010</xs:documentation>
	</xs:annotation>
	<xs:import namespace="http://www.ech.ch/xmlns/eCH-0044/1" schemaLocation="http://www.ech.ch/xmlns/eCH-0044/1/eCH-0044-1-1.xsd"/>
	<xs:import namespace="http://www.ech.ch/xmlns/eCH-0058/2" schemaLocation="http://www.ech.ch/xmlns/eCH-0058/2/eCH-0058-2-0.xsd"/>
	<xs:complexType name="headerType">
		<xs:sequence>
			<xs:element name="senderId" type="eCH-0058:participantIdType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachlicher Absender der Ereignislieferung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="originalSenderID" type="eCH-0058:participantIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Bei weitergeleiteten Nachrichten (action = 10) wird hier die Sender-Id des ursprünglichen Absenders eingetragen. Wird eine Nachricht über mehrere Stationen weitergeleitet, so bleibt immer die Sender-Id des ersten Absenders eingetragen.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="declarationLocalReference" type="eCH-0058:declarationLocalReferenceType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Lokale fachliche Referenz des Absenders für Nachfragen.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="recipientId" type="eCH-0058:participantIdType" minOccurs="0" maxOccurs="unbounded">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachlicher Empfänger der Ereignislieferung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="messageId" type="eCH-0058:messageIdType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Eindeutige ID der Meldung: 
Diese ID wird von der sendenden Anwendung vergeben. Sie dient der sendenden
Anwendung dazu, eine Meldung und eine Antwort auf diese Meldung zu korrelieren.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="referenceMessageId" type="eCH-0058:messageIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Id der Nachricht, auf welche die aktuelle Nachricht referenziert.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="ourBusinessReferenceID" type="eCH-0058:businessReferenceIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Ermöglicht die Weitergabe einer fachlichen Referenz. Dabei handel es sich um die Referenz des Absenders einer Nachricht.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yourBusinessReferenceId" type="eCH-0058:businessReferenceIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Damit kann bei einer Antwort explizit Bezug auf die fachliche Referenz des Absenders genommen werden.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="messageType" type="eCH-0058:messageTypeType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Meldungstyp.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="subMessageType" type="eCH-0058:subMessageTypeType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Der Subnachrichtentyp ermöglicht eine weitere Verfeinerung des Nachrichtentyps zu fachlichen Zwecken.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="sendingApplication" type="eCH-0058:sendingApplicationType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Identifikation der Anwendung, welche die Ereignislieferung aufbereitet hat.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="partialDelivery" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Die Angaben zur Teillieferung können für zwei unterschiedliche Szenarien eingesetzt werden:

* Szenario 1: Die Lieferung von mehreren Ereignismeldungen desselben Typs sollen in mehrere Teillieferungen unterteilt werden. (Bsp. Gesamtdatenlieferung von sehr grossen Registern).

* Szenario 2: Mehrere unterschiedliche Ereignismeldungen sollen als zusammengehörig gekennzeichnet werden, damit sie vom Empfänger gemeinsam verarbeitet werden können
(Bsp. Eheschliessung und abhängige Namensänderung).</xs:documentation>
				</xs:annotation>
				<xs:complexType>
					<xs:sequence>
						<xs:element name="uniqueIDBusinessCase" type="eCH-0058:uniqueIDBusinessCaseType">
							<xs:annotation>
								<xs:documentation xml:lang="de">Beliebiger, eindeutiger Schlüssel zur Identifikation des Geschäftsfalls.</xs:documentation>
							</xs:annotation>
						</xs:element>
						<xs:element name="totalNumberOfPackages" type="eCH-0058:totalNumberOfPackagesType">
							<xs:annotation>
								<xs:documentation xml:lang="de">Anzahl der Teillieferungen für die vollständige Übermittlung des Geschäftsfalls.</xs:documentation>
							</xs:annotation>
						</xs:element>
						<xs:element name="numberOfActualPackage" type="eCH-0058:numberOfActualPackageType">
							<xs:annotation>
								<xs:documentation>Identifikation des aktuellen Pakets. Die Nummer ist (mit 1 beginnend) in 1er-Schritten zu vergeben.</xs:documentation>
							</xs:annotation>
						</xs:element>
					</xs:sequence>
				</xs:complexType>
			</xs:element>
			<xs:element name="subject" type="eCH-0058:subjectType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Möglichkeit der Ereignislieferung einen bezeichnenden Titel zu geben.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="object" type="xs:anyType" minOccurs="0" maxOccurs="unbounded">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachliche Identifikation(en) zum Objekt der Ereignismeldung. Das Herstellen der Beziehung zwischen Objekt und Ereignismeldung ist Aufgabe der Fachanwendung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="comment" type="eCH-0058:commentType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Möglichkeit für das fachliche Dispatching der Ereignismeldungen einen Kommentar zuzufügen.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="messageDate" type="xs:dateTime">
				<xs:annotation>
					<xs:documentation xml:lang="de">Versanddatum der Nachricht.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="initialMessageDate" type="eCH-0058:initialMessageDateType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Wird bei Weiterleitungen (action = 10) angegeben. Es handelt sich dabei um das Datum der ersten Meldung. Dieses bleibt also auch bei der Weiterleitung über mehrere Instanzen immer gleich.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="eventDate" type="xs:dateTime">
				<xs:annotation>
					<xs:documentation>Fachliches Datum, an welchem das Ereignis stattgefunden hat.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="modificationDate" type="xs:dateTime" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachliches Bearbeitungsdatum der Ereignismeldung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="action">
				<xs:annotation>
					<xs:documentation xml:lang="de">Der Code „action“ kann folgende Werte annehmen:

„1“= „neu“/„new“
Erstmaliges Liefern von Daten. Diese Aktion darf für eine individuelle Meldung nur einmal verwendet werden.

„3“= „Widerruf“ / „recall“
Eine zu Unrecht gelieferte Meldung rückgängig machen.

„4“= „Korrektur“ / „correction“
Bereits gesendete, aber falsche Daten korrigieren.

„5“= „Anfrage“ / „request“
Daten beim Absender explizit verlangen.

„6“ = „Antwort“ / „response“
Senden von Daten, welche mittels „5“ angefordert wurden.

„7“ = „Schlüsselaustausch“ / „keyExchange“
Austausch von Schlüsseln

„10“= „Weiterleitung“ / „forward“
Daten weiterleiten.</xs:documentation>
				</xs:annotation>
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="2"/>
						<xs:enumeration value="1"/>
						<xs:enumeration value="3"/>
						<xs:enumeration value="4"/>
						<xs:enumeration value="5"/>
						<xs:enumeration value="6"/>
						<xs:enumeration value="7"/>
						<xs:enumeration value="10"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="attachment" type="xs:anyType" minOccurs="0" maxOccurs="unbounded">
				<xs:annotation>
					<xs:documentation xml:lang="de">Die Nachricht kann aus mehreren Teilen bestehen, welche z.B. in einer ZIP-Datei zusammenfasst werden. Ob und in welcher Form solche Anhänge zulässig sind, muss pro Fachdomäne definiert werden.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="testDeliveryFlag" type="eCH-0058:testDeliveryFlagType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Angabe ob es sich um eine Testnachricht handelt (true) oder nicht (false).</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="testData" type="xs:anyType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Testdaten. Die Definition bleibt den Fachdomänen überlassen.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="extension" type="xs:anyType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Die Erweiterung ermöglicht spezifische Ergänzungen der Kopfnachricht für eine Fachdomäne.</xs:documentation>
				</xs:annotation>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="reportHeaderType">
		<xs:sequence>
			<xs:element name="senderId" type="eCH-0058:participantIdType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachlicher Absender der Ereignislieferung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="recipientId" type="eCH-0058:participantIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachlicher Empfänger der Ereignislieferung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="messageId" type="eCH-0058:messageIdType">
				<xs:annotation>
					<xs:documentation>Eindeutige ID der Meldung: 
Diese ID wird von der sendenden Anwendung vergeben. Sie dient der sendenden
Anwendung dazu, eine Meldung und eine Antwort auf diese Meldung zu korrelieren.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="referenceMessageId" type="eCH-0058:messageIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Id der Nachricht, auf welche die aktuelle Nachricht referenziert.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="ourBusinessReferenceID" type="eCH-0058:businessReferenceIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Ermöglicht die Weitergabe einer fachlichen Referenz. Dabei handel es sich um die Referenz des Absenders einer Nachricht.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yourBusinessReferenceId" type="eCH-0058:businessReferenceIdType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Damit kann bei einer Antwort explizit Bezug auf die fachliche Referenz des Absenders genommen werden.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="messageType" type="eCH-0058:messageTypeType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Meldungstyp.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="subMessageType" type="eCH-0058:subMessageTypeType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Der Subnachrichtentyp ermöglicht eine weitere Verfeinerung des Nachrichtentyps zu fachlichen Zwecken.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="sendingApplication" type="eCH-0058:sendingApplicationType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Identifikation der Anwendung, welche die Ereignislieferung aufbereitet hat.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="object" type="xs:anyType" minOccurs="0" maxOccurs="unbounded">
				<xs:annotation>
					<xs:documentation xml:lang="de">Fachliche Identifikation(en) zum Objekt der Ereignismeldung. Das Herstellen der Beziehung zwischen Objekt und Ereignismeldung ist Aufgabe der Fachanwendung.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="initialMessageDate" type="eCH-0058:initialMessageDateType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Wird bei Weiterleitungen (action = 10) angegeben. Es handelt sich dabei um das Datum der ersten Meldung. Dieses bleibt also auch bei der Weiterleitung über mehrere Instanzen immer gleich.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="action">
				<xs:annotation>
					<xs:documentation xml:lang="de">Der Code „action“ kann folgende Werte annehmen:
					
„8“ = „Fehlerreport“ „negativeReport“
Meldung von Fehlern zu einer Ereignislieferung
Die Definition der Fehler ist Aufgabe der Fachdomäne und muss in den
jeweiligen Standards beschrieben werden.

„9“ = „Meldungsreport“ / „positiveReport“
Rückmeldung des korrekten Empfangs einer Meldung.

„11“= „fachliche Rückmeldung“ / „Business response“
Rückmeldung von fachlich</xs:documentation>
				</xs:annotation>
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="2"/>
						<xs:enumeration value="8"/>
						<xs:enumeration value="9"/>
						<xs:enumeration value="11"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="testDeliveryFlag" type="eCH-0058:testDeliveryFlagType">
				<xs:annotation>
					<xs:documentation xml:lang="de">Angabe ob es sich um eine Testnachricht handelt (true) oder nicht (false).</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="testData" type="xs:anyType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Testdaten. Die Definition bleibt den Fachdomänen überlassen.</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="extension" type="xs:anyType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Die Erweiterung ermöglicht spezifische Ergänzungen der Kopfnachricht für eine Fachdomäne.</xs:documentation>
				</xs:annotation>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="reportType">
		<xs:choice>
			<xs:element name="negativeReport" type="igs-0001:negativeReportType"/>
			<xs:element name="positiveReport" type="igs-0001:positiveReportType"/>
		</xs:choice>
	</xs:complexType>
	<xs:complexType name="negativeReportType">
		<xs:sequence>
			<xs:element name="generalError" type="igs-0001:infoType" minOccurs="0" maxOccurs="unbounded"/>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="positiveReportType">
		<xs:sequence>
			<xs:element name="generalResponse" type="igs-0001:infoType" minOccurs="0" maxOccurs="unbounded"/>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="infoType">
		<xs:sequence>
			<xs:element name="code" minOccurs="0">
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="100"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
			<xs:element name="description" minOccurs="0">
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:maxLength value="255"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
</xs:schema>

<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:eCH-0044="http://www.ech.ch/xmlns/eCH-0044/1" xmlns:igs-0001="http://igs-gmbh.ch/xmlns/igs-0001/1" xmlns:igs-0002="http://igs-gmbh.ch/xmlns/igs-0002/1" targetNamespace="http://igs-gmbh.ch/xmlns/igs-0002/1" elementFormDefault="qualified" attributeFormDefault="unqualified" version="0">
	<xs:annotation>
		<xs:documentation xml:lang="de">Ausgabedatum: 08.03.2010</xs:documentation>
	</xs:annotation>
	<xs:import namespace="http://www.ech.ch/xmlns/eCH-0044/1" schemaLocation="http://www.ech.ch/xmlns/eCH-0044/1/eCH-0044-1-1.xsd"/>
	<xs:import namespace="http://igs-gmbh.ch/xmlns/igs-0001/1" schemaLocation="igs-0001-1-0.xsd"/>
	<xs:element name="message">
		<xs:annotation>
			<xs:documentation xml:lang="de">Nachricht, welche gesendet oder empfangen wird.</xs:documentation>
		</xs:annotation>
		<xs:complexType>
			<xs:sequence>
				<xs:choice>
					<xs:element name="header" type="igs-0001:headerType">
						<xs:annotation>
							<xs:documentation xml:lang="de">Nachrichtenkopf fÃ¼r den Austausch von Ereignismeldungen.</xs:documentation>
						</xs:annotation>
					</xs:element>
					<xs:sequence>
						<xs:element name="reportHeader" type="igs-0001:reportHeaderType">
							<xs:annotation>
								<xs:documentation xml:lang="de">Antwortkopf fÃ¼r den Austausch von Fehler- und Statusmeldungen.</xs:documentation>
							</xs:annotation>
						</xs:element>
						<xs:element name="report" type="igs-0001:reportType"/>
					</xs:sequence>
				</xs:choice>
				<xs:choice>
					<xs:element name="searchIndividualAccountRequest" type="igs-0002:searchIndividualAccountRequestType">
						<xs:annotation>
							<xs:documentation xml:lang="de">IK Suchanfrage.</xs:documentation>
						</xs:annotation>
					</xs:element>
					<xs:element name="searchIndividualAccountReponse" type="igs-0002:searchIndividualAccountReponseType">
						<xs:annotation>
							<xs:documentation xml:lang="de">Antwort auf eine IK Suchanfrage.</xs:documentation>
						</xs:annotation>
					</xs:element>
				</xs:choice>
			</xs:sequence>
		</xs:complexType>
	</xs:element>
	<xs:complexType name="searchIndividualAccountRequestType">
		<xs:sequence>
			<xs:element name="vn" type="eCH-0044:vnType">
				<xs:annotation>
					<xs:documentation xml:lang="de">AHVVN13</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="officialName" type="eCH-0044:baseNameType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Name</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="firstName" type="eCH-0044:baseNameType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Vorname</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="countryOfOrigin" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Heimatstaat</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="dateOfBirth" type="xs:date" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Geburtsdatum</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yearTo" type="xs:gYear">
				<xs:annotation>
					<xs:documentation xml:lang="de">Jahr Periodenstart</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yearFrom" type="xs:gYear">
				<xs:annotation>
					<xs:documentation xml:lang="de">Jahr Periodenende</xs:documentation>
				</xs:annotation>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
	<xs:complexType name="searchIndividualAccountReponseType">
		<xs:sequence>
			<xs:element name="vn" type="eCH-0044:vnType">
				<xs:annotation>
					<xs:documentation xml:lang="de">AHVVN13</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="officialName" type="eCH-0044:baseNameType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Name</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="firstName" type="eCH-0044:baseNameType" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Vorname</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="countryOfOrigin" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Heimatstaat</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="dateOfBirth" type="xs:date" minOccurs="0">
				<xs:annotation>
					<xs:documentation xml:lang="de">Geburtsdatum</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yearTo" type="xs:gYear">
				<xs:annotation>
					<xs:documentation xml:lang="de">Jahr Periodenstart</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="yearFrom" type="xs:gYear">
				<xs:annotation>
					<xs:documentation xml:lang="de">Jahr Periodenende</xs:documentation>
				</xs:annotation>
			</xs:element>
			<xs:element name="account" minOccurs="0" maxOccurs="unbounded">
				<xs:annotation>
					<xs:documentation xml:lang="de">Kopfdaten pro Versichertennummer des Klienten.</xs:documentation>
				</xs:annotation>
				<xs:complexType>
					<xs:sequence>
						<xs:element name="personId">
							<xs:annotation>
								<xs:documentation xml:lang="de">AHVVN11 oder AHVVN13</xs:documentation>
							</xs:annotation>
							<xs:simpleType>
								<xs:restriction base="xs:token">
									<xs:maxLength value="13"/>
								</xs:restriction>
							</xs:simpleType>
						</xs:element>
						<xs:element name="totalIncome" minOccurs="0">
							<xs:annotation>
								<xs:documentation xml:lang="de">Einkommenssumme</xs:documentation>
							</xs:annotation>
							<xs:simpleType>
								<xs:restriction base="xs:string">
									<xs:maxLength value="15"/>
									<xs:minLength value="4"/>
									<xs:pattern value="\d{1,12}\.\d{2}"/>
								</xs:restriction>
							</xs:simpleType>
						</xs:element>
						<xs:element name="accountData" minOccurs="0" maxOccurs="unbounded">
							<xs:annotation>
								<xs:documentation xml:lang="de">Kontodaten</xs:documentation>
							</xs:annotation>
							<xs:complexType>
								<xs:sequence>
									<xs:element name="compensationOffice" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Kassennummer</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:token">
												<xs:minLength value="0"/>
												<xs:maxLength value="2"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
									<xs:element name="accountNumber" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Abrechnungsnummer</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:token">
												<xs:minLength value="0"/>
												<xs:maxLength value="14"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
									<xs:element name="incomeCode" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Einkommenscode</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:token">
												<xs:maxLength value="2"/>
												<xs:minLength value="0"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
									<xs:element name="fractionFL" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">BruchteilBG</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:positiveInteger">
												<xs:maxInclusive value="99"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
									<xs:element name="contributionMonthStart" type="xs:gMonth" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Beginn Beitragsmonat</xs:documentation>
										</xs:annotation>
									</xs:element>
									<xs:element name="contributionMonthEnd" type="xs:gMonth" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Ende Beitragsmonat</xs:documentation>
										</xs:annotation>
									</xs:element>
									<xs:element name="contributionYear" type="xs:gYear" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Beitragsjahr</xs:documentation>
										</xs:annotation>
									</xs:element>
									<xs:element name="income" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Einkommen</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:string">
												<xs:maxLength value="15"/>
												<xs:minLength value="4"/>
												<xs:pattern value="\d{1,13}\.\d{2}"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
									<xs:element name="description" minOccurs="0">
										<xs:annotation>
											<xs:documentation xml:lang="de">Bezeichnung</xs:documentation>
										</xs:annotation>
										<xs:simpleType>
											<xs:restriction base="xs:token">
												<xs:minLength value="0"/>
												<xs:maxLength value="100"/>
											</xs:restriction>
										</xs:simpleType>
									</xs:element>
								</xs:sequence>
							</xs:complexType>
						</xs:element>
					</xs:sequence>
				</xs:complexType>
			</xs:element>
		</xs:sequence>
	</xs:complexType>
</xs:schema>

'
GO