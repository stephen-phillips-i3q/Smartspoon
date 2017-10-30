namespace Smartspoon.Repository.Configuration
{
    /// <summary>
    /// Data connection String settings
    /// </summary>
    public class DataConnectionSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public string Database { get; set; }

        #endregion Properties
    }
}