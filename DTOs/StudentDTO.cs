using System.ComponentModel.DataAnnotations;

namespace learnMySQL.DTOs
{
    public class StudentDTO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phone_number { get; set; }

        [Required]
        public string pic_url { get; set; }
    }
}
