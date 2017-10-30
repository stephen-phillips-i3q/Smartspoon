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

        [BsonId]
        public string Id { get; set; }

        [BsonElement("type")]

        public TagType Type { get; set; }

        [BsonElement("order")]
        public int Order { get; set; }

        [BsonElement("table")]
        public int Table { get; set; }

        #endregion Properties
    }
}