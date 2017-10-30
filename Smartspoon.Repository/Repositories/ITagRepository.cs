using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Smartspoon.Repository.Enums;
using Tag = Smartspoon.Repository.Models.Tag;

namespace Smartspoon.Repository.Repositories
{
    /// <summary>
    /// Interface to the tag repository
    /// </summary>
    public interface ITagRepository
    {
        /// <summary>
        /// Deregisters the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns></returns>
        Task<DeleteResult> DeregisterTag(string tagId);

        /// <summary>
        /// Finds the tag.
        /// </summary>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns></returns>
        Task<Tag> FindTag(string tagId);

        /// <summary>
        /// Lists the tags.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Tag>> ListTags();

        /// <summary>
        /// Registers the tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        Task RegisterTag(Tag tag);
    }
}