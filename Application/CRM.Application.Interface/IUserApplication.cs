using CRM.Transversal.Common;
using CRM.Application.DTO;

namespace CRM.Application.Interface;
public interface IUserApplication
{
    Response<UserDTO> Authenticate (string username, string password);
}
