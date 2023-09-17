using System;
using System.Text.RegularExpressions;

namespace VitDeck.Validator
{
    public class VRCSDKVersion : IVersion, IEquatable<VRCSDKVersion>, IComparable<VRCSDKVersion>
    {
        private readonly string rawString;
        private readonly int Year;
        private readonly int Month;
        private readonly int Date;
        private readonly int Major;
        private readonly int Minor;

        private static readonly Regex regex =
            new Regex(@"^(?<Year>\d+)\.(?<Month>\d+)\.(?<Date>\d+)\.(?<Major>\d+)\.(?<Minor>\d+)$");

        public VRCSDKVersion(string version)
        {
            var match = regex.Match(version);
            if (!match.Success)
                throw new InvalidVersionFormatException();

            rawString = version;

            Year = int.Parse(match.Groups["Year"].Value);
            Month = int.Parse(match.Groups["Month"].Value);
            Date = int.Parse(match.Groups["Date"].Value);
            Major = int.Parse(match.Groups["Major"].Value);
            Minor = int.Parse(match.Groups["Minor"].Value);
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
                   Year == other.Year &&
                   Month == other.Month &&
                   Date == other.Date &&
                   Major == other.Major &&
                   Minor == other.Minor;
        }

        public override int GetHashCode()
        {
            var hashCode = 1394553890;
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + Month.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + Major.GetHashCode();
            hashCode = hashCode * -1521134295 + Minor.GetHashCode();
            return hashCode;
        }

        public int CompareTo(VRCSDKVersion other)
        {
            var x = Year.CompareTo(other.Year);
            if (x != 0) return x;

            x = Month.CompareTo(other.Month);
            if (x != 0) return x;

            x = Date.CompareTo(other.Date);
            if (x != 0) return x;

            x = Major.CompareTo(other.Major);
            if (x != 0) return x;

            x = Minor.CompareTo(other.Minor);
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
