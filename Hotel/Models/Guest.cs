using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public int UserID { get; set; }

        [MaxLength(50, ErrorMessage = "Pole nie moze zawierać wiecej niż 50 znaków")]
        public string? Name { get; set; }
        [MaxLength(50,ErrorMessage = "Pole nie moze zawierać wiecej niż 50 znaków")]
        public string? Surename { get; set; }
        [EmailAddress(ErrorMessage = "Nieprawidlowy adres Email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Podaj prawidłowy numer telefonu")]
        public string? Phone { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
