/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: BaRelation auf Französisch übersetzen.
  
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
-- generiert aus T:\SE\Projekte\D10 KiSS Standard\1 Projekte\JU - APEA\4 Realisierung\5 Übersetzungen\übersetzt\BaRelation_FR_mitSql.xlsx
  SELECT 1, 'parents : enfant', 'père / mère', 'enfant', 'père', 'mère', 'fils', 'fille' UNION ALL
  SELECT 2, 'frères et sœurs', 'frère / sœur', 'frère / sœur', 'frère', 'sœur', 'frère', 'sœur' UNION ALL
  SELECT 3, 'demi-frères et demi-sœurs', 'demi-frère / demi-sœur', 'demi-frère / demi-sœur', 'demi-frère', 'demi-sœur', 'demi-frère', 'demi-sœur' UNION ALL
  SELECT 4, 'grands-parents : petit-fils ou petite-fille', 'grand-père / grand-mère', 'petit-fils ou petite-fille', 'grand-père', 'grand-mère', 'petit-fils', 'petite-fille' UNION ALL
  SELECT 5, 'parents adoptifs : enfant adoptif', 'père adoptif / mère adoptive', 'enfant adoptif', 'père adoptif', 'mère adoptive', 'fils adoptif', 'fille adoptive' UNION ALL
  SELECT 6, 'famille d’accueil : enfant placé', 'père d’accueil / mère d’accueil', 'enfant placé', 'père d’accueil', 'mère d’accueil', 'garçon dont on a la garde', 'fille dont on a la garde' UNION ALL
  SELECT 7, 'beaux-parents : beau-fils ou belle-fille', 'beau-père / belle-mère', 'beau-fils ou belle-fille', 'beau-père', 'belle-mère', 'beau-fils', 'belle-fille' UNION ALL
  SELECT 8, 'beaux-parents : beaux-enfants', 'beau-père / belle-mère', 'beau-fils ou belle-fille', 'beau-père', 'belle-mère', 'beau-fils', 'belle-fille' UNION ALL
  SELECT 9, 'parents des beaux-parents : fils des beaux-enfants', 'père des beaux-parents / mère des beaux-parents', 'enfant des beaux-enfants', 'père des beaux-parents', 'mère des beaux-parents', 'fils des beaux-enfants', 'fille des beaux-enfants' UNION ALL
  SELECT 10, 'oncle / tante : neveu / nièce', 'oncle / tante', 'neveu / nièce', 'oncle', 'tante', 'neveu', 'nièce' UNION ALL
  SELECT 11, 'cousin, cousine', 'cousin / cousine', 'cousin / cousine', 'cousin', 'cousine', 'cousin', 'cousine' UNION ALL
  SELECT 12, 'beau-frère / belle-sœur', 'beau-frère / belle-sœur', 'beau-frère / belle-sœur', 'beau-frère', 'belle-sœur', 'beau-frère', 'belle-sœur' UNION ALL
  SELECT 13, 'couple marié', 'époux / épouse', 'époux / épouse', 'époux', 'épouse', 'époux', 'épouse' UNION ALL
  SELECT 14, 'partenariat légal', 'compagnon / compagne', 'compagnon / compagne', 'compagnon', 'compagne', 'compagnon', 'compagne' UNION ALL
  SELECT 15, 'couple en concubinage', 'concubin-e', 'concubin-e', 'concubin', 'concubine', 'concubin', 'concubine' UNION ALL
  SELECT 16, 'relation extraconjugale', 'compagnon / compagne', 'compagnon / compagne', 'compagnon', 'compagne', 'compagnon', 'compagne' UNION ALL
  SELECT 17, 'couple divorcé', 'ex-mari / ex-femme', 'ex-mari / ex-femme', 'ex-mari', 'ex-femme', 'ex-mari', 'ex-femme' UNION ALL
  SELECT 18, 'médecin : patient', 'patient', 'médecin', 'patient', 'patiente', 'médecin', 'médecin' UNION ALL
  SELECT 19, 'personne de confiance', 'personne de référence', 'personne de référence', 'personne de référence', 'personne de référence', 'personne de référence', 'personne de référence' UNION ALL
  SELECT 20, 'avocat', 'client-e', 'avocat / avocate', 'client', 'cliente', 'avocat', 'avocate' UNION ALL
  SELECT 21, 'amitié', 'ami-e', 'ami-e', 'ami', 'amie', 'ami', 'amie' UNION ALL
  SELECT 22, 'inimitié', 'ennemi-e', 'ennemi-e', 'ennemi', 'ennemie', 'ennemi', 'ennemie' UNION ALL
  SELECT 23, 'parrain / marraine : filleul-e', 'parrain / marraine', 'filleul-e', 'parrain', 'marraine', 'filleul', 'filleule' UNION ALL
  SELECT 24, 'parents des beaux-parents : enfant des beaux-enfants', 'père des beaux-parents / mère des beaux-parents', 'enfant des beaux-enfants', 'père des beaux-parents', 'mère des beaux-parents', 'fils des beaux-enfants', 'fille des beaux-enfants' UNION ALL
  SELECT 25, 'personne chargée de l’encadrement : personne encadrée', 'personne chargée de l’encadrement', 'personne encadrée', 'personne chargée de l’encadrement', 'personne chargée de l’encadrement', 'personne encadrée', 'personne encadrée' UNION ALL
  SELECT 26, 'conseiller / conseillère : personne conseillée', 'conseiller / conseillère', 'personne conseillée', 'conseiller', 'conseillère', 'personne conseillée', 'personne conseillée' UNION ALL
  SELECT 27, 'curateur / curatrice : personne placée sous curatelle', 'curateur / curatrice', 'personne placée sous curatelle', 'curateur', 'curatrice', 'personne placée sous curatelle', 'personne placée sous curatelle' UNION ALL
  SELECT 28, 'personne avec obligations alimentaires : Alimentenberechtigte/-r', 'personne avec obligations alimentaires', 'personne touchant une pension alimentaire', 'personne avec obligations alimentaires', 'personne avec obligations alimentaires', 'personne touchant une pension alimentaire', 'personne touchant une pension alimentaire' UNION ALL
  SELECT 29, 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre', 'inconnu / autre' UNION ALL
  SELECT 30, 'tuteur / tutrice : personne sous tutelle', 'tuteur / tutrice', 'personne sous tutelle', 'tuteur', 'tutrice', 'personne sous tutelle', 'personne sous tutelle' UNION ALL
  SELECT 31, 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré', 'partenaire en partenariat enregistré' 
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
