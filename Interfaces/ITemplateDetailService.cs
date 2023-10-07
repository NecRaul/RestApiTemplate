using RestApiTemplate.Models;

namespace RestApiTemplate.Interfaces
{
    public interface ITemplateDetailService
    {
        Task<TemplateDetail> GetByID(int id);
        void Insert(TemplateDetail templateDetail);
        void Update(TemplateDetail templateDetail);
        void Delete(int id);
        Task<List<TemplateDetail>> GetAll();
    }
}