using System.ComponentModel.DataAnnotations;

namespace RestApiTemplate.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}