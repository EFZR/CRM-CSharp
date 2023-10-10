using CRM.Application.DTO;
using CRM.Application.Interface;
using CRM.Transversal.Common;
using CRM.Domain.Interface;
using CRM.Domain.Entity;
using AutoMapper;

namespace CRM.Application.Main;
public class UserApplication : IUserApplication
{
    IUserDomain _userDomain;
    IMapper _mapper;
    public UserApplication(IUserDomain userDomain, IMapper mapper)
    {
        _userDomain = userDomain;
        _mapper = mapper;
    }
    public Response<UserDTO> Authenticate(string username, string password)
    {
        var response = new Response<UserDTO>();
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            response.IsSuccess = false;
            response.Message = "Username and Password Required.";
            return response;
        }
        try
        {
            var user = _userDomain.Authenticate(username, password);
            response.Data = _mapper.Map<UserDTO>(user);
            response.IsSuccess = true;
            response.Message = "Authentication succesfully.";
            return response;
        }
        catch (InvalidOperationException)
        {
            response.IsSuccess = true;
            response.Message = "User not found.";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
