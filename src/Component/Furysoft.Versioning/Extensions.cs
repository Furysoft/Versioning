// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>The Version</returns>
        public static DtoVersion GetVersion<TEntity>(this TEntity entity)
        {
            var attribute = typeof(TEntity).GetCustomAttribute(typeof(DtoVersionAttribute)) as DtoVersionAttribute;

            return attribute?.Version ?? new DtoVersion(typeof(TEntity), 0, 0, 0);
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="DtoVersion"/></returns>
        public static DtoVersion GetVersion(this Type type)
        {
            var attribute = type.GetCustomAttribute(typeof(DtoVersionAttribute)) as DtoVersionAttribute;

            return attribute?.Version ?? new DtoVersion(type, 0, 0, 0);
        }

        /// <summary>
        /// Determines if the version is only a minor version change
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="targetVersion">The target version.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is compatible; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCompatible<TEntity>(this TEntity entity, DtoVersion targetVersion)
        {
            var thisVersion = entity.GetVersion();

            return thisVersion.IsCompatible(targetVersion);
        }

        /// <summary>
        /// Determines if the version is only a minor version change
        /// </summary>
        /// <typeparam name="TEntityOne">The type of the entity one.</typeparam>
        /// <typeparam name="TEntityTwo">The type of the entity two.</typeparam>
        /// <param name="entityOne">The entity one.</param>
        /// <param name="entityTwo">The entity two.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is compatible; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCompatible<TEntityOne, TEntityTwo>(this TEntityOne entityOne, TEntityTwo entityTwo)
        {
            var versionOne = entityOne.GetVersion();
            var versionTwo = entityTwo.GetVersion();

            return versionOne.IsCompatible(versionTwo);
        }

        /// <summary>
        /// Determines if the version is only a minor version change
        /// </summary>
        /// <param name="versionOne">The version one.</param>
        /// <param name="versionTwo">The version two.</param>
        /// <returns>
        ///   <c>true</c> if the specified version one is compatible; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCompatible(this DtoVersion versionOne, DtoVersion versionTwo)
        {
            if (versionOne == null || versionTwo == null)
            {
                return false;
            }

            if (versionOne.Type != versionTwo.Type)
            {
                return false;
            }

            if (versionOne.Minor != versionTwo.Minor)
            {
                return false;
            }

            if (versionOne.Major != versionTwo.Major)
            {
                return false;
            }

            if (versionOne.VersionTypeVersion != versionTwo.VersionTypeVersion)
            {
                return false;
            }

            if (versionOne.Patch != versionTwo.Patch)
            {
                return false;
            }

            return true;
        }
    }
}