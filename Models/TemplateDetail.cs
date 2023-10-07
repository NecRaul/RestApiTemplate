namespace RestApiTemplate.Models
{
    public class TemplateDetail : BaseEntity
    {
        public int TemplateID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; } = 0;
    }
}