using HuertoUrbano.Models;
using HuertoUrbano.Models.dbModels;
using HuertoUrbano.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HuertoUrbano.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HuertoUrbanoContext _dbcontext;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, HuertoUrbanoContext dbcontext, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Blog()
        {
            List<TipoHortaliza> tipohort = _dbcontext.TipoHortalizas.ToList();
            List<SelectListItem> lsttipohort = new List<SelectListItem>();

            foreach(TipoHortaliza hortaliza in tipohort)
            {
                lsttipohort.Add(new SelectListItem { Value = hortaliza.IdTipoHortaliza.ToString(), Text = hortaliza.DescTipoHortaliza });
            }

            PublicacViewModel rvm = new PublicacViewModel
            {
                TipoHortalizas = lsttipohort
            };
            return View(rvm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Blog(PublicacViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostingEnvironment.WebRootPath;
                    string nombreArchivo = Path.GetFileNameWithoutExtension(rvm.Fotografia.FileName);
                    string extensionArchivo = Path.GetExtension(rvm.Fotografia.FileName);
                    nombreArchivo = nombreArchivo + DateTime.Now.ToString("yymmssfff") + extensionArchivo;

                    string path = Path.Combine(wwwRootPath + "/img/imgsubidas", nombreArchivo);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await rvm.Fotografia.CopyToAsync(fileStream);
                    }
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        Publicación hortaliza = new Publicación
                        {
                            Usuarios = user.Id,
                            Nombre = rvm.Nombre,
                            Descripcion = rvm.Descripcion,
                            TipoHortaliza = rvm.TipoHortaliza,
                            Ciudad = rvm.Ciudad,
                            FotoHortaliza = "/img/imgsubidas" + nombreArchivo
                        };
                        _dbcontext.Publicacións.Add(hortaliza);
                        _dbcontext.SaveChanges();
                    }
                }catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                
            }
            return View(rvm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
