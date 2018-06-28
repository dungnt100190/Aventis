using System;
using System.Linq;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Authentication.UserId;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.ErrorHandling;
using Kiss4Web.Infrastructure.ErrorHandling.Questions;
using Kiss4Web.Infrastructure.I18N;
using Kiss4Web.Infrastructure.Kiss4Configuration;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model;
using Kiss4Web.Model.Fibu;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Modules.Fibu.Buchungen
{
    public class SaveBuchungCommandHandler : TypedMessageHandler<SaveBuchungCommand>
    {
        public const string ZahlwegNichtErfasstQuestionIdentifier = "DtaQuestion";
        private readonly IRepository<FbBelegNr> _belegnummern;
        private readonly IRepository<FbBuchung> _buchungen;
        private readonly IKiss4Configuration _configuration;
        private readonly IQueryable<FbKonto> _konten;
        private readonly IQueryable<FbPeriode> _perioden;
        private readonly IQueryable<FbTeamMitglied> _teamMitglieder;
        private readonly IKiss4TranslationProvider _translationProvider;
        private readonly IUserIdProvider _userIdProvider;

        public SaveBuchungCommandHandler(IUserIdProvider userIdProvider,
                                         IQueryable<FbPeriode> perioden,
                                         IQueryable<FbKonto> konten,
                                         IQueryable<FbTeamMitglied> teamMitglieder,
                                         IKiss4TranslationProvider translationProvider,
                                         IRepository<FbBuchung> buchungen,
                                         IRepository<FbBelegNr> belegnummern,
                                         IKiss4Configuration configuration)
        {
            _userIdProvider = userIdProvider;
            _perioden = perioden;
            _konten = konten;
            _teamMitglieder = teamMitglieder;
            _translationProvider = translationProvider;
            _buchungen = buchungen;
            _belegnummern = belegnummern;
            _configuration = configuration;
        }

        public override async Task Handle(SaveBuchungCommand command)
        {
            var buchung = command.Buchung;
            buchung.UserId = _userIdProvider.UserId;
            buchung.ValutaDatum = buchung.ValutaDatum ?? buchung.BuchungsDatum;

            var baPersonId = await _perioden.Where(per => per.FbPeriodeId == buchung.FbPeriodeId)
                                            .Select(per => (int?)per.BaPersonId)
                                            .FirstOrDefaultAsync();
            if (!baPersonId.HasValue)
            {
                throw new Exception($"Invalid FbPeriodeId {buchung.FbPeriodeId}");
            }

            await ValidatePeriodeStatus(buchung, baPersonId.Value);
            var teamId = await GetFbTeamId(buchung.FbPeriodeId);
            if (!await ValidateKontoErlaubnis(buchung.SollKtoNr, teamId, buchung.FbPeriodeId))
            {
                var text = await _translationProvider.GetText("CtlFibuBuchung", "BerechtigungSollFehlt") ?? "Die Berechtigung für den KontoTyp des Soll-Kontos fehlt!";
                throw new InsufficientPermissionException(text);
            }
            if (!await ValidateKontoErlaubnis(buchung.HabenKtoNr, teamId, buchung.FbPeriodeId))
            {
                var text = await _translationProvider.GetText("CtlFibuBuchung", "BerechtigungHabenFehlt") ?? "Die Berechtigung für den KontoTyp des Haben-Kontos fehlt!";
                throw new InsufficientPermissionException(text);
            }

            if (buchung.ZahlungsArtCode == FbZahlungsart.OrangerEinzahlungsschein
             || buchung.ZahlungsArtCode == FbZahlungsart.BlauOrangeEsrÜberBank_Inaktiv)
            {
                // keep referenznummer, remove zahlungsgrund
                buchung.Zahlungsgrund = null;
            }
            else
            {
                // keep zahlungsgrund, remove referenznummer
                buchung.ReferenzNummer = null;
            }

            await ValidateZahlungsgrund(buchung.Zahlungsgrund);

            if (command.DtaQuestion != true
                && buchung.FbBuchungId == 0
                && buchung.FbZahlungswegId == null)
            {
                var isDtaAccount = (await _konten.FirstOrDefaultAsync(kto => kto.FbPeriodeId == buchung.FbPeriodeId
                                                                            && kto.KontoNr == buchung.HabenKtoNr))?.FbDtazugangId != null;
                if (isDtaAccount)
                {
                    // FbZahlungswegId == null if HabenKonto is a DTA account is valid, but an exception
                    // the user might have forgotten to set Zahlungsweg, so better ask
                    var question = await _translationProvider.GetText("CtlFibuBuchung", "ZahlungswegNichtErfasst") ?? "Im Haben steht ein Konto mit DTA-Zugang, ein Zahlungsweg ist aber nicht erfasst!\r\n\r\nTrotzdem speichern ?";
                    throw new YesNoQuestionException(question, ZahlwegNichtErfasstQuestionIdentifier);
                }
            }

            // HACK: the process in KiSS4 FiBu to generate BelegNr is a bit shaky and has to be refactored
            // for now, we just port the whole shaky thing
            var belegNrProMandant = await _configuration.GetConfigValue(ConfigNodes.System_Fibu_Buchen_GenerateBelegNrProMandant);
            var belegNr = belegNrProMandant ? await _belegnummern.FirstOrDefaultAsync(bnr => bnr.BaPersonId == baPersonId)
                                            : await _belegnummern.FirstOrDefaultAsync(bnr => bnr.UserId == _userIdProvider.UserId);
            if (belegNr != null)
            {
                var nextBelegNrText = $"{belegNr.Praefix}{belegNr.NaechsteBelegNr}";
                // Falls vorgeschlagene BelegNr unverändert: BelegNr hochzählen
                if (nextBelegNrText == buchung.BelegNr)
                {
                    belegNr.NaechsteBelegNr += 1;
                }
            }

            await _buchungen.InsertOrUpdateEntity(buchung);
        }

        private Task<int?> GetFbTeamId(int periodeId)
        {
            return _perioden.Where(per => per.FbPeriodeId == periodeId)
                            .Select(per => per.FbTeamId)
                            .FirstAsync();
        }

        private async Task<bool> ValidateKontoErlaubnis(int? kontoNummer, int? teamId, int periodeId)
        {
            if (!kontoNummer.HasValue || !teamId.HasValue || _userIdProvider.IsUserAdmin)
            {
                return true;
            }

            var kontotyp = await _konten.Where(kto => kto.KontoNr == kontoNummer.Value &&
                                                      kto.FbPeriodeId == periodeId)
                                        .Select(kto => (KontoTyp?)kto.KontoTypCode)
                                        .FirstOrDefaultAsync();
            if (!kontotyp.HasValue)
            {
                return true;
            }

            var authorizations = await _teamMitglieder.FirstOrDefaultAsync(tmi => tmi.FbTeamId == teamId);
            switch (kontotyp.Value)
            {
                case KontoTyp.DepotKonto:
                case KontoTyp.WertschriftKonto:
                    {
                        return authorizations.DepotBereich == true;
                    }
                case KontoTyp.TransferKonto:
                    {
                        return authorizations.StandardBereich == true
                            || authorizations.DepotBereich == true;
                    }
                default:
                    {
                        return authorizations.StandardBereich == true;
                    }
            }
        }

        private async Task ValidatePeriodeStatus(FbBuchung buchung, int baPersonId)
        {
            var aktivePeriode = await _perioden.Where(per => per.BaPersonId == baPersonId
                                                          && per.PeriodeVon <= buchung.BuchungsDatum
                                                          && per.PeriodeBis >= buchung.BuchungsDatum)
                                               .FirstOrDefaultAsync();
            if (aktivePeriode == null)
            {
                var text = string.Format(await _translationProvider.GetText("CtlFibuBuchung", "KeineAktivePeriode") ?? "Keine aktive Periode gefunden für den {0}!", buchung.BuchungsDatum.ToShortDateString());
                throw new ValidationException(text);
            }

            switch (aktivePeriode.PeriodeStatusCode)
            {
                case FbPeriodeStatus.Aktiv:
                    {
                        buchung.FbPeriodeId = aktivePeriode.FbPeriodeId;
                        break;
                    }
                case FbPeriodeStatus.Inaktiv:
                    {
                        var text = string.Format(await _translationProvider.GetText("CtlFibuBuchung", "PeriodeInaktiv") ?? "Die zutreffende Periode für den {0} ist inaktiv!", buchung.BuchungsDatum.ToShortDateString());
                        throw new ValidationException(text);
                    }
                case FbPeriodeStatus.Abgeschlossen:
                    {
                        var text = string.Format(await _translationProvider.GetText("CtlFibuBuchung", "PeriodeAbgeschlossen") ?? "Die zutreffende Periode für den {0} ist abgeschlossen!", buchung.BuchungsDatum.ToShortDateString());
                        throw new ValidationException(text);
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task ValidateZahlungsgrund(string zahlungsgrund)
        {
            if (zahlungsgrund == null)
            {
                return;
            }

            zahlungsgrund = zahlungsgrund.Replace("\r\n", "\n");
            var lines = zahlungsgrund.Split('\n');
            if (lines.Length > 4)
            {
                var text = await _translationProvider.GetText("CtlFibuBuchung", "MaxVierLinien") ?? "Der Zahlungsgrund darf maximal 4 Linien umfassen!";
                throw new ValidationException(text);
            }

            var linesTooLong = lines.Where(line => line.Length > 35).ToList();
            if (linesTooLong.Any())
            {
                var errorText = string.Empty;
                foreach (var lineTooLong in linesTooLong)
                {
                    errorText += string.Format(await _translationProvider.GetText("CtlFibuBuchung", "LinieZuLang") ?? "Zahlungsgrund: Die Linie '{0}' ist länger als 35 Zeichen!\r\nEventuell Zeilenumbrüche einfügen mit der Enter-Taste", lineTooLong);
                }
                throw new ValidationException(errorText);
            }
        }
    }
}