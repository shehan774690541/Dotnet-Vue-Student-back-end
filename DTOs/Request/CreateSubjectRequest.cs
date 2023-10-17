using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace learnMySQL.DTOs.Request
{
    public class CreateSubjectRequest
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Check { get; set; }
    }
}
