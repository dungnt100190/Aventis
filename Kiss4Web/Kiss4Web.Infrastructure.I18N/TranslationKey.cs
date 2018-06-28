using System;

namespace Kiss4Web.Infrastructure.I18N
{
    public struct TranslationKey
    {
        public TranslationKey(string maskName, string messageName, LanguageCode languageCode)
        {
            MaskName = maskName;
            MessageName = messageName;
            LanguageCode = languageCode;
        }

        public string MaskName { get; }
        public string MessageName { get; }
        public LanguageCode LanguageCode { get; }

        public bool Equals(TranslationKey other)
        {
            return string.Equals(MaskName, other.MaskName, StringComparison.InvariantCultureIgnoreCase) && string.Equals(MessageName, other.MessageName, StringComparison.InvariantCultureIgnoreCase) && LanguageCode == other.LanguageCode;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is TranslationKey key && Equals(key);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (MaskName != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(MaskName) : 0);
                hashCode = (hashCode * 397) ^ (MessageName != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(MessageName) : 0);
                hashCode = (hashCode * 397) ^ (int)LanguageCode;
                return hashCode;
            }
        }
    }
}