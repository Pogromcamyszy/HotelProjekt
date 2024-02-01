using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Podaj numer pokoju")]
        [RegularExpression(@"^[0-999]$", ErrorMessage = "Liczba musi być w zakresie 0 do 999")]
        public int RoomNr { get; set; }

        [MinLength(10,ErrorMessage ="Pole musi zawierać conajmniej 10 znaków"), MaxLength(50)]
        [Required(ErrorMessage = "Prosze podaj opis pokoju")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Podaj ilosc łóżek w pokoju")]
        [RegularExpression(@"^[0-5]$", ErrorMessage = "Liczba musi być w zakresie 1 do 5")]
        public int BedsCount { get; set; }

        [Required(ErrorMessage = "Podaj dostepnosc pokoju")]
        public bool Availability { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
