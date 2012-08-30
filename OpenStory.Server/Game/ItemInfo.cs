using System;

namespace OpenStory.Server.Game
{
    /// <summary>
    /// Represents information about a game item.
    /// </summary>
    public abstract class ItemInfo : IEquatable<ItemInfo>
    {
        /// <summary>
        /// Gets the identifier for this prototype.
        /// </summary>
        public int ItemId { get; private set; }

        /// <summary>
        /// Gets how many items of this prototype you can put in one cluster.
        /// </summary>
        public virtual int ClusterCapacity { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="ItemInfo"/>.
        /// </summary>
        /// <param name="itemId">The identifier for the item.</param>
        protected ItemInfo(int itemId)
        {
            if (itemId <= 0)
            {
                throw new ArgumentOutOfRangeException("itemId", itemId, "'itemId' must be a positive integer.");
            }

            this.ItemId = itemId;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }

            return this.Equals(obj as ItemInfo);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.ItemId;
        }

        /// <inheritdoc />
        public bool Equals(ItemInfo other)
        {
            if (other == null)
            {
                return false;
            }

            return this.ItemId == other.ItemId;
        }

    }
}