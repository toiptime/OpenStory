using System;
using System.Data;

namespace OpenStory.Framework.Model.Auth
{
    /// <summary>
    /// An object mapping for the World table.
    /// </summary>
    public sealed class WorldInfo
    {
        /// <summary>
        /// Gets the world ID.
        /// </summary>
        public byte WorldId { get; set; }

        /// <summary>
        /// Gets the world name.
        /// </summary>
        public string WorldName { get; set; }

        /// <summary>
        /// Gets the number of channels in the world.
        /// </summary>
        public int ChannelCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldInfo"/> class.
        /// </summary>
        public WorldInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldInfo"/> class.
        /// </summary>
        /// <param name="record">The record containing the data for this object.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="record"/> is <see langword="null"/>.
        /// </exception>
        public WorldInfo(IDataRecord record)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            this.WorldId = (byte)record["WorldId"];
            this.WorldName = (string)record["WorldName"];
            this.ChannelCount = (int)record["ChannelCount"];
        }
    }
}