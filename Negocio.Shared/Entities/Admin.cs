using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Admin
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del administrador")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "El {1} no es una dirección válida")]
        [Required(ErrorMessage = "El {1} es obligatorio")]
        public string Email { get; set; }

        [Display(Name = "Rol")]
        [MaxLength(50, ErrorMessage = "El {2} no puede tener más de 50 caracteres")]
        [Required(ErrorMessage = "El {2} es obligatorio")]
        public string Role { get; set; }

        [JsonIgnore]
        public ICollection<Workspace> ManagedWorkspaces { get; set; }  

        [JsonIgnore]
        public ICollection<Event> ManagedEvents { get; set; }


    }
}
