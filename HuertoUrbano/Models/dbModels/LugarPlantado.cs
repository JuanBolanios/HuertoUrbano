using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    [Table("LugarPlantado")]
    public partial class LugarPlantado
    {
        public LugarPlantado()
        {
            Publicacións = new HashSet<Publicación>();
        }

        [Key]
        [Column("idLugarPlantado")]
        public int IdLugarPlantado { get; set; }
        [StringLength(50)]
        public string DescLugarP { get; set; }

        [InverseProperty(nameof(Publicación.LugarPlantadoNavigation))]
        public virtual ICollection<Publicación> Publicacións { get; set; }
    }
}
