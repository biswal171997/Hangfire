using System.Data;

namespace AdminConsole.Repository.Factory
{
     public interface ICachDB10ConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
