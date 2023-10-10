using CRM.Domain.Entity;
using CRM.Infrastructure.Interface;
using CRM.Transversal.Common;
using Dapper;

namespace CRM.Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
    private IFactoryConnection _factoryConnection;
    public CustomerRepository(IFactoryConnection factoryConnection)
    {
        _factoryConnection = factoryConnection;
    }
    
    #region Queries
    private readonly string INSERT = "INSERT INTO customer (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES "
    + "(@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";
    private readonly string SELECT = "SELECT * FROM customer";
    private readonly string SELECT_BY_ID = "SELECT * FROM customer WHERE CustomerID = @CustomerID";
    private readonly string UPDATE = "UPDATE customer SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, "
    + "City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax WHERE CustomerID = @CustomerID";
    private readonly string DELETE = "DELETE FROM customer WHERE CustomerID = @CustomerID";
    #endregion

    #region Sync
    public bool Insert(Customers customer)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);
            var result = connection.Execute(INSERT, parameters);
            return result > 0;
        }
    }
    public Customers Get(string customerId)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customerId);
            var customer = connection.QuerySingle<Customers>(SELECT_BY_ID, parameters);
            return customer;
        }
    }
    public IEnumerable<Customers> GetAll()
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var customers = connection.Query<Customers>(SELECT);
            return customers;
        }
    }
    public bool Update(Customers customer)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);
            var result = connection.Execute(UPDATE, parameters);
            return result > 0;
        }
    }
    public bool Delete(string customerId)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameter = new DynamicParameters(connection);
            parameter.Add("CustomerID", customerId);
            var result = connection.Execute(DELETE, parameter);
            return result > 0;
        }
    }
    #endregion
    
    #region Async
    public async Task<bool> InsertAsync(Customers customer)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);
            var result = await connection.ExecuteAsync(INSERT, parameters);
            return result > 0;
        }
    }
    public async Task<IEnumerable<Customers>> GetAllAsync()
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var customers = await connection.QueryAsync<Customers>(SELECT);
            return customers;
        }
    }
    public Task<Customers> GetAsync(string customerId)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customerId);
            var customer = connection.QuerySingleAsync<Customers>(SELECT_BY_ID, parameters);
            return customer;
        }
    }
    public async Task<bool> UpdateAsync(Customers customer)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameters = new DynamicParameters(connection);
            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CompanyName", customer.CompanyName);
            parameters.Add("ContactName", customer.ContactName);
            parameters.Add("ContactTitle", customer.ContactTitle);
            parameters.Add("Address", customer.Address);
            parameters.Add("City", customer.City);
            parameters.Add("Region", customer.Region);
            parameters.Add("PostalCode", customer.PostalCode);
            parameters.Add("Country", customer.Country);
            parameters.Add("Phone", customer.Phone);
            parameters.Add("Fax", customer.Fax);
            var result = await connection.ExecuteAsync(UPDATE, parameters);
            return result > 0;
        }
    }
    public async Task<bool> DeleteAsync(string customerId)
    {
        using (var connection = _factoryConnection.GetConnection)
        {
            var parameter = new DynamicParameters(connection);
            parameter.Add("CustomerID", customerId);
            var result = await connection.ExecuteAsync(DELETE, parameter);
            return result > 0;
        }
    }
    #endregion
}
