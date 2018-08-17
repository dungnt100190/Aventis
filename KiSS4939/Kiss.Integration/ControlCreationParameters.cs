using System.Collections.Generic;
using System.Linq;

namespace Kiss.Integration
{
    public class ControlCreationParameters
    {
        public object[] ConstructorParameters { get; set; }

        public IDictionary<string, object[]> InitMethodInvocations { get; set; }

        public bool IsWpf { get; set; }

        public string TypeName { get; set; }

        public IDictionary<string, object> WpfInitParameters { get; set; }

        public bool Equals(ControlCreationParameters other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            var equal = Equals(other.TypeName, TypeName) &&
                        (other.ConstructorParameters == null && ConstructorParameters == null ||
                         other.ConstructorParameters != null && other.ConstructorParameters.SequenceEqual(ConstructorParameters)) &&
                         (other.WpfInitParameters == null && WpfInitParameters == null ||
                         other.WpfInitParameters != null && other.WpfInitParameters.SequenceEqual(WpfInitParameters));// &&
            //(other.InitMethodInvocations == null && InitMethodInvocations == null ||
            // other.InitMethodInvocations != null && other.InitMethodInvocations.SequenceEqual(InitMethodInvocations));
            return equal;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(ControlCreationParameters))
            {
                return false;
            }
            return Equals((ControlCreationParameters)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (TypeName != null ? TypeName.GetHashCode() : 0);
                result = (result * 397) ^ (ConstructorParameters != null ? ConstructorParameters.GetHashCode() : 0);
                result = (result * 397) ^ (InitMethodInvocations != null ? InitMethodInvocations.GetHashCode() : 0);
                result = (result * 397) ^ (WpfInitParameters != null ? WpfInitParameters.GetHashCode() : 0);
                return result;
            }
        }
    }
}