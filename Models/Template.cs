using System.ComponentModel.DataAnnotations;

namespace RestApiTemplate.Models
{
    public class Template : BaseEntity
    {
        public Template()
        {
            TemplateDetails = new List<TemplateDetail>();
        }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Value { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public List<TemplateDetail> TemplateDetails { get; set; }
    }
}