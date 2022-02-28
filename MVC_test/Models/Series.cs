using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_test.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Episodes { get; set; }
        [DisplayName("Review Score")]
        [Range(0, 10,ErrorMessage ="Review scores are 0 to 10.")]
        public int ReviewScore { get; set; }
        [Column(TypeName = "Date")]
        [DisplayName("Premiere Date")]
        public DateTime RelaseDate { get; set; }
    }
}
