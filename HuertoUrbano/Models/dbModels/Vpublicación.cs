using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    [Keyless]
    public partial class Vpublicación
    {
        [Column("idPublicacion")]
        public int IdPublicacion { get; set; }
        public int Usuarios { get; set; }
        public int TipoHortaliza { get; set; }
        [StringLength(50)]
        public string DescTipoHortaliza { get; set; }
        public int LugarPlantado { get; set; }
        [StringLength(50)]
        public string DescLugarP { get; set; }
        public int Temporada { get; set; }
        [StringLength(50)]
        public string DescTemporada { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        public string FotoHortaliza { get; set; }
    }
}
