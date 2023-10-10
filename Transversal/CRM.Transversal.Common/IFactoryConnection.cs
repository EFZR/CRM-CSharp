using Microsoft.Data.Sqlite;

namespace CRM.Transversal.Common;
public interface IFactoryConnection
{
    SqliteConnection GetConnection { get; }
}
