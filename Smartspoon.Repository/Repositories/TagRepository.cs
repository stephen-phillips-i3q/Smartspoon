using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Smartspoon.Repository.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tag = Smartspoon.Repository.Models.Tag;

namespace Smartspoon.Repository.Repositories
{
    /// <summary>
    /// RFID tag data repository
    /// </summary>
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        #region Constants

        private const string TagCollectionName = "tags";

        #endregion Constants

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TagRepository" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public TagRepository(IOptions<DataConnectionSettings> settings) : base(settings)
        {
            base.Context.CollectionName = TagCollectionName;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Deregisters the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeregisterTag(string tagId)
        {
            return await Context.Collection.DeleteOneAsync(t => t.Id == tagId);
        }

        /// <summary>
        /// Finds the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns></returns>
        public async Task<Tag> FindTag(string tagId)
        {
            if (string.IsNullOrEmpty(tagId))
                return new Tag();

            var tag = await Context.Collection.Find(t => t.Id == tagId).Limit(1).FirstOrDefaultAsync();
            if (tag == null)
                return new Tag();

            return tag;
        }

        /// <summary>
        /// Lists the tags.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tag>> ListTags()
        {
            return await Context.Collection.Find(new BsonDocument()).ToListAsync();
        }

        /// <summary>
        /// Registers the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public async Task RegisterTag(Tag tag)
        {
            await Context.Collection.InsertOneAsync(tag);
        }

        #endregion Public Methods
    }
}