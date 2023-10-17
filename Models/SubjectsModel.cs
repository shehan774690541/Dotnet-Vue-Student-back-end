using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace learnMySQL.Models
{
    [Table("subjects")]
    public class SubjectsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Check { get; set; }

    }
}
