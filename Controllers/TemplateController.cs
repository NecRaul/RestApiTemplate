using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Context;
using RestApiTemplate.Interfaces;
using RestApiTemplate.Models;
using RestApiTemplate.Repository;
using RestApiTemplate.Services;

namespace RestApiTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private ITemplateService _templateService = new TemplateService(new Repository<Template>(new AppDbContext()));
        private readonly ILogger<TemplateController> _logger;
        public TemplateController(ILogger<TemplateController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> Get(int id)
        {
            var template = await _templateService.GetByID(id);
            if (template == null)
            {
                _logger.LogError("Not Found");
                return NotFound("Not Found");
            }
            _logger.LogInformation($"{id}");
            return Ok(template);
        }
        [HttpPost]
        public async Task<ActionResult<Template>> Insert(Template template)
        {
            if (template == null)
            {
                _logger.LogError("Null Object");
                return BadRequest("Null Object");
            }
            _templateService.Insert(template);
            _logger.LogInformation($"{template.Id}");
            return Ok(template);
        }
        [HttpPut]
        public async Task<ActionResult<Template>> Update(Template template)
        {
            if (template == null)
            {
                _logger.LogError("Null Object");
                return BadRequest("Null Object");
            }
            if (template.Id == 0)
            {
                _logger.LogError("Object not in database");
                return BadRequest("Object not in database");
            }
            _templateService.Update(template);
            _logger.LogInformation($"{template.Id}");
            return Ok(template);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Template>> Delete(int id)
        {
            var template = await _templateService.GetByID(id);
            if (template == null)
            {
                _logger.LogError("Object not in database");
                return BadRequest("Object not in database");
            }
            _templateService.Delete(id);
            _logger.LogInformation($"{id}");
            return Ok(template);
        }
        [HttpGet]
        public async Task<ActionResult<Template>> GetAll()
        {
            var templates = await _templateService.GetAll();
            if (templates.Count == 0)
            {
                _logger.LogError("Not Found");
                return NotFound("Not Found");
            }
            templates.ForEach(x => _logger.LogInformation($"{x.Id}"));
            return Ok(templates);
        }
    }
}
