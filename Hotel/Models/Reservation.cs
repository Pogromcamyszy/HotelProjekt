using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int ResID { get; set; }
        [Required(ErrorMessage = "Prosze wybierz Numer pokoju")]
        public int RoomID { get; set; }

        [ForeignKey("Guests")]
        [Required(ErrorMessage = "Prosze wybierz Numer klienta")]
        public int UserID { get; set; }

        [ForeignKey("Services")]
        public int? ServiceID { get; set; }
        [MinLength(10,ErrorMessage ="Pole nie może zawierać mniej niż 10 znaków")]
        [MaxLength(200, ErrorMessage = "Pole nie może zawierać więcej niż 200 znaków")]
        public string? ReservationDescription { get; set; }
        [Required(ErrorMessage = "Podaj prawidłową date")]
        public DateTime Startofdate { get; set; }
        [Required(ErrorMessage = "Podaj prawidłową date")]
        public DateTime Endofdate { get; set; }

        public Guest Guests { get; set; }

        public Service Service { get; set; }

        public Room Rooms { get; set; }
    }
}