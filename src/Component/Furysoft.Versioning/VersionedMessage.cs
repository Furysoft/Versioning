// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionedMessage.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The Versioned Message
    /// </summary>
    [DataContract]
    public sealed class VersionedMessage
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [DataMember(Name = "d", Order = 2)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [DataMember(Name = "v", Order = 1)]
        public DtoVersion Version { get; set; }
    }
}