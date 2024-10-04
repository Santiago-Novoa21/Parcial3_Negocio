using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio.Shared.Entities
{
    public class Membership
    {

        public int Id { get; set; }

        [Display(Name = "Nivel del miembro")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener mas de 50 caracteres")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Level { get; set; }



        [Display(Name = "Privilegios del miembro")]
        [MaxLength(150, ErrorMessage = "El {1} no puede tener mas de 150 caracteres")]
        [Required(ErrorMessage = "El {1} es obligatorio")]
        public string Privileges { get; set; }


        [JsonIgnore]
        public ICollection<Member> Members { get; set; }



    }
}
