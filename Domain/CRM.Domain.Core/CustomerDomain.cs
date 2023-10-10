using CRM.Domain.Interface;
using CRM.Infrastructure.Interface;
using CRM.Domain.Entity;

namespace CRM.Domain.Core;

public class CustomerDomain : ICustomersDomain
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerDomain (ICustomerRepository customer)
    {
        _customerRepository = customer;
    }
    
    #region Synchronous Methods
    public bool Insert(Customers customer)
    {
        return _customerRepository.Insert(customer);
    }
    public bool Update(Customers customer)
    {
        return _customerRepository.Update(customer);
    }
    public bool Delete(string customerId)
    {
        return _customerRepository.Delete(customerId);
    }
    public Customers Get(string customerId)
    {
        return _customerRepository.Get(customerId);
    }
    public IEnumerable<Customers> GetAll()
    {
        return _customerRepository.GetAll();
    }
    #endregion

    #region Asynchronous Methods
    public async Task<bool> InsertAsync(Customers customer)
    {
        return await _customerRepository.InsertAsync(customer);
    }
    public async Task<bool> UpdateAsync(Customers customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }
    public async Task<bool> DeleteAsync(string customerId)
    {
        return await _customerRepository.DeleteAsync(customerId);
    }
    public async Task<Customers> GetAsync(string customerId)
    {
        return await _customerRepository.GetAsync(customerId);
    }
    public async Task<IEnumerable<Customers>> GetAllAsync()
    {
        return await _customerRepository.GetAllAsync();
    }
    #endregion
}
