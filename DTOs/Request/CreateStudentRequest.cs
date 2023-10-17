using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;

namespace learnMySQL.DTOs.Request
{
    public class CreateStudentRequest
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set;}

        [Required]
        public string address { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phone_number { get; set; }

        [Required]
        public string pic_url {get; set; }

        //[Required]
        //public string pic_file { get; set; }
    }
}
