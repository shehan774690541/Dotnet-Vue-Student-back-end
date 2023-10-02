using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learnMySQL.Models
{
    [Table("students")]
    public class StudentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

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
        public string pic_url { get; set; }




    }
}
