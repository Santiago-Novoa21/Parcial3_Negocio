using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Resource
    {

        public int Id { get; set; }

        [Display(Name = "Nombre del recurso")]
        [MaxLength(100, ErrorMessage = "El {0} no puede tener más de 100 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Descripción del recurso")]
        [MaxLength(200, ErrorMessage = "El {1} no puede tener más de 200 caracteres")]
        public string Description { get; set; }

        [Display(Name = "Disponible")]
        public bool Available { get; set; }

        [JsonIgnore]
        public ICollection<Workspace> Workspaces { get; set; } 
    }

}

