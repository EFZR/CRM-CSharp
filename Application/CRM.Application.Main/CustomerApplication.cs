using CRM.Application.DTO;
using CRM.Application.Interface;
using CRM.Transversal.Common;
using AutoMapper;
using CRM.Domain.Interface;
using CRM.Domain.Entity;


namespace CRM.Application.Main;
public class CustomersApplication : ICustomerApplication
{
    private IMapper _mapper;
    private ICustomersDomain _customerDomain;
    private IAppLogger<CustomersApplication> _logger;
    public CustomersApplication(IMapper mapper, ICustomersDomain customersDomain, IAppLogger<CustomersApplication> logger)
    {
        _mapper = mapper;
        _customerDomain = customersDomain;
        _logger = logger;
    }
    #region Synchronous Methods
    public Response<bool> Insert(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = _customerDomain.Insert(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register created succesfully";
                _logger.LogInformation("Register created succesfully");
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public Response<bool> Update(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = _customerDomain.Update(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register updated succesfully";
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public Response<bool> Delete(string customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = _customerDomain.Delete(customerId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register deleted succesfully";
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public Response<CustomersDTO> Get(string customerId)
    {
        var response = new Response<CustomersDTO>();
        try
        {
            var customer = _customerDomain.Get(customerId);
            response.Data = _mapper.Map<CustomersDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public Response<IEnumerable<CustomersDTO>> GetAll()
    {
        var response = new Response<IEnumerable<CustomersDTO>>();
        try
        {
            var customers = _customerDomain.GetAll();
            response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    #endregion

    #region Asynchronous Methods
    public async Task<Response<bool>> InsertAsync(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = await _customerDomain.InsertAsync(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register created succesfully";
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public async Task<Response<bool>> UpdateAsync(CustomersDTO customerDTO)
    {
        var response = new Response<bool>();
        try
        {
            var customer = _mapper.Map<Customers>(customerDTO);
            response.Data = await _customerDomain.UpdateAsync(customer);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register updated succesfully";
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public async Task<Response<bool>> DeleteAsync(string customerId)
    {
        var response = new Response<bool>();
        try
        {
            response.Data = await _customerDomain.DeleteAsync(customerId);
            if (response.Data == true)
            {
                response.IsSuccess = true;
                response.Message = "Register deleted succesfully";
            }
        }
        catch (Exception e)
        {
            response.Data = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public async Task<Response<CustomersDTO>> GetAsync(string customerId)
    {
        var response = new Response<CustomersDTO>();
        try
        {
            var customer = await _customerDomain.GetAsync(customerId);
            response.Data = _mapper.Map<CustomersDTO>(customer);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
    {
        var response = new Response<IEnumerable<CustomersDTO>>();
        try
        {
            var customers = await _customerDomain.GetAllAsync();
            response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
            if (response.Data != null)
            {
                response.IsSuccess = true;
                response.Message = "Query successfully";
            }
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            _logger.LogError(e.Message);
        }
        return response;
    }
    #endregion
}
