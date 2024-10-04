using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Workspace
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del espacio de trabajo")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Descripción del espacio de trabajo")]
        public string Description { get; set; }

        [Display(Name = "Capacidad máxima")]
        [Range(1, 1000, ErrorMessage = "La {1} debe estar entre 1 y 1000")]
        public int Capacity { get; set; }

        [JsonIgnore]
        public ICollection<Resource> Resources { get; set; }  

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; } 

    }
}
