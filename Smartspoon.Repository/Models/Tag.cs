using MongoDB.Bson.Serialization.Attributes;
using Smartspoon.Repository.Enums;

namespace Smartspoon.Repository.Models
{
    /// <summary>
    /// RFID Tag
    /// </summary>
    public class Tag
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonId]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [BsonElement("order")]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        [BsonElement("table")]
        public int Table { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [BsonElement("type")]
        public TagType Type { get; set; }

        #endregion Properties
    }
}