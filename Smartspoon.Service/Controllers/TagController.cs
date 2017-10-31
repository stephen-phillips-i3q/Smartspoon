using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Smartspoon.Repository.Repositories;
using System.Collections.Generic;
using Tag = Smartspoon.Repository.Models.Tag;

namespace Smartspoon.Service.Controllers
{
    /// <summary>
    /// RFID tag controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class TagController : BaseController
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TagController" /> class.
        /// </summary>
        /// <param name="tagRepository">The tag repository.</param>
        public TagController(ITagRepository tagRepository) : base(tagRepository)
        {
        }

        #endregion Constructors

        #region Delete Services

        // DELETE api/tag/1
        [HttpDelete("{tagId}")]
        public DeleteResult Delete(string tagId)
        {
            return TagRepository.DeregisterTag(tagId).Result;
        }

        #endregion Delete Services

        #region Get Services

        // GET api/tag
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return TagRepository.ListTags().Result;
        }

        // GET api/tag/1
        [HttpGet("{tagId}")]
        public Tag Get(string tagId)
        {
            return TagRepository.FindTag(tagId).Result;
        }

        #endregion Get Services

        #region Post Services

        // POST api/tag
        /// <summary>
        /// Posts the specified tag identifier.
        /// </summary>
        /// <param name="tag">The tag.</param>
        [HttpPost]
        public void Post([FromBody] Tag tag)
        {
            TagRepository.RegisterTag(tag);
        }

        #endregion Post Services
    }
}