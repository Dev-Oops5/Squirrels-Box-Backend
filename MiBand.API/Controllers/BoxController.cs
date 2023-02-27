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
    public class BoxController : ControllerBase
    {
        private readonly IStateService<Box, BoxResponse> _service;
        private readonly IMapper _mapper;

        public BoxController(IStateService<Box, BoxResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<BoxResource> FindByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Box, BoxResource>(model.Resource);
            return resource;
        }

        [HttpGet("list/{id}")]
        public async Task<IEnumerable<BoxResource>> GetAllByUserCodeAsync(int id)
        {
            var models = await _service.ListByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Box>, IEnumerable<BoxResource>>(models);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBoxResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveBoxResource, Box>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Box, BoxResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBoxResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveBoxResource, Box>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Box, BoxResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Box, BoxResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}
