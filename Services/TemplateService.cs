using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Interfaces;
using RestApiTemplate.Models;
using RestApiTemplate.Repository;

namespace RestApiTemplate.Services
{
    public class TemplateService : ITemplateService
    {
        private IRepository<Template> _repository;
        public TemplateService(IRepository<Template> repository)
        {
            _repository = repository;
        }
        public async Task<Template> GetByID(int id)
        {
            return await _repository.GetAll().AsNoTracking().Include(x => x.TemplateDetails).FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Insert(Template template)
        {
            _repository.Insert(template);
        }
        public void Update(Template template)
        {
            _repository.Update(template);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public async Task<List<Template>> GetAll()
        {
            return await _repository.GetAll().AsNoTracking().Include(x => x.TemplateDetails).OrderBy(x => x.Id).ToListAsync();
        }
    }
}