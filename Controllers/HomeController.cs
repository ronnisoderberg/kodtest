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
        //var flavs = _ctx.Flavours.ToList();
        var model = new QuestionViewModel();
        model.Flavours = new List<CheckBoxItem>();
        var cb = new List<CheckBoxItem>();
        cb.Add(new CheckBoxItem()
        {
            Title = "Jordgubb",
            IsChecked = false,
        });
        cb.Add(new CheckBoxItem()
        {
            Title = "Choklad",
            IsChecked = false,
        });
        cb.Add(new CheckBoxItem()
        {
            Title = "Vanilj",
            IsChecked = false,
        });
        cb.Add(new CheckBoxItem()
        {
            Title = "Banan",
            IsChecked = false,
        });
        model.Flavours = cb;

        //flavs.ForEach(i =>
        //{
        //    model.Flavours.Add(new CheckBoxItem()
        //    {
        //        Id = i.Id,
        //        Title = i.Title,
        //        IsChecked = false
        //    });
        //});
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

