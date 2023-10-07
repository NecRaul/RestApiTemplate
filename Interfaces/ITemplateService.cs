using RestApiTemplate.Models;

namespace RestApiTemplate.Interfaces
{
    public interface ITemplateService
    {
        Task<Template> GetByID(int id);
        void Insert(Template template);
        void Update(Template template);
        void Delete(int id);
        Task<List<Template>> GetAll();
    }
}