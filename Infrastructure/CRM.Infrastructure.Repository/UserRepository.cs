using Dapper;
using CRM.Domain.Entity;
using CRM.Infrastructure.Interface;
using CRM.Transversal.Common;

namespace CRM.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly IFactoryConnection _factoryConnection;
    public UserRepository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }

    #region Queries
    private readonly string SELECT_USER = "SELECT * FROM user WHERE UserName = @UserName";
    #endregion

    public User Authenticate(string username)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters();
            parameters.Add("UserName", username);
            var user = connection.QuerySingle<User>(SELECT_USER, parameters);
            return user;
        }
    }
}