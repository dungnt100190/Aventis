/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: BaRelation auf Franz�sisch �bersetzen.
  
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- translate BaRelation
-------------------------------------------------------------------------------

;WITH RelationCte (BaRelationID, NameRelation, NameGenerisch1, NameGenerisch2, NameMaennlich1, NameWeiblich1, NameMaennlich2, NameWeiblich2) AS
(
-- generiert aus T:\SE\Projekte\D10 KiSS Standard\1 Projekte\JU - APEA\4 Realisierung\5 �bersetzungen\�bersetzt\BaRelation_FR_mitSql.xlsx
  SELECT 1, 'parents : enfant', 'p�re / m�re', 'enfant', 'p�re', 'm�re', 'fils', 'fille' UNION ALL
  SELECT 2, 'fr�res et s�urs', 'fr�re / s�ur', 'fr�re / s�ur', 'fr�re', 's�ur', 'fr�re', 's�ur' UNION ALL
  SELECT 3, 'demi-fr�res et demi-s�urs', 'demi-fr�re / demi-s�ur', 'demi-fr�re / demi-s�ur', 'demi-fr�re', 'demi-s�ur', 'demi-fr�re', 'demi-s�ur' UNION ALL
  SELECT 4, 'grands-parents�: petit-fils ou petite-fille', 'grand-p�re / grand-m�re', 'petit-fils ou petite-fille', 'grand-p�re', 'grand-m�re', 'petit-fils', 'petite-fille' UNION ALL
  SELECT 5, 'parents adoptifs�: enfant adoptif', 'p�re adoptif / m�re adoptive', 'enfant adoptif', 'p�re adoptif', 'm�re adoptive', 'fils adoptif', 'fille adoptive' UNION ALL
  SELECT 6, 'famille d�accueil�: enfant plac�', 'p�re d�accueil / m�re d�accueil', 'enfant plac�', 'p�re d�accueil', 'm�re d�accueil', 'gar�on dont on a la garde', 'fille dont on a la garde' UNION ALL
  SELECT 7, 'beaux-parents�: beau-fils ou belle-fille', 'beau-p�re / belle-m�re', 'beau-fils ou belle-fille', 'beau-p�re', 'belle-m�re', 'beau-fils', 'belle-fille' UNION ALL
  SELECT 8, 'beaux-parents�: beaux-enfants', 'beau-p�re / belle-m�re', 'beau-fils ou belle-fille', 'beau-p�re', 'belle-m�re', 'beau-fils', 'belle-fille' UNION ALL
  SELECT 9, 'parents des beaux-parents�: fils des beaux-enfants', 'p�re des beaux-parents / m�re des beaux-parents', 'enfant des beaux-enfants', 'p�re des beaux-parents', 'm�re des beaux-parents', 'fils des beaux-enfants', 'fille des beaux-enfants' UNION ALL
  SELECT 10, 'oncle / tante�: neveu / ni�ce', 'oncle / tante', 'neveu / ni�ce', 'oncle', 'tante', 'neveu', 'ni�ce' UNION ALL
  SELECT 11, 'cousin, cousine', 'cousin / cousine', 'cousin / cousine', 'cousin', 'cousine', 'cousin', 'cousine' UNION ALL
  SELECT 12, 'beau-fr�re / belle-s�ur', 'beau-fr�re / belle-s�ur', 'beau-fr�re / belle-s�ur', 'beau-fr�re', 'belle-s�ur', 'beau-fr�re', 'belle-s�ur' UNION ALL
  SELECT 13, 'couple mari�', '�poux / �pouse', '�poux / �pouse', '�poux', '�pouse', '�poux', '�pouse' UNION ALL
  SELECT 14, 'partenariat l�gal', 'compagnon / compagne', 'compagnon / compagne', 'compagnon', 'compagne', 'compagnon', 'compagne' UNION ALL
  SELECT 15, 'couple en concubinage', 'concubin-e', 'concubin-e', 'concubin', 'concubine', 'concubin', 'concubine' UNION ALL
  SELECT 16, 'relation extraconjugale', 'compagnon / compagne', 'compagnon / compagne', 'compagnon', 'compagne', 'compagnon', 'compagne' UNION ALL
  SELECT 17, 'couple divorc�', 'ex-mari / ex-femme', 'ex-mari / ex-femme', 'ex-mari', 'ex-femme', 'ex-mari', 'ex-femme' UNION ALL
  SELECT 18, 'm�decin�: patient', 'patient', 'm�decin', 'patient', 'patiente', 'm�decin', 'm�decin' UNION ALL
  SELECT 19, 'personne de confiance', 'personne de r�f�rence', 'personne de r�f�rence', 'personne de r�f�rence', 'personne de r�f�rence', 'personne de r�f�rence', 'personne de r�f�rence' UNION ALL
  SELECT 20, 'avocat', 'client-e', 'avocat / avocate', 'client', 'cliente', 'avocat', 'avocate' UNION ALL
  SELECT 21, 'amiti�', 'ami-e', 'ami-e', 'ami', 'amie', 'ami', 'amie' UNION ALL
  SELECT 22, 'inimiti�', 'ennemi-e', 'ennemi-e', 'ennemi', 'ennemie', 'ennemi', 'ennemie' UNION ALL
  SELECT 23, 'parrain / marraine�: filleul-e', 'parrain / marraine', 'filleul-e', 'parrain', 'marraine', 'filleul', 'filleule' UNION ALL
  SELECT 24, 'parents des beaux-parents�: enfant des beaux-enfants', 'p�re des beaux-parents / m�re des beaux-parents', 'enfant des beaux-enfants', 'p�re des beaux-parents', 'm�re des beaux-parents', 'fils des beaux-enfants', 'fille des beaux-enfants' UNION ALL
  SELECT 25, 'personne charg�e de l�encadrement�: personne encadr�e', 'personne charg�e de l�encadrement', 'personne encadr�e', 'personne charg�e de l�encadrement', 'personne charg�e de l�encadrement', 'personne encadr�e', 'personne encadr�e' UNION ALL
  SELECT 26, 'conseiller / conseill�re�: personne conseill�e', 'conseiller / conseill�re', 'personne conseill�e', 'conseiller', 'conseill�re', 'personne conseill�e', 'personne conseill�e' UNION ALL
  SELECT 27, 'curateur / curatrice�: personne plac�e sous curatelle', 'curateur / curatrice', 'personne plac�e sous curatelle', 'curateur', 'curatrice', 'personne plac�e sous curatelle', 'personne plac�e sous curatelle' UNION ALL
  SELECT 28, 'personne avec obligations alimentaires : Alimentenberechtigte/-r', 'personne avec obligations alimentaires', 'personne touchant une pension alimentaire', 'personne avec obligations alimentaires', 'personne avec obligations alimentaires', 'personne touchant une pension alimentaire', 'personne touchant une pension alimentaire' UNION ALL
  SELECT 29, 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre' UNION ALL
  SELECT 30, 'tuteur / tutrice�: personne sous tutelle', 'tuteur / tutrice', 'personne sous tutelle', 'tuteur', 'tutrice', 'personne sous tutelle', 'personne sous tutelle' UNION ALL
  SELECT 31, 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�', 'partenaire en partenariat enregistr�' 
)

--SELECT 
--  CTE.BaRelationID, 
--  REL.NameRelation, 
--  CTE.NameRelation, 
--  REL.NameGenerisch1, 
--  CTE.NameGenerisch1, 
--  REL.NameGenerisch2, 
--  CTE.NameGenerisch2, 
--  REL.NameMaennlich1, 
--  CTE.NameMaennlich1, 
--  REL.NameWeiblich1, 
--  CTE.NameWeiblich1, 
--  REL.NameMaennlich2, 
--  CTE.NameMaennlich2, 
--  REL.NameWeiblich2,
--  CTE.NameWeiblich2
UPDATE REL
  SET NameRelation   = CTE.NameRelation, 
      NameGenerisch1 = CTE.NameGenerisch1, 
      NameGenerisch2 = CTE.NameGenerisch2, 
      NameMaennlich1 = CTE.NameMaennlich1, 
      NameWeiblich1  = CTE.NameWeiblich1, 
      NameMaennlich2 = CTE.NameMaennlich2, 
      NameWeiblich2  = CTE.NameWeiblich2
FROM RelationCte CTE
  INNER JOIN dbo.BaRelation REL ON REL.BaRelationID = CTE.BaRelationID

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
