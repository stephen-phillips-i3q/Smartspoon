using Microsoft.Extensions.Options;
using Smartspoon.Repository.Configuration;
using Smartspoon.Repository.Context;

namespace Smartspoon.Repository.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T : class
    {
        #region Fields

        private readonly DataConnectionSettings _settings;
        private DataContext<T> _context;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public DataContext<T> Context
        {
            get
            {
                if (_context == null)
                    _context = new DataContext<T>(_settings);

                return _context;
            }
        }

        #endregion Properties

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public BaseRepository(IOptions<DataConnectionSettings> settings)
        {
            _settings = settings.Value;
        }

        #endregion Contructors
    }
}