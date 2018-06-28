namespace Kiss4Web.Infrastructure.I18N
{
    public struct TranslationIdKey
    {
        public TranslationIdKey(int tid, LanguageCode languageCode)
        {
            Tid = tid;
            LanguageCode = languageCode;
        }

        public int Tid { get; }
        public LanguageCode LanguageCode { get; }

        public override bool Equals(object obj)
        {
            if (!(obj is TranslationIdKey))
            {
                return false;
            }

            var key = (TranslationIdKey)obj;
            return Tid == key.Tid &&
                   LanguageCode == key.LanguageCode;
        }

        public override int GetHashCode()
        {
            var hashCode = -229983936;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Tid.GetHashCode();
            hashCode = hashCode * -1521134295 + LanguageCode.GetHashCode();
            return hashCode;
        }
    }
}