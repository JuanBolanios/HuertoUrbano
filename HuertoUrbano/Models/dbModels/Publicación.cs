using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    [Table("Publicación")]
    public partial class Publicación
    {
        [Key]
        [Column("idPublicacion")]
        public int IdPublicacion { get; set; }
        public int Usuarios { get; set; }
        public int TipoHortaliza { get; set; }
        public int LugarPlantado { get; set; }
        public int Temporada { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        public string FotoHortaliza { get; set; }


        [ForeignKey(nameof(LugarPlantado))]
        [InverseProperty("Publicacións")]
        public virtual LugarPlantado LugarPlantadoNavigation { get; set; }
        [ForeignKey(nameof(Temporada))]
        [InverseProperty(nameof(Temporadum.Publicacións))]
        public virtual Temporadum TemporadaNavigation { get; set; }
        [ForeignKey(nameof(TipoHortaliza))]
        [InverseProperty("Publicacións")]
        public virtual TipoHortaliza TipoHortalizaNavigation { get; set; }
    }
}
