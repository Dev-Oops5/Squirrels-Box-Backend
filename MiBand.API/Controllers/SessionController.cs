using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Extensions;
using MiBand.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace MiBand.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly IBaseService<Session, SessionResponse> _service;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionController(IBaseService<Session, SessionResponse> service, ISessionService sessionService, IMapper mapper)
        {
            _service = service;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<SessionResource> FindByIdAsync(int id)
        {
            var model = await _service.FindByIdAsync(id);
            var resource = _mapper.Map<Session, SessionResource>(model.Resource);
            return resource;
        }

        [HttpGet]
        public async Task<SessionResource> FindByUsernameOrEmailAndPasswordAsync(string password, string? username = null, string? email = null)
        {
            username = username ?? string.Empty;
            email = email ?? string.Empty;
            var model = await _sessionService.FindByUsernameOrEmailAndPasswordAsync(username,email,password);
            var resource = _mapper.Map<Session, SessionResource>(model.Resource);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _service.SaveAsync(model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var model = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _service.UpdateAsync(id, model);

            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(itemResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var itemResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(itemResource);
        }
    }
}
