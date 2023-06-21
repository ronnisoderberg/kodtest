using kodTest.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly DbContext _ctx;

    public HomeController(DbContext ctx)
    {
        _ctx = ctx;
    }

    public IActionResult Index()
    {
        var model = new QuestionViewModel();
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
                FavoriteIceCream = model.FavoriteIceCream
            };

            _ctx.Awnsers.Add(formData);
            _ctx.SaveChanges();

            return RedirectToAction("Stats");
        }

        return View(model);
    }

    public IActionResult Stats()
    {
        var questions = _ctx.Awnsers.ToList(); // Hämta alla svar från databasen

        return View(questions);
    }
}

