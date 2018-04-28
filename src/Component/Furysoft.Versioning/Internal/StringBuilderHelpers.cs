// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderHelpers.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning.Internal
{
    using System.Text;
    using JetBrains.Annotations;

    /// <summary>
    /// The String Builder Helpers
    /// </summary>
    internal static class StringBuilderHelpers
    {
        /// <summary>
        /// Appends if not null.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The <see cref="StringBuilder" />
        /// </returns>
        public static StringBuilder AppendIfNotNull<TEntity>(
            this StringBuilder stringBuilder,
            [CanBeNull] TEntity entity,
            string value)
            where TEntity : class
        {
            if (entity != null)
            {
                stringBuilder.Append(value);
            }

            return stringBuilder;
        }
    }
}