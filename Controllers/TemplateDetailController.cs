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
    public class TemplateDetailController : ControllerBase
    {
        private ITemplateDetailService _templateDetailService = new TemplateDetailService(new Repository<TemplateDetail>(new AppDbContext()));
        private readonly ILogger<TemplateDetailController> _logger;
        public TemplateDetailController(ILogger<TemplateDetailController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateDetail>> Get(int id)
        {
            var templateDetail = await _templateDetailService.GetByID(id);
            if (templateDetail == null)
            {
                _logger.LogError("Not Found");
                return NotFound("Not Found");
            }
            _logger.LogInformation($"{id}");
            return Ok(templateDetail);
        }
        [HttpPost]
        public async Task<ActionResult<TemplateDetail>> Insert(TemplateDetail templateDetail)
        {
            if (templateDetail == null)
            {
                _logger.LogError("Null Object");
                return BadRequest("Null Object");
            }
            _templateDetailService.Insert(templateDetail);
            _logger.LogInformation($"{templateDetail.Id}");
            return Ok(templateDetail);
        }
        [HttpPut]
        public async Task<ActionResult<TemplateDetail>> Update(TemplateDetail templateDetail)
        {
            if (templateDetail == null)
            {
                _logger.LogError("Null Object");
                return BadRequest("Null Object");
            }
            if (templateDetail.Id == 0)
            {
                _logger.LogError("Object not in database");
                return BadRequest("Object not in database");
            }
            _templateDetailService.Update(templateDetail);
            _logger.LogInformation($"{templateDetail.Id}");
            return Ok(templateDetail);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TemplateDetail>> Delete(int id)
        {
            var templateDetail = await _templateDetailService.GetByID(id);
            if (templateDetail == null)
            {
                _logger.LogError("Object not in database");
                return BadRequest("Object not in database");
            }
            _templateDetailService.Delete(id);
            _logger.LogInformation($"{id}");
            return Ok(templateDetail);
        }
        [HttpGet]
        public async Task<ActionResult<TemplateDetail>> GetAll()
        {
            var templateDetails = await _templateDetailService.GetAll();
            if (templateDetails.Count == 0)
            {
                _logger.LogError("Not Found");
                return NotFound("Not Found");
            }
            templateDetails.ForEach(x => _logger.LogInformation($"{x.Id}"));
            return Ok(templateDetails);
        }
    }
}
