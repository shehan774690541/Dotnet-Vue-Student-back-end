using System.ComponentModel.DataAnnotations;

namespace learnMySQL.DTOs
{
    public class SubjectDTO
    {
        [Required] 
        public long Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Check { get; set; }
    }
}
