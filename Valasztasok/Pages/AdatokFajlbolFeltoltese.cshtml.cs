using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Valasztasok.Models;

namespace Valasztasok.Pages
{
    public class AdatokFajlbolFeltolteseModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ValasztasDbContext _context;
        [BindProperty]
        public IFormFile Feltoltes { get; set; }

        public AdatokFajlbolFeltolteseModel(IWebHostEnvironment env, ValasztasDbContext context)
        {
            _env = env;
            _context = context;
        }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (Feltoltes == null || Feltoltes.Length == 0)
            {
                ModelState.AddModelError("Feltoltes", "Adj meg egy állományt");
                return Page();
            }


            var UploadDirPath = Path.Combine(_env.ContentRootPath, "uploads");
            var UploadFilePath = Path.Combine(UploadDirPath, Feltoltes.FileName);
            using (var stream = new FileStream(UploadFilePath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(stream);
            }

            StreamReader sr = new StreamReader(UploadFilePath);

            sr.ReadLine();
            List<Part> partok = _context.Partok.ToList();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elemek = line.Split();
                Jelolt ujJelolt = new Jelolt();

                ujJelolt.Kerulet =int.Parse(elemek[0]);
                ujJelolt.SzavazatokSzama = int.Parse(elemek[1]);
                ujJelolt.Nev = elemek[2] + " "+elemek[3];
                ujJelolt.PartRovidNev = elemek[4];
                if (!_context.Partok.Select(x => x.RovidNev).Contains(elemek[4]))
                {
                    partok.Add(new Part {RovidNev = elemek[4]});
                }
                _context.Add(ujJelolt);
            }

            sr.Close();
            _context.SaveChanges();
            System.IO.File.Delete(UploadFilePath);
            return Page();
        }
    }
}
