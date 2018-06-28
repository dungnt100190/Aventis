using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kiss4Web.Infrastructure.DocumentCreation
{
    public class SqlParameterReplacer
    {
        private readonly List<string> _parameterNames = new List<string>();

        public (string sql, IEnumerable<string> parameterNames) ReformatParametersFromKissToDapper(string sql)
        {
            _parameterNames.Clear();
            var rgxContextPrm = new Regex(@"{([^{}]*)}");
            return (rgxContextPrm.Replace(sql, ReformatParameterKissToDapper), _parameterNames);
        }

        private string ReformatParameterKissToDapper(Match match)
        {
            var parameterName = match.Groups[1].Value;
            _parameterNames.Add(parameterName);
            return $"@{parameterName}";
        }
    }
}