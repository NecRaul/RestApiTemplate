using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiTemplate.Models
{
    public class TemplateDetail : BaseEntity
    {
        [ForeignKey("Template")]
        public int TemplateID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Value { get; set; } = 0;
    }
}