using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Kiss.UI.Controls.Converter
{
    public class PostkontoNrFormattingConverter : IMultiValueConverter, IValueConverter
    {
        /// <summary>
        /// Konversion von Bankkonto- oder Postkonto-Nummer.
        /// Value#1: Postkonto-Nummer
        /// Value#2: Bankkonto-Nummer
        /// Priorität hat die Postkonto-Nummer. Das heisst: wenn sowohl eine Postkonto- als auch
        /// eine Bankkonto-Nummer übergeben wird, wird die Postkonto-Nummer formattiert und zurückgegeben.
        /// Die Bankkonto-Nummer wird unverändert zurückgegeben.
        /// 
        /// Es gelten die gleichen Regeln wie beim IValueConverter:
        /// Konversion von 5- oder 9-stelliger unformattierter PC-Nummer in formattierte PC-Nummer.
        /// Die Länge der unformattierten PC-Nummer definiert das Ausgabeformat.
        /// 5-stellig: xxxxx
        /// 9-stellig: xx-xxxxx-x
        /// </summary>
        /// <param name="values">Value#1: Postkonto-Nummer; Value#2: Bankkonto-Nummer</param>
        /// <param name="targetType">ignoriert</param>
        /// <param name="parameter">ignoriert</param>
        /// <param name="culture">ignoriert</param>
        /// <returns>Formattierte Postkonto-Nummer, falls nicht null; sonst: Bankkonto-Nummer</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values.Length < 2)
            {
                return null;
            }

            string postkontoNrUnformatted = values[0] as string;
            string bankkontoNrUnformatted = values[1] as string;

            if(!string.IsNullOrEmpty(postkontoNrUnformatted))
            {
                return Convert(postkontoNrUnformatted, typeof(string), parameter, culture);
            }

            return bankkontoNrUnformatted;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //not supported
            return null;
        }

        /// <summary>
        /// Konversion von 5- oder 9-stelliger unformattierter PC-Nummer in formattierte PC-Nummer.
        /// Die Länge der unformattierten PC-Nummer definiert das Ausgabeformat.
        /// 5-stellig: xxxxx
        /// 9-stellig: xx-xxxxx-x
        /// </summary>
        /// <param name="value">unformatierte PC-Nummer</param>
        /// <param name="targetType">ignoriert</param>
        /// <param name="parameter">ignoriert</param>
        /// <param name="culture">ignoriert</param>
        /// <returns>Formattierte PC-Nummer</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Konversion von 5-stellig/9-stellig unformattierte PC-Nummer in formattierte PC-Nummer (format: xx-xxxxx-x)
            string postkontoUnformatted = value as string;
            if (string.IsNullOrEmpty(postkontoUnformatted))
                return null;

            if (postkontoUnformatted.Length == 9)
            {
                string prefix = postkontoUnformatted.Substring(0, 2);
                string suffix = postkontoUnformatted.Substring(postkontoUnformatted.Length - 1);
                string midPart = postkontoUnformatted.Substring(2, postkontoUnformatted.Length - 3);

                midPart = midPart.TrimStart('0');

                return prefix + "-" + midPart + "-" + suffix;
            }

            //postkontoUnformatted ist eine 5-stellige Teilnehmer-Nummer
            return postkontoUnformatted;
        }

        /// <summary>
        /// Konversion von formattierter PC-Nr in unformatierte PC-Nr mit Padding.
        /// Das Format der formattierten PC-Nr definiert die Länge des Ausgabeformat.
        /// 
        /// Ohne Bindestriche und 5-stellig: xxxxx
        /// Mit Bindestrichen (aa-b..b-c):   aabbbbbbc
        /// Der mittlere Bereich (b...b) ist im Ausgabeformat immer 6-stellig und wird gegebenenfalls
        /// mit führenden Nullen gepadded:   aa000bbbc
        /// </summary>
        /// <param name="value">formatierte PC-Nummer</param>
        /// <param name="targetType">ignoriert</param>
        /// <param name="parameter">ignoriert</param>
        /// <param name="culture">ignoriert</param>
        /// <returns>Formattierte PC-Nummer</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Konversion von formattierter PC-Nr in unformatierte PC-Nr mit Padding
            //Format: aa-bb-c -> aabbbbbbc
            //                   a: 2 Stellen
            //                   b: 6 Stellen
            //                   c: 1 Stelle
            //gegebenenfalls wird der b-Bereich mit führenden Nullen gepadded, so dass er in jedem Fall
            //6 Stellen umfasst.
            //
            //5-stellige Teilnehmer-Nummern werden as-is zurückgegeben

            string postkontoFormatted = value as string;
            if (string.IsNullOrEmpty(postkontoFormatted))
                return null;

            if(!postkontoFormatted.Contains("-"))
            {
                if(postkontoFormatted.Length != 5)
                {
                    //invalid format
                    throw new FormatException("Teilnehmernummer muss 5-stellig sein.");
                }

                //5-stellige Teilnehmer-Nummern werden as-is zurückgegeben
                return postkontoFormatted;
            }

            var nummernGruppen = postkontoFormatted.Split('-');
            if(nummernGruppen.Length != 3)
            {
                //invalid format
                throw new FormatException("Postkonto muss im Format xx-yy-z eingegeben werden.");
            }

            //gegebenenfalls wird der mittlere Bereich gepadded, so dass er in jedem Fall 6 Stellen umfasst
            string midPart = nummernGruppen[1].PadLeft(6, '0');

            return nummernGruppen[0] + midPart + nummernGruppen[2];
        }
    }
}
