using CRM.Domain.Entity;

namespace CRM.Infrastructure.Interface;

public interface IUserRepository
{
    User Authenticate(string username);
}