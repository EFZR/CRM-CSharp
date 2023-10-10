using CRM.Application.DTO;
using CRM.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Service.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class CustomerController : ControllerBase
{
    private readonly ICustomerApplication _customerApplication;
    public CustomerController(ICustomerApplication customerApplication)
    {
        _customerApplication = customerApplication;
    }
    #region Sync
    [HttpPost]
    public IActionResult Insert([FromBody] CustomersDTO customersDTO)
    {
        if (customersDTO == null)
        {
            return BadRequest();
        }
        var response = _customerApplication.Insert(customersDTO);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet("customerId")]
    public IActionResult Get(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest();
        }
        var response = _customerApplication.Get(customerId);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var response = _customerApplication.GetAll();
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpPut]
    public IActionResult Update([FromBody] CustomersDTO customersDTO)
    {
        if (customersDTO == null)
        {
            return BadRequest();
        }
        var response = _customerApplication.Update(customersDTO);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest();
        }
        var response = _customerApplication.Delete(customerId);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    #endregion

    #region Async
    [HttpPost]
    public async Task<IActionResult> AsyncInsert([FromBody] CustomersDTO customersDTO)
    {
        if (customersDTO == null)
        {
            return BadRequest();
        }
        var response = await _customerApplication.InsertAsync(customersDTO);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet("customerId")]
    public async Task<IActionResult> AsyncGet(string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest();
        }
        var response = await _customerApplication.GetAsync(customerId);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet]
    public async Task<IActionResult> AsyncGetAll()
    {
        var response = await _customerApplication.GetAllAsync();
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpPut]
    public async Task<IActionResult> AsyncUpdate([FromBody] CustomersDTO customersDTO)
    {
        if (customersDTO == null)
        {
            return BadRequest();
        }
        var response = await _customerApplication.UpdateAsync(customersDTO);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpDelete]
    public async Task<IActionResult> AsyncDelete([FromBody] string customerId)
    {
        if (string.IsNullOrEmpty(customerId))
        {
            return BadRequest();
        }
        var response = await _customerApplication.DeleteAsync(customerId);
        if (response.IsSuccess == true)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    #endregion

}