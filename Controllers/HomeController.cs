using kodtest.Models;
using kodTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly kodTest.Services.DbContext _ctx;

    public HomeController(kodTest.Services.DbContext ctx)
    {
        _ctx = ctx;
    }

    public IActionResult Index()
    {
        var flavs = _ctx.Flavours.ToList();
        var model = new QuestionViewModel();
        model.Flavours = new List<CheckBoxItem>();
       
        flavs.ForEach(i =>
        {
            model.Flavours.Add(new CheckBoxItem()
            {
                Title = i.Title,
                IsChecked = false
            });
        });
        return View(model);
        
    }

    [HttpPost]
    public IActionResult Index(QuestionViewModel model)
    {
        if (ModelState.IsValid)
        {
            var formData = new QuestionViewModel()
            {
                IsInSweden = model.IsInSweden,
                GoodDayDescription = model.GoodDayDescription,
                Flavours = model.Flavours.Where(i => i.IsChecked == true).ToList()
                //Flavours = model.Flavours.ToList()


                //FavoriteIceCream = model.FavoriteIceCream
            };

            _ctx.Awnsers.Add(formData);
            _ctx.SaveChanges();

            return RedirectToAction("Stats");
        }
        //model.IsInSweden = model.IsInSweden == null ? false : true;
        //model.FavoriteIceCream = null;
        return View(model);
    }

    public IActionResult Stats()
    {
        var questions = _ctx.Awnsers.Include(i => i.Flavours).ToList(); // Hämta alla svar från databasen

        return View(questions);
    }
}

