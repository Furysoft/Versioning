// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BatchedVersionedMessage.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The Batched Versioned Message
    /// </summary>
    [DataContract]
    [DtoVersion(typeof(BatchedVersionedMessage), 1, 0, 0)]
    public sealed class BatchedVersionedMessage
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [DataMember(Name = "m", Order = 1)]
        public IEnumerable<VersionedMessage> Messages { get; set; }
    }
}