SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [BFSKatalogVersion]
GO
INSERT INTO [BFSKatalogVersion] ([BFSKatalogVersionID], [Jahr], [PlausexVersion], [DossierXML]) VALUES (20080714, 2008, N'2.5.0', N'<xml xmlns:z="#RowsetSchema">
  <!-- 2.2007 konsequente Kleinschreibung aller Bezeichner. Insbesondere versichertennummer, albv_leistung (anstelle von Versichertennummer und albv_Leistung) -->
  <dossier sh_fremd_id="" b_neubezuegerrecord="">
    <z:row jahr="" gemeinde_id="" sozialleistungstraeger_id="" dossiernummer="" sh_leistungstyp_id="" wohnungsgroesse_id="" sh_wohnsituation_id="" sh_leistungsart_id="" beendigungsgrund_id="" antragsart_id="" pfleger_id="" dat_aufnahme="" anz_personen_hh="" anz_personen_ue="" anz_pflegefaelle_hh="" b_weitere_ue_einkommen="" b_vermoegensfreibetrag="" b_guthaben_pensionskasse="" b_wohneigentum="" b_frueher_unterstuetzt="" dauer_unterstuetzung_mt="" wohnkosten_inkl_nk="" betrag_bruttobedarf="" betrag_nettobedarf_skos="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" betrag_tot_ausz_krankheit="" einkommen_detail_id="" ue_monatseinkommen="" ue_monatserwerbseinkommen="" ue_monatssozialversleistungen="" ue_monatsleistungen_bedarf="" ue_monats_zusatzeinkommen="" b_bezug_stichtag="" dat_letzte_zahlung="" b_ueberbrueckung="" dat_abgeschlossen="" b_ber_skos_2005="" dat_beginn_anspruch="" b_ergaenzung_bund="" betrag_zugesprochen_el_bund="" betrag_ausbezahlt_el_bund="" b_beihilfe_kanton="" betrag_zugesprochen_beihilfe_kanton="" betrag_ausbezahlt_beihilfe_kanton="" b_zuschuss_gemeinde="" betrag_zugesprochen_zuschuss_gemeinde="" betrag_ausbezahlt_zuschuss_gemeinde="" />
    <antragsteller>
      <z:row vorname="" nachname="" frueherer_name="" geschlecht_id="" zivilstand_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" buerger_gemeinde_id="" zuzug_gem_gemeinde_id="" zuzug_gem_land_id="" zuzug_kant_land_id="" zvr_gemeinde_id="" ust_gemeinde_id="" auf_gemeinde_id="" ausbildung_id="" abgebr_ausbildung_id="" erlernter_beruf_id="" aktueller_beruf_id="" beschaeftigungsgrad_id="" branche_id="" branche_alpha_code="" branche_alpha_code_2008="" teilzeit_grund1_id="" teilzeit_grund2_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" ahv_nr="" versichertennummer="" dat_geburt="" zvr_strasse="" zvr_haus_nr="" zvr_plz="" zvr_ort="" ust_plz="" ust_ort="" auf_plz="" auf_ort="" dat_in_gemeinde_seit_jahr="" dat_in_gemeinde_seit_tag_monat="" dat_im_kanton_seit_jahr="" dat_im_kanton_seit_tag_monat="" in_ch_seit_jahr="" b_allein_im_hh="" b_arbeit_unregelmaessig="" arbeitszeit_woche="" dat_stempelbeginn="" b_ausgesteuert="" dat_ausgesteuert="" anz_arbeitslos_3j="" b_ausb_abgebrochen="" b_iv_eingliederung="" b_kk_grundversicherung="" b_kk_zusatzversicherung="" kk_name="" kk_praemie_mt="" b_kk_praemienzuschuss="" kk_zuschuss_betrag="" betrag_mietanteil="" />
      <einkommen>
        <z:row einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="14" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row erwerbsituation_id="" indx="1" />
        <z:row erwerbsituation_id="" indx="2" />
        <z:row erwerbsituation_id="" indx="3" />
        <z:row erwerbsituation_id="" indx="4" />
      </erwerbsit>
      <skos>
        <z:row bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </antragsteller>
    <auszahlung>
      <z:row monat_id="1" betrag="" />
      <z:row monat_id="2" betrag="" />
      <z:row monat_id="3" betrag="" />
      <z:row monat_id="4" betrag="" />
      <z:row monat_id="5" betrag="" />
      <z:row monat_id="6" betrag="" />
      <z:row monat_id="7" betrag="" />
      <z:row monat_id="8" betrag="" />
      <z:row monat_id="9" betrag="" />
      <z:row monat_id="10" betrag="" />
      <z:row monat_id="11" betrag="" />
      <z:row monat_id="12" betrag="" />
    </auszahlung>
    <ausgabe>
      <z:row ausgabeart_id="1" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="2" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="3" b_in_abklaerung="" />
      <z:row ausgabeart_id="4" betrag="" b_in_abklaerung="" />
    </ausgabe>
    <bedarf>
      <z:row bedarfsart_id="1" betrag="" />
      <z:row bedarfsart_id="2" betrag="" />
      <z:row bedarfsart_id="3" betrag="" />
      <z:row bedarfsart_id="4" betrag="" />
      <z:row bedarfsart_id="5" betrag="" />
      <z:row bedarfsart_id="6" betrag="" />
      <z:row bedarfsart_id="7" betrag="" />
      <z:row bedarfsart_id="8" betrag="" />
      <z:row bedarfsart_id="9" betrag="" />
      <z:row bedarfsart_id="10" betrag="" />
      <z:row bedarfsart_id="11" betrag="" />
      <z:row bedarfsart_id="12" betrag="" />
      <z:row bedarfsart_id="13" betrag="" />
      <z:row bedarfsart_id="14" betrag="" />
      <z:row bedarfsart_id="15" betrag="" />
      <z:row bedarfsart_id="16" betrag="" />
      <z:row bedarfsart_id="17" betrag="" />
      <z:row bedarfsart_id="18" betrag="" />
    </bedarf>
    <zusatz>
      <z:row sh_einkommensart_id="1" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="10" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="12" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="13" betrag="" b_in_abklaerung="" />
    </zusatz>
    <massnahme>
      <z:row massnahme_id="1" wert="" kommentar="" />
      <z:row massnahme_id="2" wert="" kommentar="" />
      <z:row massnahme_id="3" wert="" kommentar="" />
      <z:row massnahme_id="4" wert="" kommentar="" />
      <z:row massnahme_id="5" wert="" kommentar="" />
      <z:row massnahme_id="6" wert="" kommentar="" />
      <z:row massnahme_id="7" wert="" kommentar="" />
      <z:row massnahme_id="8" wert="" kommentar="" />
      <z:row massnahme_id="9" wert="" kommentar="" />
      <z:row massnahme_id="10" wert="" kommentar="" />
      <z:row massnahme_id="11" wert="" kommentar="" />
      <z:row massnahme_id="12" wert="" kommentar="" />
      <z:row massnahme_id="13" wert="" kommentar="" />
      <z:row massnahme_id="14" wert="" kommentar="" />
      <z:row massnahme_id="15" wert="" kommentar="" />
      <z:row massnahme_id="16" wert="" kommentar="" />
      <z:row massnahme_id="17" wert="" kommentar="" />
      <z:row massnahme_id="18" wert="" kommentar="" />
      <z:row massnahme_id="19" wert="" kommentar="" />
      <z:row massnahme_id="20" wert="" kommentar="" />
      <z:row massnahme_id="21" wert="" kommentar="" />
      <z:row massnahme_id="22" wert="" kommentar="" />
      <z:row massnahme_id="23" wert="" kommentar="" />
      <z:row massnahme_id="24" wert="" kommentar="" />
      <z:row massnahme_id="25" wert="" kommentar="" />
      <z:row massnahme_id="26" wert="" kommentar="" />
      <z:row massnahme_id="27" wert="" kommentar="" />
      <z:row massnahme_id="28" wert="" kommentar="" />
      <z:row massnahme_id="29" wert="" kommentar="" />
      <z:row massnahme_id="30" wert="" kommentar="" />
      <z:row massnahme_id="31" wert="" kommentar="" />
    </massnahme>
    <merkmal>
      <z:row sh_merkmal_id="1" wert="" />
      <z:row sh_merkmal_id="2" wert="" />
      <z:row sh_merkmal_id="3" wert="" />
      <z:row sh_merkmal_id="4" wert="" />
      <z:row sh_merkmal_id="5" wert="" />
      <z:row sh_merkmal_id="6" wert="" />
      <z:row sh_merkmal_id="7" wert="" />
      <z:row sh_merkmal_id="8" wert="" />
      <z:row sh_merkmal_id="9" wert="" />
      <z:row sh_merkmal_id="10" wert="" />
      <z:row sh_merkmal_id="11" wert="" />
      <z:row sh_merkmal_id="12" wert="" />
      <z:row sh_merkmal_id="13" wert="" />
      <z:row sh_merkmal_id="14" wert="" />
      <z:row sh_merkmal_id="15" wert="" />
      <z:row sh_merkmal_id="16" wert="" />
      <z:row sh_merkmal_id="17" wert="" />
      <z:row sh_merkmal_id="18" wert="" />
      <z:row sh_merkmal_id="19" wert="" />
      <z:row sh_merkmal_id="20" wert="" />
      <z:row sh_merkmal_id="21" wert="" />
      <z:row sh_merkmal_id="22" wert="" />
      <z:row sh_merkmal_id="23" wert="" />
      <z:row sh_merkmal_id="24" wert="" />
      <z:row sh_merkmal_id="25" wert="" />
      <z:row sh_merkmal_id="26" wert="" />
      <z:row sh_merkmal_id="27" wert="" />
      <z:row sh_merkmal_id="28" wert="" />
      <z:row sh_merkmal_id="29" wert="" />
      <z:row sh_merkmal_id="30" wert="" />
      <z:row sh_merkmal_id="31" wert="" />
      <z:row sh_merkmal_id="32" wert="" />
      <z:row sh_merkmal_id="33" wert="" />
      <z:row sh_merkmal_id="34" wert="" />
      <z:row sh_merkmal_id="35" wert="" />
      <z:row sh_merkmal_id="36" wert="" />
      <z:row sh_merkmal_id="37" wert="" />
      <z:row sh_merkmal_id="38" wert="" />
      <z:row sh_merkmal_id="39" wert="" />
      <z:row sh_merkmal_id="40" wert="" />
      <z:row sh_merkmal_id="41" wert="" />
      <z:row sh_merkmal_id="42" wert="" />
      <z:row sh_merkmal_id="43" wert="" />
      <z:row sh_merkmal_id="44" wert="" />
      <z:row sh_merkmal_id="45" wert="" />
      <z:row sh_merkmal_id="46" wert="" />
      <z:row sh_merkmal_id="47" wert="" />
      <z:row sh_merkmal_id="48" wert="" />
      <z:row sh_merkmal_id="49" wert="" />
      <z:row sh_merkmal_id="50" wert="" />
      <z:row sh_merkmal_id="51" wert="" />
    </merkmal>
    <wbsl_einkommensart>
      <z:row sh_einkommensart_id="1" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="14" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="15" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="19" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="20" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="101" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="102" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="103" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="104" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="105" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="106" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="107" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="108" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="112" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="113" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="114" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="115" b_in_abklaerung="" />
    </wbsl_einkommensart>
    <ue>
      <person>
        <z:row ue_person_id="1" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="2" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="3" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="4" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="5" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="6" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="7" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="8" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="9" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
      </person>
      <einkommen>
        <z:row ue_person_id="1" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="13" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="4" />
      </erwerbsit>
      <skos>
        <z:row ue_person_id="1" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row ue_person_id="1" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="2" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="3" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="4" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="5" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="6" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="7" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="8" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="9" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </ue>
    <hh>
      <person>
        <z:row hh_person_id="1" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="2" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="3" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="4" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="5" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="6" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="7" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="8" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="9" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
      </person>
    </hh>
  </dossier>
</xml>')
INSERT INTO [BFSKatalogVersion] ([BFSKatalogVersionID], [Jahr], [PlausexVersion], [DossierXML]) VALUES (20090101, 2009, N'2.5.0', N'<xml xmlns:z="#RowsetSchema">
  <!-- 2.2007 konsequente Kleinschreibung aller Bezeichner. Insbesondere versichertennummer, albv_leistung (anstelle von Versichertennummer und albv_Leistung) -->
  <dossier sh_fremd_id="" b_neubezuegerrecord="">
    <z:row jahr="" gemeinde_id="" sozialleistungstraeger_id="" dossiernummer="" sh_leistungstyp_id="" wohnungsgroesse_id="" sh_wohnsituation_id="" sh_leistungsart_id="" beendigungsgrund_id="" antragsart_id="" pfleger_id="" dat_aufnahme="" anz_personen_hh="" anz_personen_ue="" anz_pflegefaelle_hh="" b_weitere_ue_einkommen="" b_vermoegensfreibetrag="" b_guthaben_pensionskasse="" b_wohneigentum="" b_frueher_unterstuetzt="" dauer_unterstuetzung_mt="" wohnkosten_inkl_nk="" betrag_bruttobedarf="" betrag_nettobedarf_skos="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" betrag_tot_ausz_krankheit="" einkommen_detail_id="" ue_monatseinkommen="" ue_monatserwerbseinkommen="" ue_monatssozialversleistungen="" ue_monatsleistungen_bedarf="" ue_monats_zusatzeinkommen="" b_bezug_stichtag="" dat_letzte_zahlung="" b_ueberbrueckung="" dat_abgeschlossen="" b_ber_skos_2005="" dat_beginn_anspruch="" b_ergaenzung_bund="" betrag_zugesprochen_el_bund="" betrag_ausbezahlt_el_bund="" b_beihilfe_kanton="" betrag_zugesprochen_beihilfe_kanton="" betrag_ausbezahlt_beihilfe_kanton="" b_zuschuss_gemeinde="" betrag_zugesprochen_zuschuss_gemeinde="" betrag_ausbezahlt_zuschuss_gemeinde="" />
    <antragsteller>
      <z:row vorname="" nachname="" frueherer_name="" geschlecht_id="" zivilstand_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" buerger_gemeinde_id="" zuzug_gem_gemeinde_id="" zuzug_gem_land_id="" zuzug_kant_land_id="" zvr_gemeinde_id="" ust_gemeinde_id="" auf_gemeinde_id="" ausbildung_id="" abgebr_ausbildung_id="" erlernter_beruf_id="" aktueller_beruf_id="" beschaeftigungsgrad_id="" branche_id="" branche_alpha_code="" branche_alpha_code_2008="" teilzeit_grund1_id="" teilzeit_grund2_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" ahv_nr="" versichertennummer="" dat_geburt="" zvr_strasse="" zvr_haus_nr="" zvr_plz="" zvr_ort="" ust_plz="" ust_ort="" auf_plz="" auf_ort="" dat_in_gemeinde_seit_jahr="" dat_in_gemeinde_seit_tag_monat="" dat_im_kanton_seit_jahr="" dat_im_kanton_seit_tag_monat="" in_ch_seit_jahr="" b_allein_im_hh="" b_arbeit_unregelmaessig="" arbeitszeit_woche="" dat_stempelbeginn="" b_ausgesteuert="" dat_ausgesteuert="" anz_arbeitslos_3j="" b_ausb_abgebrochen="" b_iv_eingliederung="" b_kk_grundversicherung="" b_kk_zusatzversicherung="" kk_name="" kk_praemie_mt="" b_kk_praemienzuschuss="" kk_zuschuss_betrag="" betrag_mietanteil="" />
      <einkommen>
        <z:row einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="14" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row erwerbsituation_id="" indx="1" />
        <z:row erwerbsituation_id="" indx="2" />
        <z:row erwerbsituation_id="" indx="3" />
        <z:row erwerbsituation_id="" indx="4" />
      </erwerbsit>
      <skos>
        <z:row bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </antragsteller>
    <auszahlung>
      <z:row monat_id="1" betrag="" />
      <z:row monat_id="2" betrag="" />
      <z:row monat_id="3" betrag="" />
      <z:row monat_id="4" betrag="" />
      <z:row monat_id="5" betrag="" />
      <z:row monat_id="6" betrag="" />
      <z:row monat_id="7" betrag="" />
      <z:row monat_id="8" betrag="" />
      <z:row monat_id="9" betrag="" />
      <z:row monat_id="10" betrag="" />
      <z:row monat_id="11" betrag="" />
      <z:row monat_id="12" betrag="" />
    </auszahlung>
    <ausgabe>
      <z:row ausgabeart_id="1" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="2" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="3" b_in_abklaerung="" />
      <z:row ausgabeart_id="4" betrag="" b_in_abklaerung="" />
    </ausgabe>
    <bedarf>
      <z:row bedarfsart_id="1" betrag="" />
      <z:row bedarfsart_id="2" betrag="" />
      <z:row bedarfsart_id="3" betrag="" />
      <z:row bedarfsart_id="4" betrag="" />
      <z:row bedarfsart_id="5" betrag="" />
      <z:row bedarfsart_id="6" betrag="" />
      <z:row bedarfsart_id="7" betrag="" />
      <z:row bedarfsart_id="8" betrag="" />
      <z:row bedarfsart_id="9" betrag="" />
      <z:row bedarfsart_id="10" betrag="" />
      <z:row bedarfsart_id="11" betrag="" />
      <z:row bedarfsart_id="12" betrag="" />
      <z:row bedarfsart_id="13" betrag="" />
      <z:row bedarfsart_id="14" betrag="" />
      <z:row bedarfsart_id="15" betrag="" />
      <z:row bedarfsart_id="16" betrag="" />
      <z:row bedarfsart_id="17" betrag="" />
      <z:row bedarfsart_id="18" betrag="" />
    </bedarf>
    <zusatz>
      <z:row sh_einkommensart_id="1" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="10" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="12" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="13" betrag="" b_in_abklaerung="" />
    </zusatz>
    <massnahme>
      <z:row massnahme_id="1" wert="" kommentar="" />
      <z:row massnahme_id="2" wert="" kommentar="" />
      <z:row massnahme_id="3" wert="" kommentar="" />
      <z:row massnahme_id="4" wert="" kommentar="" />
      <z:row massnahme_id="5" wert="" kommentar="" />
      <z:row massnahme_id="6" wert="" kommentar="" />
      <z:row massnahme_id="7" wert="" kommentar="" />
      <z:row massnahme_id="8" wert="" kommentar="" />
      <z:row massnahme_id="9" wert="" kommentar="" />
      <z:row massnahme_id="10" wert="" kommentar="" />
      <z:row massnahme_id="11" wert="" kommentar="" />
      <z:row massnahme_id="12" wert="" kommentar="" />
      <z:row massnahme_id="13" wert="" kommentar="" />
      <z:row massnahme_id="14" wert="" kommentar="" />
      <z:row massnahme_id="15" wert="" kommentar="" />
      <z:row massnahme_id="16" wert="" kommentar="" />
      <z:row massnahme_id="17" wert="" kommentar="" />
      <z:row massnahme_id="18" wert="" kommentar="" />
      <z:row massnahme_id="19" wert="" kommentar="" />
      <z:row massnahme_id="20" wert="" kommentar="" />
      <z:row massnahme_id="21" wert="" kommentar="" />
      <z:row massnahme_id="22" wert="" kommentar="" />
      <z:row massnahme_id="23" wert="" kommentar="" />
      <z:row massnahme_id="24" wert="" kommentar="" />
      <z:row massnahme_id="25" wert="" kommentar="" />
      <z:row massnahme_id="26" wert="" kommentar="" />
      <z:row massnahme_id="27" wert="" kommentar="" />
      <z:row massnahme_id="28" wert="" kommentar="" />
      <z:row massnahme_id="29" wert="" kommentar="" />
      <z:row massnahme_id="30" wert="" kommentar="" />
      <z:row massnahme_id="31" wert="" kommentar="" />
    </massnahme>
    <merkmal>
      <z:row sh_merkmal_id="1" wert="" />
      <z:row sh_merkmal_id="2" wert="" />
      <z:row sh_merkmal_id="3" wert="" />
      <z:row sh_merkmal_id="4" wert="" />
      <z:row sh_merkmal_id="5" wert="" />
      <z:row sh_merkmal_id="6" wert="" />
      <z:row sh_merkmal_id="7" wert="" />
      <z:row sh_merkmal_id="8" wert="" />
      <z:row sh_merkmal_id="9" wert="" />
      <z:row sh_merkmal_id="10" wert="" />
      <z:row sh_merkmal_id="11" wert="" />
      <z:row sh_merkmal_id="12" wert="" />
      <z:row sh_merkmal_id="13" wert="" />
      <z:row sh_merkmal_id="14" wert="" />
      <z:row sh_merkmal_id="15" wert="" />
      <z:row sh_merkmal_id="16" wert="" />
      <z:row sh_merkmal_id="17" wert="" />
      <z:row sh_merkmal_id="18" wert="" />
      <z:row sh_merkmal_id="19" wert="" />
      <z:row sh_merkmal_id="20" wert="" />
      <z:row sh_merkmal_id="21" wert="" />
      <z:row sh_merkmal_id="22" wert="" />
      <z:row sh_merkmal_id="23" wert="" />
      <z:row sh_merkmal_id="24" wert="" />
      <z:row sh_merkmal_id="25" wert="" />
      <z:row sh_merkmal_id="26" wert="" />
      <z:row sh_merkmal_id="27" wert="" />
      <z:row sh_merkmal_id="28" wert="" />
      <z:row sh_merkmal_id="29" wert="" />
      <z:row sh_merkmal_id="30" wert="" />
      <z:row sh_merkmal_id="31" wert="" />
      <z:row sh_merkmal_id="32" wert="" />
      <z:row sh_merkmal_id="33" wert="" />
      <z:row sh_merkmal_id="34" wert="" />
      <z:row sh_merkmal_id="35" wert="" />
      <z:row sh_merkmal_id="36" wert="" />
      <z:row sh_merkmal_id="37" wert="" />
      <z:row sh_merkmal_id="38" wert="" />
      <z:row sh_merkmal_id="39" wert="" />
      <z:row sh_merkmal_id="40" wert="" />
      <z:row sh_merkmal_id="41" wert="" />
      <z:row sh_merkmal_id="42" wert="" />
      <z:row sh_merkmal_id="43" wert="" />
      <z:row sh_merkmal_id="44" wert="" />
      <z:row sh_merkmal_id="45" wert="" />
      <z:row sh_merkmal_id="46" wert="" />
      <z:row sh_merkmal_id="47" wert="" />
      <z:row sh_merkmal_id="48" wert="" />
      <z:row sh_merkmal_id="49" wert="" />
      <z:row sh_merkmal_id="50" wert="" />
      <z:row sh_merkmal_id="51" wert="" />
    </merkmal>
    <wbsl_einkommensart>
      <z:row sh_einkommensart_id="1" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="14" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="15" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="19" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="20" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="101" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="102" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="103" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="104" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="105" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="106" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="107" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="108" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="112" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="113" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="114" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="115" b_in_abklaerung="" />
    </wbsl_einkommensart>
    <ue>
      <person>
        <z:row ue_person_id="1" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="2" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="3" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="4" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="5" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="6" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="7" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="8" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="9" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
      </person>
      <einkommen>
        <z:row ue_person_id="1" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="13" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="4" />
      </erwerbsit>
      <skos>
        <z:row ue_person_id="1" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row ue_person_id="1" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="2" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="3" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="4" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="5" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="6" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="7" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="8" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="9" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </ue>
    <hh>
      <person>
        <z:row hh_person_id="1" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="2" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="3" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="4" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="5" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="6" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="7" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="8" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="9" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
      </person>
    </hh>
  </dossier>
</xml>')
INSERT INTO [BFSKatalogVersion] ([BFSKatalogVersionID], [Jahr], [PlausexVersion], [DossierXML]) VALUES (20100101, 2010, N'2.5.0', N'<xml xmlns:z="#RowsetSchema">
  <!-- 2.2007 konsequente Kleinschreibung aller Bezeichner. Insbesondere versichertennummer, albv_leistung (anstelle von Versichertennummer und albv_Leistung) -->
  <dossier sh_fremd_id="" b_neubezuegerrecord="">
    <z:row jahr="" gemeinde_id="" sozialleistungstraeger_id="" dossiernummer="" sh_leistungstyp_id="" wohnungsgroesse_id="" sh_wohnsituation_id="" sh_leistungsart_id="" beendigungsgrund_id="" antragsart_id="" pfleger_id="" dat_aufnahme="" anz_personen_hh="" anz_personen_ue="" anz_pflegefaelle_hh="" b_weitere_ue_einkommen="" b_vermoegensfreibetrag="" b_guthaben_pensionskasse="" b_wohneigentum="" b_frueher_unterstuetzt="" dauer_unterstuetzung_mt="" wohnkosten_inkl_nk="" betrag_bruttobedarf="" betrag_nettobedarf_skos="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" betrag_tot_ausz_krankheit="" einkommen_detail_id="" ue_monatseinkommen="" ue_monatserwerbseinkommen="" ue_monatssozialversleistungen="" ue_monatsleistungen_bedarf="" ue_monats_zusatzeinkommen="" b_bezug_stichtag="" dat_letzte_zahlung="" b_ueberbrueckung="" dat_abgeschlossen="" b_ber_skos_2005="" dat_beginn_anspruch="" b_ergaenzung_bund="" betrag_zugesprochen_el_bund="" betrag_ausbezahlt_el_bund="" b_beihilfe_kanton="" betrag_zugesprochen_beihilfe_kanton="" betrag_ausbezahlt_beihilfe_kanton="" b_zuschuss_gemeinde="" betrag_zugesprochen_zuschuss_gemeinde="" betrag_ausbezahlt_zuschuss_gemeinde="" />
    <antragsteller>
      <z:row vorname="" nachname="" frueherer_name="" geschlecht_id="" zivilstand_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" buerger_gemeinde_id="" zuzug_gem_gemeinde_id="" zuzug_gem_land_id="" zuzug_kant_land_id="" zvr_gemeinde_id="" ust_gemeinde_id="" auf_gemeinde_id="" ausbildung_id="" abgebr_ausbildung_id="" erlernter_beruf_id="" aktueller_beruf_id="" beschaeftigungsgrad_id="" branche_id="" branche_alpha_code="" branche_alpha_code_2008="" teilzeit_grund1_id="" teilzeit_grund2_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" ahv_nr="" versichertennummer="" dat_geburt="" zvr_strasse="" zvr_haus_nr="" zvr_plz="" zvr_ort="" ust_plz="" ust_ort="" auf_plz="" auf_ort="" dat_in_gemeinde_seit_jahr="" dat_in_gemeinde_seit_tag_monat="" dat_im_kanton_seit_jahr="" dat_im_kanton_seit_tag_monat="" in_ch_seit_jahr="" b_allein_im_hh="" b_arbeit_unregelmaessig="" arbeitszeit_woche="" dat_stempelbeginn="" b_ausgesteuert="" dat_ausgesteuert="" anz_arbeitslos_3j="" b_ausb_abgebrochen="" b_iv_eingliederung="" b_kk_grundversicherung="" b_kk_zusatzversicherung="" kk_name="" kk_praemie_mt="" b_kk_praemienzuschuss="" kk_zuschuss_betrag="" betrag_mietanteil="" />
      <einkommen>
        <z:row einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="14" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row erwerbsituation_id="" indx="1" />
        <z:row erwerbsituation_id="" indx="2" />
        <z:row erwerbsituation_id="" indx="3" />
        <z:row erwerbsituation_id="" indx="4" />
      </erwerbsit>
      <skos>
        <z:row bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </antragsteller>
    <auszahlung>
      <z:row monat_id="1" betrag="" />
      <z:row monat_id="2" betrag="" />
      <z:row monat_id="3" betrag="" />
      <z:row monat_id="4" betrag="" />
      <z:row monat_id="5" betrag="" />
      <z:row monat_id="6" betrag="" />
      <z:row monat_id="7" betrag="" />
      <z:row monat_id="8" betrag="" />
      <z:row monat_id="9" betrag="" />
      <z:row monat_id="10" betrag="" />
      <z:row monat_id="11" betrag="" />
      <z:row monat_id="12" betrag="" />
    </auszahlung>
    <ausgabe>
      <z:row ausgabeart_id="1" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="2" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="3" b_in_abklaerung="" />
      <z:row ausgabeart_id="4" betrag="" b_in_abklaerung="" />
    </ausgabe>
    <bedarf>
      <z:row bedarfsart_id="1" betrag="" />
      <z:row bedarfsart_id="2" betrag="" />
      <z:row bedarfsart_id="3" betrag="" />
      <z:row bedarfsart_id="4" betrag="" />
      <z:row bedarfsart_id="5" betrag="" />
      <z:row bedarfsart_id="6" betrag="" />
      <z:row bedarfsart_id="7" betrag="" />
      <z:row bedarfsart_id="8" betrag="" />
      <z:row bedarfsart_id="9" betrag="" />
      <z:row bedarfsart_id="10" betrag="" />
      <z:row bedarfsart_id="11" betrag="" />
      <z:row bedarfsart_id="12" betrag="" />
      <z:row bedarfsart_id="13" betrag="" />
      <z:row bedarfsart_id="14" betrag="" />
      <z:row bedarfsart_id="15" betrag="" />
      <z:row bedarfsart_id="16" betrag="" />
      <z:row bedarfsart_id="17" betrag="" />
      <z:row bedarfsart_id="18" betrag="" />
    </bedarf>
    <zusatz>
      <z:row sh_einkommensart_id="1" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="10" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="12" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="13" betrag="" b_in_abklaerung="" />
    </zusatz>
    <massnahme>
      <z:row massnahme_id="1" wert="" kommentar="" />
      <z:row massnahme_id="2" wert="" kommentar="" />
      <z:row massnahme_id="3" wert="" kommentar="" />
      <z:row massnahme_id="4" wert="" kommentar="" />
      <z:row massnahme_id="5" wert="" kommentar="" />
      <z:row massnahme_id="6" wert="" kommentar="" />
      <z:row massnahme_id="7" wert="" kommentar="" />
      <z:row massnahme_id="8" wert="" kommentar="" />
      <z:row massnahme_id="9" wert="" kommentar="" />
      <z:row massnahme_id="10" wert="" kommentar="" />
      <z:row massnahme_id="11" wert="" kommentar="" />
      <z:row massnahme_id="12" wert="" kommentar="" />
      <z:row massnahme_id="13" wert="" kommentar="" />
      <z:row massnahme_id="14" wert="" kommentar="" />
      <z:row massnahme_id="15" wert="" kommentar="" />
      <z:row massnahme_id="16" wert="" kommentar="" />
      <z:row massnahme_id="17" wert="" kommentar="" />
      <z:row massnahme_id="18" wert="" kommentar="" />
      <z:row massnahme_id="19" wert="" kommentar="" />
      <z:row massnahme_id="20" wert="" kommentar="" />
      <z:row massnahme_id="21" wert="" kommentar="" />
      <z:row massnahme_id="22" wert="" kommentar="" />
      <z:row massnahme_id="23" wert="" kommentar="" />
      <z:row massnahme_id="24" wert="" kommentar="" />
      <z:row massnahme_id="25" wert="" kommentar="" />
      <z:row massnahme_id="26" wert="" kommentar="" />
      <z:row massnahme_id="27" wert="" kommentar="" />
      <z:row massnahme_id="28" wert="" kommentar="" />
      <z:row massnahme_id="29" wert="" kommentar="" />
      <z:row massnahme_id="30" wert="" kommentar="" />
      <z:row massnahme_id="31" wert="" kommentar="" />
    </massnahme>
    <merkmal>
      <z:row sh_merkmal_id="1" wert="" />
      <z:row sh_merkmal_id="2" wert="" />
      <z:row sh_merkmal_id="3" wert="" />
      <z:row sh_merkmal_id="4" wert="" />
      <z:row sh_merkmal_id="5" wert="" />
      <z:row sh_merkmal_id="6" wert="" />
      <z:row sh_merkmal_id="7" wert="" />
      <z:row sh_merkmal_id="8" wert="" />
      <z:row sh_merkmal_id="9" wert="" />
      <z:row sh_merkmal_id="10" wert="" />
      <z:row sh_merkmal_id="11" wert="" />
      <z:row sh_merkmal_id="12" wert="" />
      <z:row sh_merkmal_id="13" wert="" />
      <z:row sh_merkmal_id="14" wert="" />
      <z:row sh_merkmal_id="15" wert="" />
      <z:row sh_merkmal_id="16" wert="" />
      <z:row sh_merkmal_id="17" wert="" />
      <z:row sh_merkmal_id="18" wert="" />
      <z:row sh_merkmal_id="19" wert="" />
      <z:row sh_merkmal_id="20" wert="" />
      <z:row sh_merkmal_id="21" wert="" />
      <z:row sh_merkmal_id="22" wert="" />
      <z:row sh_merkmal_id="23" wert="" />
      <z:row sh_merkmal_id="24" wert="" />
      <z:row sh_merkmal_id="25" wert="" />
      <z:row sh_merkmal_id="26" wert="" />
      <z:row sh_merkmal_id="27" wert="" />
      <z:row sh_merkmal_id="28" wert="" />
      <z:row sh_merkmal_id="29" wert="" />
      <z:row sh_merkmal_id="30" wert="" />
      <z:row sh_merkmal_id="31" wert="" />
      <z:row sh_merkmal_id="32" wert="" />
      <z:row sh_merkmal_id="33" wert="" />
      <z:row sh_merkmal_id="34" wert="" />
      <z:row sh_merkmal_id="35" wert="" />
      <z:row sh_merkmal_id="36" wert="" />
      <z:row sh_merkmal_id="37" wert="" />
      <z:row sh_merkmal_id="38" wert="" />
      <z:row sh_merkmal_id="39" wert="" />
      <z:row sh_merkmal_id="40" wert="" />
      <z:row sh_merkmal_id="41" wert="" />
      <z:row sh_merkmal_id="42" wert="" />
      <z:row sh_merkmal_id="43" wert="" />
      <z:row sh_merkmal_id="44" wert="" />
      <z:row sh_merkmal_id="45" wert="" />
      <z:row sh_merkmal_id="46" wert="" />
      <z:row sh_merkmal_id="47" wert="" />
      <z:row sh_merkmal_id="48" wert="" />
      <z:row sh_merkmal_id="49" wert="" />
      <z:row sh_merkmal_id="50" wert="" />
      <z:row sh_merkmal_id="51" wert="" />
    </merkmal>
    <wbsl_einkommensart>
      <z:row sh_einkommensart_id="1" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="14" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="15" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="19" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="20" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="101" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="102" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="103" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="104" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="105" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="106" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="107" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="108" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="112" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="113" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="114" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="115" b_in_abklaerung="" />
    </wbsl_einkommensart>
    <ue>
      <person>
        <z:row ue_person_id="1" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="2" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="3" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="4" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="5" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="6" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="7" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="8" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="9" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
      </person>
      <einkommen>
        <z:row ue_person_id="1" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="13" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="4" />
      </erwerbsit>
      <skos>
        <z:row ue_person_id="1" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row ue_person_id="1" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="2" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="3" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="4" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="5" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="6" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="7" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="8" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="9" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </ue>
    <hh>
      <person>
        <z:row hh_person_id="1" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="2" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="3" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="4" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="5" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="6" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="7" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="8" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="9" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
      </person>
    </hh>
  </dossier>
</xml>')
INSERT INTO [BFSKatalogVersion] ([BFSKatalogVersionID], [Jahr], [PlausexVersion], [DossierXML]) VALUES (20110101, 2011, N'2.5.0', N'<xml xmlns:z="#RowsetSchema">
  <!-- 2.2007 konsequente Kleinschreibung aller Bezeichner. Insbesondere versichertennummer, albv_leistung (anstelle von Versichertennummer und albv_Leistung) -->
  <dossier sh_fremd_id="" b_neubezuegerrecord="">
    <z:row jahr="" gemeinde_id="" sozialleistungstraeger_id="" dossiernummer="" sh_leistungstyp_id="" wohnungsgroesse_id="" sh_wohnsituation_id="" sh_leistungsart_id="" beendigungsgrund_id="" antragsart_id="" pfleger_id="" dat_aufnahme="" anz_personen_hh="" anz_personen_ue="" anz_pflegefaelle_hh="" b_weitere_ue_einkommen="" b_vermoegensfreibetrag="" b_guthaben_pensionskasse="" b_wohneigentum="" b_frueher_unterstuetzt="" dauer_unterstuetzung_mt="" wohnkosten_inkl_nk="" betrag_bruttobedarf="" betrag_nettobedarf_skos="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" betrag_tot_ausz_krankheit="" einkommen_detail_id="" ue_monatseinkommen="" ue_monatserwerbseinkommen="" ue_monatssozialversleistungen="" ue_monatsleistungen_bedarf="" ue_monats_zusatzeinkommen="" b_bezug_stichtag="" dat_letzte_zahlung="" b_ueberbrueckung="" dat_abgeschlossen="" b_ber_skos_2005="" dat_beginn_anspruch="" b_ergaenzung_bund="" betrag_zugesprochen_el_bund="" betrag_ausbezahlt_el_bund="" b_beihilfe_kanton="" betrag_zugesprochen_beihilfe_kanton="" betrag_ausbezahlt_beihilfe_kanton="" b_zuschuss_gemeinde="" betrag_zugesprochen_zuschuss_gemeinde="" betrag_ausbezahlt_zuschuss_gemeinde="" />
    <antragsteller>
      <z:row vorname="" nachname="" frueherer_name="" geschlecht_id="" zivilstand_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" buerger_gemeinde_id="" zuzug_gem_gemeinde_id="" zuzug_gem_land_id="" zuzug_kant_land_id="" zvr_gemeinde_id="" ust_gemeinde_id="" auf_gemeinde_id="" ausbildung_id="" abgebr_ausbildung_id="" erlernter_beruf_id="" aktueller_beruf_id="" beschaeftigungsgrad_id="" branche_id="" branche_alpha_code="" branche_alpha_code_2008="" teilzeit_grund1_id="" teilzeit_grund2_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" ahv_nr="" versichertennummer="" dat_geburt="" zvr_strasse="" zvr_haus_nr="" zvr_plz="" zvr_ort="" ust_plz="" ust_ort="" auf_plz="" auf_ort="" dat_in_gemeinde_seit_jahr="" dat_in_gemeinde_seit_tag_monat="" dat_im_kanton_seit_jahr="" dat_im_kanton_seit_tag_monat="" in_ch_seit_jahr="" b_allein_im_hh="" b_arbeit_unregelmaessig="" arbeitszeit_woche="" dat_stempelbeginn="" b_ausgesteuert="" dat_ausgesteuert="" anz_arbeitslos_3j="" b_ausb_abgebrochen="" b_iv_eingliederung="" b_kk_grundversicherung="" b_kk_zusatzversicherung="" kk_name="" kk_praemie_mt="" b_kk_praemienzuschuss="" kk_zuschuss_betrag="" betrag_mietanteil="" />
      <einkommen>
        <z:row einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row einkommensart_id="14" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row erwerbsituation_id="" indx="1" />
        <z:row erwerbsituation_id="" indx="2" />
        <z:row erwerbsituation_id="" indx="3" />
        <z:row erwerbsituation_id="" indx="4" />
      </erwerbsit>
      <skos>
        <z:row bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </antragsteller>
    <auszahlung>
      <z:row monat_id="1" betrag="" />
      <z:row monat_id="2" betrag="" />
      <z:row monat_id="3" betrag="" />
      <z:row monat_id="4" betrag="" />
      <z:row monat_id="5" betrag="" />
      <z:row monat_id="6" betrag="" />
      <z:row monat_id="7" betrag="" />
      <z:row monat_id="8" betrag="" />
      <z:row monat_id="9" betrag="" />
      <z:row monat_id="10" betrag="" />
      <z:row monat_id="11" betrag="" />
      <z:row monat_id="12" betrag="" />
    </auszahlung>
    <ausgabe>
      <z:row ausgabeart_id="1" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="2" betrag="" b_in_abklaerung="" />
      <z:row ausgabeart_id="3" b_in_abklaerung="" />
      <z:row ausgabeart_id="4" betrag="" b_in_abklaerung="" />
    </ausgabe>
    <bedarf>
      <z:row bedarfsart_id="1" betrag="" />
      <z:row bedarfsart_id="2" betrag="" />
      <z:row bedarfsart_id="3" betrag="" />
      <z:row bedarfsart_id="4" betrag="" />
      <z:row bedarfsart_id="5" betrag="" />
      <z:row bedarfsart_id="6" betrag="" />
      <z:row bedarfsart_id="7" betrag="" />
      <z:row bedarfsart_id="8" betrag="" />
      <z:row bedarfsart_id="9" betrag="" />
      <z:row bedarfsart_id="10" betrag="" />
      <z:row bedarfsart_id="11" betrag="" />
      <z:row bedarfsart_id="12" betrag="" />
      <z:row bedarfsart_id="13" betrag="" />
      <z:row bedarfsart_id="14" betrag="" />
      <z:row bedarfsart_id="15" betrag="" />
      <z:row bedarfsart_id="16" betrag="" />
      <z:row bedarfsart_id="17" betrag="" />
      <z:row bedarfsart_id="18" betrag="" />
    </bedarf>
    <zusatz>
      <z:row sh_einkommensart_id="1" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="10" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="12" betrag="" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="13" betrag="" b_in_abklaerung="" />
    </zusatz>
    <massnahme>
      <z:row massnahme_id="1" wert="" kommentar="" />
      <z:row massnahme_id="2" wert="" kommentar="" />
      <z:row massnahme_id="3" wert="" kommentar="" />
      <z:row massnahme_id="4" wert="" kommentar="" />
      <z:row massnahme_id="5" wert="" kommentar="" />
      <z:row massnahme_id="6" wert="" kommentar="" />
      <z:row massnahme_id="7" wert="" kommentar="" />
      <z:row massnahme_id="8" wert="" kommentar="" />
      <z:row massnahme_id="9" wert="" kommentar="" />
      <z:row massnahme_id="10" wert="" kommentar="" />
      <z:row massnahme_id="11" wert="" kommentar="" />
      <z:row massnahme_id="12" wert="" kommentar="" />
      <z:row massnahme_id="13" wert="" kommentar="" />
      <z:row massnahme_id="14" wert="" kommentar="" />
      <z:row massnahme_id="15" wert="" kommentar="" />
      <z:row massnahme_id="16" wert="" kommentar="" />
      <z:row massnahme_id="17" wert="" kommentar="" />
      <z:row massnahme_id="18" wert="" kommentar="" />
      <z:row massnahme_id="19" wert="" kommentar="" />
      <z:row massnahme_id="20" wert="" kommentar="" />
      <z:row massnahme_id="21" wert="" kommentar="" />
      <z:row massnahme_id="22" wert="" kommentar="" />
      <z:row massnahme_id="23" wert="" kommentar="" />
      <z:row massnahme_id="24" wert="" kommentar="" />
      <z:row massnahme_id="25" wert="" kommentar="" />
      <z:row massnahme_id="26" wert="" kommentar="" />
      <z:row massnahme_id="27" wert="" kommentar="" />
      <z:row massnahme_id="28" wert="" kommentar="" />
      <z:row massnahme_id="29" wert="" kommentar="" />
      <z:row massnahme_id="30" wert="" kommentar="" />
      <z:row massnahme_id="31" wert="" kommentar="" />
    </massnahme>
    <merkmal>
      <z:row sh_merkmal_id="1" wert="" />
      <z:row sh_merkmal_id="2" wert="" />
      <z:row sh_merkmal_id="3" wert="" />
      <z:row sh_merkmal_id="4" wert="" />
      <z:row sh_merkmal_id="5" wert="" />
      <z:row sh_merkmal_id="6" wert="" />
      <z:row sh_merkmal_id="7" wert="" />
      <z:row sh_merkmal_id="8" wert="" />
      <z:row sh_merkmal_id="9" wert="" />
      <z:row sh_merkmal_id="10" wert="" />
      <z:row sh_merkmal_id="11" wert="" />
      <z:row sh_merkmal_id="12" wert="" />
      <z:row sh_merkmal_id="13" wert="" />
      <z:row sh_merkmal_id="14" wert="" />
      <z:row sh_merkmal_id="15" wert="" />
      <z:row sh_merkmal_id="16" wert="" />
      <z:row sh_merkmal_id="17" wert="" />
      <z:row sh_merkmal_id="18" wert="" />
      <z:row sh_merkmal_id="19" wert="" />
      <z:row sh_merkmal_id="20" wert="" />
      <z:row sh_merkmal_id="21" wert="" />
      <z:row sh_merkmal_id="22" wert="" />
      <z:row sh_merkmal_id="23" wert="" />
      <z:row sh_merkmal_id="24" wert="" />
      <z:row sh_merkmal_id="25" wert="" />
      <z:row sh_merkmal_id="26" wert="" />
      <z:row sh_merkmal_id="27" wert="" />
      <z:row sh_merkmal_id="28" wert="" />
      <z:row sh_merkmal_id="29" wert="" />
      <z:row sh_merkmal_id="30" wert="" />
      <z:row sh_merkmal_id="31" wert="" />
      <z:row sh_merkmal_id="32" wert="" />
      <z:row sh_merkmal_id="33" wert="" />
      <z:row sh_merkmal_id="34" wert="" />
      <z:row sh_merkmal_id="35" wert="" />
      <z:row sh_merkmal_id="36" wert="" />
      <z:row sh_merkmal_id="37" wert="" />
      <z:row sh_merkmal_id="38" wert="" />
      <z:row sh_merkmal_id="39" wert="" />
      <z:row sh_merkmal_id="40" wert="" />
      <z:row sh_merkmal_id="41" wert="" />
      <z:row sh_merkmal_id="42" wert="" />
      <z:row sh_merkmal_id="43" wert="" />
      <z:row sh_merkmal_id="44" wert="" />
      <z:row sh_merkmal_id="45" wert="" />
      <z:row sh_merkmal_id="46" wert="" />
      <z:row sh_merkmal_id="47" wert="" />
      <z:row sh_merkmal_id="48" wert="" />
      <z:row sh_merkmal_id="49" wert="" />
      <z:row sh_merkmal_id="50" wert="" />
      <z:row sh_merkmal_id="51" wert="" />
    </merkmal>
    <wbsl_einkommensart>
      <z:row sh_einkommensart_id="1" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="2" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="3" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="4" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="5" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="6" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="7" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="9" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="11" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="14" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="15" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="19" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="20" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="101" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="102" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="103" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="104" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="105" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="106" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="107" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="108" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="112" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="113" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="114" b_in_abklaerung="" />
      <z:row sh_einkommensart_id="115" b_in_abklaerung="" />
    </wbsl_einkommensart>
    <ue>
      <person>
        <z:row ue_person_id="1" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="2" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="3" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="4" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="5" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="6" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="7" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="8" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
        <z:row ue_person_id="9" ausbildung_id="" geschlecht_id="" zivilstand_id="" verwandtschaftsgrad_id="" nationalitaet_land_id="" aufenthaltsstatus_id="" beschaeftigungsgrad_id="" invaliditaetsgrad_id="" hilflosigkeitsgrad_id="" geburtsjahr="" in_ch_seit_jahr="" versichertennummer="" />
      </person>
      <einkommen>
        <z:row ue_person_id="1" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" einkommensart_id="13" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="1" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="2" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="3" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="4" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="5" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="6" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="7" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="8" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="9" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="10" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="11" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="12" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" einkommensart_id="13" betrag="" b_in_abklaerung="" />
      </einkommen>
      <erwerbsit>
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="1" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="2" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="3" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="4" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="5" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="6" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="7" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="8" erwerbsituation_id="" Indx="4" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="1" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="2" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="3" />
        <z:row ue_person_id="9" erwerbsituation_id="" Indx="4" />
      </erwerbsit>
      <skos>
        <z:row ue_person_id="1" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="1" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="2" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="3" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="4" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="5" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="6" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="7" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="8" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="21" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="22" massnahme_grund_id="" betrag="" b_in_abklaerung="" />
        <z:row ue_person_id="9" bedarfsart_id="23" betrag="" b_in_abklaerung="" />
      </skos>
      <albv_leistung>
        <z:row ue_person_id="1" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="2" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="3" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="4" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="5" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="6" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="7" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="8" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
        <z:row ue_person_id="9" antragsart_id="" betrag_zugesprochen="" dat_erste_auszahlung="" betrag_tot_auszahlungen="" b_bezug_stichtag="" dat_letzte_zahlung="" />
      </albv_leistung>
    </ue>
    <hh>
      <person>
        <z:row hh_person_id="1" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="2" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="3" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="4" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="5" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="6" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="7" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="8" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
        <z:row hh_person_id="9" verwandtschaftsgrad_id="" b_separate_unterstuetzung="" ahv_nr="" versichertennummer="" />
      </person>
    </hh>
  </dossier>
</xml>')
GO
COMMIT
GO