using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Member
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del miembro")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "El {1} no es una dirección válida")]
        [Required(ErrorMessage = "El {1} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Número de teléfono")]
        [MaxLength(15, ErrorMessage = "El {2} no puede tener más de 15 caracteres")]
        public string PhoneNumber { get; set; }

        public int MembershipId { get; set; }

        [JsonIgnore]
        public Membership Memberships { get; set; }

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; }

    }

}
