using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    [Table("TipoHortaliza")]
    public partial class TipoHortaliza
    {
        public TipoHortaliza()
        {
            Publicacións = new HashSet<Publicación>();
        }

        [Key]
        [Column("idTipoHortaliza")]
        public int IdTipoHortaliza { get; set; }
        [StringLength(50)]
        public string DescTipoHortaliza { get; set; }

        [InverseProperty(nameof(Publicación.TipoHortalizaNavigation))]
        public virtual ICollection<Publicación> Publicacións { get; set; }
    }
}
