using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Negocio.Shared.Entities
{
    public class Reservation
    {

        public int Id { get; set; }

        [Display(Name = "Fecha de inicio")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha de fin")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }

        [JsonIgnore]
        public Member Member { get; set; } 

        public int WorkspaceId { get; set; }

        [JsonIgnore]
        public Workspace Workspace { get; set; }  

        [JsonIgnore]
        public ICollection<Resource> Resources { get; set; }

    }
}
