using System;
using System.Text.RegularExpressions;

namespace VitDeck.Validator
{
    public class VRCSDKVersion : IVersion, IEquatable<VRCSDKVersion>, IComparable<VRCSDKVersion>
    {
        private readonly string rawString;
        private readonly int Major;
        private readonly int Minor;
        private readonly int Patch;

        private static readonly Regex regex = new Regex(@"^(?<Major>\d+)\.(?<Minor>\d+)\.(?<Patch>\d+)$");

        public VRCSDKVersion(string version)
        {
            var match = regex.Match(version);
            if (!match.Success)
                throw new InvalidVersionFormatException();

            rawString = version;

            Major = int.Parse(match.Groups["Major"].Value);
            Minor = int.Parse(match.Groups["Minor"].Value);
            Patch = int.Parse(match.Groups["Patch"].Value);
        }

        public string ToInterconvertibleString()
        {
            return rawString;
        }

        public string ToReadableString()
        {
            return rawString;
        }
        
        public override bool Equals(object obj)
        {
            var version = obj as VRCSDKVersion;
            if (version != null)
            {
                return Equals(version);
            }
            return false;
        }

        public bool Equals(VRCSDKVersion other)
        {
            return (object)other != null &&
                   Major == other.Major &&
                   Minor == other.Minor &&
                   Patch == other.Patch;
        }

        public override int GetHashCode()
        {
            var hashCode = 1394553890;
            hashCode = hashCode * -1521134295 + Major.GetHashCode();
            hashCode = hashCode * -1521134295 + Minor.GetHashCode();
            hashCode = hashCode * -1521134295 + Patch.GetHashCode();
            return hashCode;
        }

        public int CompareTo(VRCSDKVersion other)
        {
            var x = Major.CompareTo(other.Major);
            if (x != 0) return x;

            x = Minor.CompareTo(other.Minor);
            if (x != 0) return x;

            x = Patch.CompareTo(other.Patch);
            return x;
        }

        public static bool operator ==(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >=(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator <=(VRCSDKVersion lhs, VRCSDKVersion rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }
    }
}
