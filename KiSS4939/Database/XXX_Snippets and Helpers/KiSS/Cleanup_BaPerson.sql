DELETE FROM FaAktennotizen;
DELETE FROM FaDokumente;

DISABLE TRIGGER trHist_BaAdresse ON BaAdresse;
DELETE FROM BaAdresse;
DELETE FROM Hist_BaAdresse;
ENABLE TRIGGER trHist_BaAdresse ON BaAdresse;

DELETE FROM KbBuchung;
DELETE FROM BgAuszahlungPerson;
DELETE FROM BaZahlungsweg;
DELETE FROM BaWVCode;
DELETE FROM BgFinanzplan_BaPerson;
DELETE FROM BgPosition;
DELETE FROM BgSpezkonto;
DELETE FROM BgBudget;
DELETE FROM BgFinanzplan;
DELETE FROM FaLeistung;

DISABLE TRIGGER trHist_BaPerson ON BaPerson;
DELETE FROM BaPerson;
DELETE FROM Hist_BaPerson;
ENABLE TRIGGER trHist_BaPerson ON BaPerson;

DELETE FROM BaInstitution_BaInstitutionTyp;
DELETE FROM BaInstitutionKontakt;
DELETE FROM BaInstitution;
