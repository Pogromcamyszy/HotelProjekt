using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
 
        public class Service
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ServiceID { get; set; }
            [MinLength(5), MaxLength(50)]
            [Required(ErrorMessage = "Prosze podaj Nazwe uslugi")]
            public string Name { get; set; }
            [MinLength(5), MaxLength(200)]
            [Required(ErrorMessage = "Prosze podaj Opis uslugi")]
            public string Description { get; set; }
        [RegularExpression(@"^[1-5]$", ErrorMessage = "Liczba Ocen musi być w zakresie 1 do 5")]
        [Required(ErrorMessage = "Prosze podaj Ocene uslugi")]
        public int Rating { get; set; }

        }
}
