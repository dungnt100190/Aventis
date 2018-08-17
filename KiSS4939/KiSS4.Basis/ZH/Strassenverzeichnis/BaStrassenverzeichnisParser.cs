using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KiSS4.Basis.ZH.Strassenverzeichnis
{
    public class BaStrassenverzeichnisParser
    {
        public static BaStrasseHausDTO[] ReadStrassenverzeichnis(Stream stream)
        {
            Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(stream, Encoding.GetEncoding(1252));
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(";");
            List<BaStrasseHausDTO> lines = new List<BaStrasseHausDTO>();
            //int id = 1;
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                BaStrasseHausDTO dto = ConvertFieldsToDTO(fields);
                if (dto != null)
                {
                    //dto.ID = id++;
                    lines.Add(dto);
                }
            }
            // Legende entfernen
            if (lines.Count > 0 && lines[0].ParseError != null)
            {
                lines.Remove(lines[0]);
            }
            return lines.ToArray();

        }

        private static BaStrasseHausDTO ConvertFieldsToDTO(string[] fields)
        {
            //fixe Struktur: ID;Strasse;Hausnr;-Zusatz;Kreis;Quartier;Zone;StatZone;Quartiername;PLZ;Sozialzentrum;Quartierteam
            //               0 ;1      ;2     ;3      ;4    ;5       ;6   ;7       ;8          ;9   ;10           ;11
            BaStrasseHausDTO dto = new BaStrasseHausDTO();
            if (fields.Length < 12)
            {
                dto.ParseError = "Ungültige Struktur, es sind 12 Spalten nötig: ID;Strasse;Hausnr;-Zusatz;Kreis;Quartier;Zone;StatZone;Quartiername;PLZ;Sozialzentrum;Quartierteam";
                return dto;
            }

            int parseInt;
            if (!int.TryParse(fields[0], out parseInt))
            {
                dto.ParseError = "Feld 1 (Strassen-ID) enthält keine Zahl";
                return dto;
            }
            dto.BaStrasseID = parseInt;
            dto.StrassenName = fields[1];

            if (!int.TryParse(fields[2], out parseInt))
            {
                if (string.IsNullOrEmpty(fields[2]))
                {
                    // Einige Strassen/Plätze werden ohne Hausnummern und Attribute aufgeführt -> Ignorieren
                    return null;
                }
                else
                {
                    dto.ParseError = "Feld 3 (Hausnummer) enthält keine Zahl";
                }
                return dto;
            }
            dto.Hausnummer = parseInt;
            dto.Suffix = fields[3];

            // Kreis
            if (!int.TryParse(fields[4], out parseInt))
            {
                dto.ParseError = "Feld 5 (Kreis) enthält keine Zahl";
                return dto;
            }
            dto.Kreis = parseInt;

            // Quartier
            if (!int.TryParse(fields[5], out parseInt))
            {
                dto.ParseError = "Feld 6 (Quartier) enthält keine Zahl";
                return dto;
            }
            dto.Quartier = parseInt;

            // Zone
            if (!int.TryParse(fields[6], out parseInt))
            {
                dto.ParseError = "Feld 7 (Zone) enthält keine Zahl";
                return dto;
            }
            dto.Zone = parseInt;

            // Statistische Zone
            if (!int.TryParse(fields[7], out parseInt))
            {
                dto.ParseError = "Feld 8 (Statistische Zone) enthält keine Zahl";
                return dto;
            }
            dto.StatistischeZone = parseInt;

            // PLZ
            if (!int.TryParse(fields[9], out parseInt))
            {
                dto.ParseError = "Feld 10 (PLZ) enthält keine Zahl";
                return dto;
            }
            dto.PLZ = parseInt;

            dto.QuartierTeam = fields[11];
            return dto;
        }
    }
}
