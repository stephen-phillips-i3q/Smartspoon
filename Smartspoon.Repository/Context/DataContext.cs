using MongoDB.Driver;
using Smartspoon.Repository.Configuration;

namespace Smartspoon.Repository.Context
{
    /// <summary>
    /// Data context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataContext<T> where T : class
    {
        #region Fields

        private readonly DataConnectionSettings _settings;
        private IMongoDatabase _database;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public IMongoCollection<T> Collection => Database.GetCollection<T>(CollectionName);

        /// <summary>
        /// Gets or sets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        public string CollectionName { get; set; }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                    _database = RetrieveDatabase();

                return _database;
            }
        }

        #endregion Properties

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public DataContext(DataConnectionSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public DataContext(DataConnectionSettings settings, string collectionName)
        {
            _settings = settings;
            CollectionName = collectionName;
        }

        #endregion Contructors

        #region Private Methods

        /// <summary>
        /// Retrieves the database.
        /// </summary>
        /// <returns></returns>
        private IMongoDatabase RetrieveDatabase()
        {
            var client = new MongoClient(_settings.ConnectionString);
            return client.GetDatabase(_settings.Database);
        }

        #endregion Private Methods
    }
}