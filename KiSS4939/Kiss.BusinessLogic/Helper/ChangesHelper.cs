using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using log4net;

namespace Kiss.BusinessLogic.Helper
{
    public class ChangesHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ChangesHelper()
        {
            Changes = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Changes { get; set; }

        public void SetPropertyAndGetChanges<T>(T target, Expression<Func<T, DateTime?>> targetExpr, DateTime? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as DateTime?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                const string format = "dd.MM.yyyy";
                var targetString = targetProperty.HasValue ? targetProperty.Value.ToString(format) : "-";
                var sourceString = sourceProperty.HasValue ? sourceProperty.Value.ToString(format) : "-";
                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        public void SetPropertyAndGetChanges<T>(T target, Expression<Func<T, decimal?>> targetExpr, decimal? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as decimal?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                var targetString = targetProperty.HasValue ? targetProperty.Value.ToString(CultureInfo.InvariantCulture) : "-";
                var sourceString = sourceProperty.HasValue ? sourceProperty.Value.ToString(CultureInfo.InvariantCulture) : "-";
                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        public void SetPropertyAndGetChanges<T>(T target, Expression<Func<T, int?>> targetExpr, int? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as int?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                var targetString = targetProperty.HasValue ? targetProperty.Value.ToString(CultureInfo.InvariantCulture) : "-";
                var sourceString = sourceProperty.HasValue ? sourceProperty.Value.ToString(CultureInfo.InvariantCulture) : "-";
                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        public void SetPropertyAndGetChanges<T>(T target, Expression<Func<T, string>> targetExpr, string sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as string;
            if (HasChanged(targetProperty, sourceProperty))
            {
                AddChangeString(prop.Name, propertyText, targetProperty, sourceProperty);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        public void SetPropertyAndGetChanges<T>(T target, Expression<Func<T, bool?>> targetExpr, bool? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as bool?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                var targetString = targetProperty.HasValue ? targetProperty.Value ? "Ja" : "Nein" : "-";
                var sourceString = sourceProperty.HasValue ? sourceProperty.Value ? "Ja" : "Nein" : "-";
                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        // TODO Refactoring
        public void SetPropertyAndGetChangesTextFromGemeinde<T>(T target, Expression<Func<T, int?>> targetExpr, int? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as int?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                string targetString;
                if (targetProperty.HasValue)
                {
                    var gemeindeService = Container.Resolve<BaGemeindeService>();
                    var gemeinde = gemeindeService.GetEntityById(targetProperty.Value);
                    if (gemeinde != null)
                    {
                        targetString = gemeinde.Name;
                    }
                    else
                    {
                        targetString = targetProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    targetString = "-";
                }

                string sourceString;
                if (sourceProperty.HasValue)
                {
                    var gemeindeService = Container.Resolve<BaGemeindeService>();
                    var gemeinde = gemeindeService.GetEntityById(sourceProperty.Value);
                    if (gemeinde != null)
                    {
                        sourceString = gemeinde.Name;
                    }
                    else
                    {
                        sourceString = sourceProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    sourceString = "-";
                }

                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        public void SetPropertyAndGetChangesTextFromGemeindeHeimatort<T>(T target, Expression<Func<T, string>> targetExpr, string sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as string;
            if (HasChanged(targetProperty, sourceProperty))
            {
                var targetString = GetGemeindeNameFromIds(targetProperty);
                var sourceString = GetGemeindeNameFromIds(sourceProperty);

                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        // TODO Refactoring
        public void SetPropertyAndGetChangesTextFromLand<T>(T target, Expression<Func<T, int?>> targetExpr, int? sourceProperty, string propertyText)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as int?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                string targetString;
                if (targetProperty.HasValue)
                {
                    var landService = Container.Resolve<BaLandService>();
                    var land = landService.GetEntityById(targetProperty.Value);
                    if (land != null)
                    {
                        targetString = land.Text;
                    }
                    else
                    {
                        targetString = targetProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    targetString = "-";
                }

                string sourceString;
                if (sourceProperty.HasValue)
                {
                    var landService = Container.Resolve<BaLandService>();
                    var land = landService.GetEntityById(sourceProperty.Value);
                    if (land != null)
                    {
                        sourceString = land.Text;
                    }
                    else
                    {
                        sourceString = sourceProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    sourceString = "-";
                }

                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        // TODO Refactoring
        public void SetPropertyAndGetChangesTextFromLov<T>(T target, Expression<Func<T, int?>> targetExpr, int? sourceProperty, string propertyText, string lovName)
        {
            var prop = GetPropertyInfo(targetExpr);
            _log.DebugFormat("targetPropertyName = {0}", prop.Name);
            var targetProperty = prop.GetValue(target, null) as int?;
            if (HasChanged(targetProperty, sourceProperty))
            {
                string targetString;
                if (targetProperty.HasValue)
                {
                    var lovService = Container.Resolve<XLovService>();
                    var lovCode = lovService.GetSingleLovCode(lovName, targetProperty.Value);
                    if (lovCode != null)
                    {
                        targetString = lovCode.Text;
                    }
                    else
                    {
                        targetString = targetProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    targetString = "-";
                }

                string sourceString;
                if (sourceProperty.HasValue)
                {
                    var lovService = Container.Resolve<XLovService>();
                    var lovCode = lovService.GetSingleLovCode(lovName, sourceProperty.Value);
                    if (lovCode != null)
                    {
                        sourceString = lovCode.Text;
                    }
                    else
                    {
                        sourceString = sourceProperty.Value.ToString(CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    sourceString = "-";
                }

                AddChangeString(prop.Name, propertyText, targetString, sourceString);
            }

            prop.SetValue(target, sourceProperty, null);
        }

        private static string GetGemeindeNameFromIds(string ids)
        {
            string returnString;
            if (!string.IsNullOrEmpty(ids))
            {
                var gemeindeService = Container.Resolve<BaGemeindeService>();
                var gemeindeIds = ids.Split(',');
                var gemeindeName = new List<string>();
                foreach (var gemeindeIdString in gemeindeIds)
                {
                    int gemeindeId;
                    var parsed = Int32.TryParse(gemeindeIdString, out gemeindeId);
                    if (parsed)
                    {
                        var gemeinde = gemeindeService.GetEntityById(gemeindeId);
                        if (gemeinde != null)
                        {
                            gemeindeName.Add(gemeinde.Name);
                        }
                    }
                }

                if (gemeindeName.Any())
                {
                    returnString = string.Join(",", gemeindeName);
                }
                else
                {
                    returnString = ids;
                }
            }
            else
            {
                returnString = "-";
            }

            return returnString;
        }

        private static PropertyInfo GetPropertyInfo<TO, TP>(Expression<Func<TO, TP>> targetExpr)
        {
            var expression = targetExpr.Body as MemberExpression;
            if (expression == null)
            {
                var op = targetExpr.Body as UnaryExpression;
                expression = (MemberExpression)op.Operand;
            }

            return (PropertyInfo)expression.Member;
        }

        private static bool HasChanged(object targetProperty, object sourceProperty)
        {
            return sourceProperty == null && targetProperty != null ||
                   sourceProperty != null && targetProperty == null ||
                   sourceProperty != null && !sourceProperty.Equals(targetProperty);
        }

        private void AddChangeString(string targetPropertyName, string propertyText, string targetString, string sourceString)
        {
            var changeString = string.Format("{0}: {1} / {2}", propertyText, targetString, sourceString);
            _log.DebugFormat("changeString = {0}", changeString);
            if (Changes.ContainsKey(targetPropertyName))
            {
                Changes[targetPropertyName] = changeString;
            }
            else
            {
                Changes.Add(targetPropertyName, changeString);
            }
        }
    }
}