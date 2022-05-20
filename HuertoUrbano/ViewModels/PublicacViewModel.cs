using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuertoUrbano.ViewModels
{
    public class PublicacViewModel
    {
        [Required(ErrorMessage = "Este campo el obligatorio")]
        [DisplayName("Apodo del usuario:")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo el obligatorio")]
        [DisplayName("Descripción:")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo el obligatorio")]
        [DisplayName("Tipo de Hortaliza:")]
        public int TipoHortaliza { get; set; }
        public List<SelectListItem> TipoHortalizas { get; set; }
        [Required(ErrorMessage = "Este campo el obligatorio")]
        [DisplayName("Ciudad:")]
        public string Ciudad { get; set; }
        public IFormFile Fotografia { get; set; }
    }
}
