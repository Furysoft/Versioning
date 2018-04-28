// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoVersionAttribute.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// The DTO Version Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DtoVersionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersionAttribute" /> class.
        /// </summary>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        public DtoVersionAttribute(int major, int minor, int patch)
        {
            this.Version = new DtoVersion(major, minor, patch);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        public DtoVersionAttribute([NotNull] Type type, int major, int minor, int patch)
        {
            this.Version = new DtoVersion(type, major, minor, patch);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersionAttribute" /> class.
        /// </summary>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        /// <param name="versionType">Type of the version.</param>
        /// <param name="versionTypeVersion">The version type version.</param>
        public DtoVersionAttribute(int major, int minor, int patch, VersionType versionType, int versionTypeVersion)
        {
            this.Version = new DtoVersion(major, minor, patch, versionType, versionTypeVersion);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoVersionAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="major">The major.</param>
        /// <param name="minor">The minor.</param>
        /// <param name="patch">The patch.</param>
        /// <param name="versionType">Type of the version.</param>
        /// <param name="versionTypeVersion">The version type version.</param>
        public DtoVersionAttribute(
            [NotNull] Type type,
            int major,
            int minor,
            int patch,
            VersionType versionType,
            int versionTypeVersion)
        {
            this.Version = new DtoVersion(type, major, minor, patch, versionType, versionTypeVersion);
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public DtoVersion Version { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Version.ToString();
        }
    }
}