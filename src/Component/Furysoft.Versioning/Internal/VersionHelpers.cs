// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionHelpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning.Internal
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The Version Helpers
    /// </summary>
    internal sealed class VersionHelpers
    {
        /// <summary>
        /// The additional part regex
        /// </summary>
        private static readonly Regex AdditionalPartRegex = new Regex(
            "-(.[^.]+.?[0-9]*)$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>
        /// The version regex
        /// </summary>
        private static readonly Regex VersionRegex = new Regex(
                "[0-9]+.[0-9]+.[0-9]+",
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>
        /// Gets the additional part.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The Version Part (rc.1)</returns>
        public static string GetAdditionalPart(string s)
        {
            var matches = AdditionalPartRegex.Matches(s);

            if (matches.Count == 0)
            {
                return null;
            }

            return matches[0].Groups?[1].Value;
        }

        /// <summary>
        /// Gets the type version.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The Type Version</returns>
        public static string GetTypeVersion(string s)
        {
            return VersionRegex.Match(s).Value;
        }

        /// <summary>
        /// Gets the version part.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>The Version Part (0.0.0)</returns>
        public static string GetVersionPart(string s)
        {
            return VersionRegex.Match(s).Value;
        }

        /// <summary>
        /// Parses the version string.
        /// </summary>
        /// <param name="s">The string version.</param>
        /// <returns>
        /// The <see cref="DtoVersion" />
        /// </returns>
        public static DtoVersion ParseVersionString(string s)
        {
            var versionPart = GetVersionPart(s);
            var additionalPart = GetAdditionalPart(s);

            var versionParts = versionPart.Split('.');

            int.TryParse(versionParts[0], out var major);
            int.TryParse(versionParts[1], out var minor);
            int.TryParse(versionParts[2], out var patch);

            var additionalParts = additionalPart.Split('.');

            VersionType versionType;
            int versionTypeVersion;
            if (additionalParts?.Length == 1)
            {
                switch (additionalParts[0])
                {
                    case "alpha":
                        versionType = VersionType.Alpha;
                        break;

                    case "beta":
                        versionType = VersionType.Beta;
                        break;

                    case "rc":
                        versionType = VersionType.RC;
                        break;

                    default:
                        versionType = VersionType.None;
                        break;
                }

                versionTypeVersion = 0;
            }
            else if (additionalParts?.Length == 2)
            {
                switch (additionalParts[0])
                {
                    case "alpha":
                        versionType = VersionType.Alpha;
                        break;

                    case "beta":
                        versionType = VersionType.Beta;
                        break;

                    case "rc":
                        versionType = VersionType.RC;
                        break;

                    default:
                        versionType = VersionType.None;
                        break;
                }

                int.TryParse(additionalParts[1], out versionTypeVersion);
            }
            else
            {
                versionType = VersionType.None;
                versionTypeVersion = 0;
            }

            return new DtoVersion(major, minor, patch, versionType, versionTypeVersion);
        }
    }
}