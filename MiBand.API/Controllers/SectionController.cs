using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using AutoMapper;
using MiBand.API.Extensions;
using MiBand.API.Resources;

namespace MiBand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IStateService<Section, SectionResponse> _service;
        private readonly IMapper _mapper;

        public SectionController(IStateService<Section, SectionResponse> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<SectionResource> FindByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Section, SectionResource>(model.Resource);
            return resource;
        }

        [HttpGet("list/{id}")]
        public async Task<IEnumerable<SectionResource>> GetAllByUserCodeAsync(int id)
        {
            var models = await _service.ListByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Section>, IEnumerable<SectionResource>>(models);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSectionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSectionResource, Section>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Section, SectionResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSectionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSectionResource, Section>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Section, SectionResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Section, SectionResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}
