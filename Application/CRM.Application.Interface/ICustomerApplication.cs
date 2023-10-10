using CRM.Transversal.Common;
using CRM.Application.DTO;

namespace CRM.Application.Interface;
public interface ICustomerApplication
{
    #region Synchronous Methods
    Response<bool> Insert(CustomersDTO customerDTO);
    Response<bool> Update(CustomersDTO customerDTO);
    Response<bool> Delete(string customerId);
    Response<CustomersDTO> Get(string customerId);
    Response<IEnumerable<CustomersDTO>> GetAll();
    #endregion

    #region Asynchronous Methods
    Task<Response<bool>> InsertAsync(CustomersDTO customerDTO);
    Task<Response<bool>> UpdateAsync(CustomersDTO customerDTO);
    Task<Response<bool>> DeleteAsync(string customerId);
    Task<Response<CustomersDTO>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
    #endregion
}
