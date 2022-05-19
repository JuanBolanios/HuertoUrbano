using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HuertoUrbano.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Publicacións = new HashSet<Publicación>();
        }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [InverseProperty(nameof(Publicación.UsuariosNavigation))]
        public virtual ICollection<Publicación> Publicacións { get; set; }
    }
}
