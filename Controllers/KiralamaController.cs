using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLibrarySystem.Models;

namespace WebUygulamaProje1.Controllers
{
    [Authorize(Roles = "Admin")]
	// link ile erişememek için authorize edilmeli.
    public class KiralamaController : Controller
    {
        private readonly IKiralamaRepository _kiralamaRepository;
		private readonly IKitapRepository _kitapRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;
		public KiralamaController(IKiralamaRepository kiralamaRepository, IKitapRepository kitapRepository, IWebHostEnvironment webHostEnvironment)
		{
			_kiralamaRepository = kiralamaRepository;
			_kitapRepository = kitapRepository;
			_webHostEnvironment = webHostEnvironment;
		}
        public IActionResult Index()
        {
           // var kitaplar = _kitapRepository.GetAll(); // Veritabanından tüm kitapları çeker
		   List<Kiralama> objKiralamaList = _kiralamaRepository.GetAll(includeProps:"Kitap").ToList(); // Include ile foreign key ilişkili tabloları çekiyoruz.
            return View(objKiralamaList);
        }
        public IActionResult EkleGuncelle(int? id)
        {
			IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll()
				.Select(k => new SelectListItem
				{
					Text = k.KitapAdi,
					Value = k.Id.ToString()
				});
			ViewBag.KitapList = KitapList;

			if (id == null || id==0)
			{
				// ekle
				return View();
			}
			else
			{
				// guncelleme
				Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);  // Expression<Func<T, bool>> filtre
				if (kiralamaVt == null)
				{
					return NotFound();
				}
				return View(kiralamaVt);
			}			
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kiralama kiralama)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);

			if (ModelState.IsValid)
			{
				
				if (kiralama.Id == 0)
				{
					_kiralamaRepository.Ekle(kiralama);
					TempData["basarili"] = "Yeni kiralama kaydı başarıyla oluşturuldu!";
				}
				else
				{
					_kiralamaRepository.Guncelle(kiralama);
					TempData["basarili"] = "Kiralama kaydı güncelleme başarılı!";
				}											
				
				_kiralamaRepository.Kaydet(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
                return RedirectToAction("Index", "Kiralama");
            }
            return View();                                 
		}
      
        public IActionResult Sil(int? id)
		{

            IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.KitapAdi,
                    Value = k.Id.ToString()
                });
            ViewBag.KitapList = KitapList;


            if (id == null || id == 0)
			{
				return NotFound();
			}
			Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);
			if (kiralamaVt == null)
			{
				return NotFound();
			}
			return View(kiralamaVt);
		}

		[HttpPost, ActionName("Sil")]
     
        public IActionResult SilPOST(int? id)		
		{
			Kiralama? kiralama = _kiralamaRepository.Get(u => u.Id == id);
			if (kiralama == null)
			{
				return NotFound();
			}
			_kiralamaRepository.Sil(kiralama);
			_kiralamaRepository.Kaydet();
			TempData["basarili"] = "Kayıt Silme işlemi başarılı!";
			return RedirectToAction("Index", "Kiralama");
		}
	}
}
