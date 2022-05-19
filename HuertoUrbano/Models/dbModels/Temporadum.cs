using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HuertoUrbano.Models.dbModels
{
    public partial class Temporadum
    {
        public Temporadum()
        {
            Publicacións = new HashSet<Publicación>();
        }

        [Key]
        [Column("idTemporada")]
        public int IdTemporada { get; set; }
        [StringLength(50)]
        public string DescTemporada { get; set; }

        [InverseProperty(nameof(Publicación.TemporadaNavigation))]
        public virtual ICollection<Publicación> Publicacións { get; set; }
    }
}
