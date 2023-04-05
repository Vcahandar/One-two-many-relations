using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFramework_Slider.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            SliderInfo sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();

            IEnumerable<Blog> blogs = await _context.Blogs.Where(m=>!m.SoftDelete).ToListAsync();

            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();

            IEnumerable<Product> products = await _context.Products.Include(m=>m.Images).Where(m => !m.SoftDelete).ToListAsync();

            About about = await _context.Abouts.FirstOrDefaultAsync();

            IEnumerable<Expert> experts = await _context.Experts.Where(m => !m.SoftDelete).ToListAsync();

            ExpertHeader expertHeaders = await _context.ExpertHeaders.FirstOrDefaultAsync();

            Subscribe subscribe = await _context.Subscribes.FirstOrDefaultAsync();
            IEnumerable<Say> says= await _context.Says.Where(m => !m.SoftDelete).ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.Where(m => !m.SoftDelete).ToListAsync();




            HomeVM model = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo,
                Blogs = blogs,
                Categories = categories,
                Products = products,
                Abouts=about,
                ExpertHeader=expertHeaders,
                Experts=experts,
                Subscribes=subscribe,
                Says=says,
                Instagrams=instagrams

                
            };

            return View(model);
        }
    }
}