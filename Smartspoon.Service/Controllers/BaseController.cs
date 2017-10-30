using Microsoft.AspNetCore.Mvc;
using Smartspoon.Repository.Repositories;

namespace Smartspoon.Service.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class BaseController : Controller
    {
        #region Properties

        /// <summary>
        /// Gets or sets the tag repository.
        /// </summary>
        /// <value>
        /// The tag repository.
        /// </value>
        public ITagRepository TagRepository { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="tagRepository">The tag repository.</param>
        public BaseController(ITagRepository tagRepository)
        {
            TagRepository = tagRepository;
        }

        #endregion Constructors
    }
}