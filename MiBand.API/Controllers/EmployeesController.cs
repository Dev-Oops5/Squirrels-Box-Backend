using AutoMapper;
using Azure;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services;
using MiBand.API.Extensions;
using MiBand.API.Resources;
using MiBand.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MiBand.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /*****************************************************************/
                            /*GET ALL EMPLOYEES*/
        /*****************************************************************/
        //[HttpGet]
        //public async Task<IEnumerable<EmployeeResource>> GetAllAsync()
        //{
        //    var cuestionary = await _employeeService.GetAllAsync();
        //    var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(cuestionary);
        //    return resources;
        //}

        /******************************************/
                    /*GET EMPLOYEE BY ID ASYNC*/
        /******************************************/
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetByIdAsync(int employeeId)
        {
            var result = await _employeeService.GetByIdAsync(employeeId);

            if (!result.Success)
                return BadRequest(result.Message);

            var administratorResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(administratorResource);
        }

        /*****************************************************************/
                        /*POST EMPLOYEE*/
        /*****************************************************************/
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cuestionary = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.SaveAsync(cuestionary);

            if (!result.Success)
                return BadRequest(result.Message);

            var cuestionaryResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);

            return Ok(cuestionaryResource);
        }

        /******************************************/
                        /*UPDATE EMPLOYEE*/
        /******************************************/
        [HttpPut("{employeeId}")]
        public async Task<IActionResult> PutAsync(int employeeId, [FromBody] SaveEmployeeResource resource)
        {
            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(employeeId, employee);

            if (!result.Success)
                return BadRequest(result.Message);

            var adminResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(adminResource);
        }

        /******************************************/
                        /*DELETE EMPLOYEE*/
        /******************************************/

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteAsync(int employeeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _employeeService.DeleteAsync(employeeId);

            if (!result.Success)
                return BadRequest(result.Message);

            var adminResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(adminResource);
        }
    }
}
