using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiBand.API.Extensions;
using MiBand.API.Resources;

namespace MiBand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        private readonly IStateService<Spec, SpecResponse> _service;
        private readonly IMapper _mapper;

        public SpecController(IStateService<Spec, SpecResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<SpecResource> FindByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Spec, SpecResource>(model.Resource);
            return resource;
        }

        [HttpGet("list/{id}")]
        public async Task<IEnumerable<SpecResource>> GetAllByUserCodeAsync(int id)
        {
            var models = await _service.ListByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Spec>, IEnumerable<SpecResource>>(models);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSpecResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSpecResource, Spec>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Spec, SpecResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSpecResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSpecResource, Spec>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Spec, SpecResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Spec, SpecResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}
