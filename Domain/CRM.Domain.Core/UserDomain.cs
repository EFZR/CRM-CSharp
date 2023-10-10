using CRM.Domain.Entity;
using CRM.Domain.Interface;
using CRM.Infrastructure.Interface;

namespace CRM.Domain.Core;

public class UserDomain : IUserDomain
{
    private readonly IUserRepository _userRepository;
    public UserDomain(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public User Authenticate(string username, string password)
    {
        var user = _userRepository.Authenticate(username);
        if (user.Password != password)
        {
            throw new Exception("Incorrect Password");
        }
        return user;
    }
}