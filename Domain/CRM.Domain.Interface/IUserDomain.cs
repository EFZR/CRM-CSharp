using CRM.Domain.Entity;

namespace CRM.Domain.Interface;

public interface IUserDomain
{
    User Authenticate(string username, string password);
}