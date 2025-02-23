using CrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudOperations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Dependy Injection
        private readonly KisiContext _context;


        public HomeController(ILogger<HomeController> logger , KisiContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.KisiListe = _context.Kisilers.ToList();
            return View();
        }

        [HttpPost]

        public IActionResult Index(Kisiler Kisi)
        {

            _context.Add(Kisi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Kisi_Sil(int ID)
        {
            var Silinecek_Kisi = await _context.Kisilers.FindAsync(ID);
            _context.Remove(Silinecek_Kisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Kisi_Güncelle(int ID)
        {
            var Guncelleneck_Kisi = _context.Kisilers.Find(ID);
            return View(Guncelleneck_Kisi);
            //return RedirectToAction(nameof(Index));
            //_context.Update(Guncelleneck_Kisi);
            //return RedirectToAction($"{nameof(Index)}");
            

        }

        [HttpPost]
        public IActionResult Kisi_Güncelle(Kisiler kisi)
        {
            _context.Update(kisi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
