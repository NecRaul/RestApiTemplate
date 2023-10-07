using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Interfaces;
using RestApiTemplate.Models;
using RestApiTemplate.Repository;

namespace RestApiTemplate.Services
{
    public class TemplateDetailService : ITemplateDetailService
    {
        private IRepository<TemplateDetail> _repository;
        public TemplateDetailService(IRepository<TemplateDetail> repository)
        {
            _repository = repository;
        }
        public async Task<TemplateDetail> GetByID(int id)
        {
            return await _repository.GetAll().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Insert(TemplateDetail templateDetail)
        {
            _repository.Insert(templateDetail);
        }
        public void Update(TemplateDetail templateDetail)
        {
            _repository.Update(templateDetail);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public async Task<List<TemplateDetail>> GetAll()
        {
            return await _repository.GetAll().AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }
    }
}