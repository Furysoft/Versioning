// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoVersion.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;
    using Internal;
    using JetBrains.Annotations;

    /// <summary>
    /// The DTO Version
    /// </summary>
    [DataContract]
    public sealed class DtoVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion" /> class.
        /// </summary>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        public DtoVersion(int major, int minor, int patch)
        {
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = VersionType.None;
            this.VersionTypeVersion = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        public DtoVersion([NotNull] Type type, int major, int minor, int patch)
        {
            this.Type = type.Name;
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = VersionType.None;
            this.VersionTypeVersion = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        public DtoVersion([NotNull] string type, int major, int minor, int patch)
        {
            this.Type = type;
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = VersionType.None;
            this.VersionTypeVersion = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion" /> class.
        /// </summary>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        /// <param name="versionType">Type of the version.</param>
        /// <param name="versionTypeVersion">The version type version.</param>
        public DtoVersion(int major, int minor, int patch, VersionType versionType, int versionTypeVersion)
        {
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = versionType;
            this.VersionTypeVersion = versionTypeVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        /// <param name="versionType">Type of the version.</param>
        /// <param name="versionTypeVersion">The version type version.</param>
        public DtoVersion([NotNull] Type type, int major, int minor, int patch, VersionType versionType, int versionTypeVersion)
        {
            this.Type = type.Name;
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = versionType;
            this.VersionTypeVersion = versionTypeVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        /// <param name="versionType">Type of the version.</param>
        /// <param name="versionTypeVersion">The version type version.</param>
        public DtoVersion([NotNull] string type, int major, int minor, int patch, VersionType versionType, int versionTypeVersion)
        {
            this.Type = type;
            this.Major = major;
            this.Minor = minor;
            this.Patch = patch;
            this.VersionType = versionType;
            this.VersionTypeVersion = versionTypeVersion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersion" /> class.
        /// </summary>
        private DtoVersion()
        {
        }

        /// <summary>
        /// Gets the major.
        /// </summary>
        [DataMember(Name = "Ma", Order = 2)]
        public int Major { get; private set; }

        /// <summary>
        /// Gets the minor.
        /// </summary>
        [DataMember(Name = "Mi", Order = 3)]
        public int Minor { get; private set; }

        /// <summary>
        /// Gets the patch.
        /// </summary>
        [DataMember(Name = "P", Order = 4)]
        public int Patch { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [DataMember(Name = "T", Order = 1)]
        public string Type { get; private set; }

        /// <summary>
        /// Gets the type of the version.
        /// </summary>
        [DataMember(Name = "VT", Order = 5)]
        public VersionType VersionType { get; private set; }

        /// <summary>
        /// Gets the version type version.
        /// </summary>
        [DataMember(Name = "VTV", Order = 6)]
        public int VersionTypeVersion { get; private set; }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="version1">The version1.</param>
        /// <param name="version2">The version2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(DtoVersion version1, DtoVersion version2)
        {
            return !(version1 == version2);
        }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(DtoVersion v1, DtoVersion v2)
        {
            if (v1.Major < v2.Major)
            {
                return true;
            }

            if (v1.Minor < v2.Minor)
            {
                return true;
            }

            if (v1.Patch < v2.Patch)
            {
                return true;
            }

            if (v1.VersionType < v2.VersionType)
            {
                return true;
            }

            if (v1.VersionTypeVersion < v2.VersionTypeVersion)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <=(DtoVersion v1, DtoVersion v2)
        {
            return v1 == v2 || v1 < v2;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="version1">The version1.</param>
        /// <param name="version2">The version2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(DtoVersion version1, DtoVersion version2)
        {
            if (ReferenceEquals(version1, version2))
            {
                return true;
            }

            if (ReferenceEquals(version1, null))
            {
                return false;
            }

            if (ReferenceEquals(version2, null))
            {
                return false;
            }

            return version1.Equals(version2);
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(DtoVersion v1, DtoVersion v2)
        {
            if (v1.Major > v2.Major)
            {
                return true;
            }

            if (v1.Minor > v2.Minor)
            {
                return true;
            }

            if (v1.Patch > v2.Patch)
            {
                return true;
            }

            if (v1.VersionType > v2.VersionType)
            {
                return true;
            }

            if (v1.VersionTypeVersion > v2.VersionTypeVersion)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >=(DtoVersion v1, DtoVersion v2)
        {
            return v1 == v2 || v1 > v2;
        }

        /// <summary>
        /// Parses the specified version.
        /// </summary>
        /// <param name="s">The string version.</param>
        /// <returns>
        /// The <see cref="Version" />
        /// </returns>
        public static DtoVersion Parse(string s)
        {
            return VersionHelpers.ParseVersionString(s);
        }

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="version">The version.</param>
        /// <returns>True if the parse succeeds</returns>
        public static bool TryParse(string s, out DtoVersion version)
        {
            try
            {
                version = VersionHelpers.ParseVersionString(s);
                return true;
            }
            catch (Exception)
            {
                version = null;
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var item = obj as DtoVersion;
            if (item == null)
            {
                return false;
            }

            if (this.Type != item.Type)
            {
                return false;
            }

            if (this.Major != item.Major)
            {
                return false;
            }

            if (this.Major != item.Major)
            {
                return false;
            }

            if (this.Patch != item.Patch)
            {
                return false;
            }

            if (this.VersionType != item.VersionType)
            {
                return false;
            }

            if (this.VersionTypeVersion != item.VersionTypeVersion)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            var hash = 13;
            hash = (hash * 7) + this.Major.GetHashCode();
            hash = (hash * 7) + this.Minor.GetHashCode();
            hash = (hash * 7) + this.Patch.GetHashCode();
            hash = (hash * 7) + this.VersionType.GetHashCode();
            hash = (hash * 7) + this.VersionTypeVersion.GetHashCode();
            return hash;

            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendIfNotNull(this.Type, $"{this.Type}.");
            sb.Append($"{this.Major}.{this.Minor}.{this.Patch}");

            if (this.VersionType == VersionType.None)
            {
                return sb.ToString();
            }

            var versionType = this.VersionType.ToString().ToLowerInvariant();
            sb.Append($"-{versionType}");

            if (this.VersionTypeVersion == 0)
            {
                return sb.ToString();
            }

            sb.Append($".{this.VersionTypeVersion}");

            return sb.ToString();
        }
    }
}