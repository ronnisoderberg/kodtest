using kodtest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            model.CheckBoxes = new List<CheckBoxItem>();

            flavs.ForEach(i =>
            {
                model.CheckBoxes.Add(new CheckBoxItem()
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

        if (!ModelState.IsValid)
        {
            return View(model);
        }
        

            var favFlavs = model.CheckBoxes.Where(x => x.IsChecked).ToList();

            var formData = new QuestionViewModel()
            {
                IsInSweden = model.IsInSweden,
                GoodDayDescription = model.GoodDayDescription,
                CheckBoxes = model.CheckBoxes.Where(x => x.IsChecked).ToList(),
                Flavours = favFlavs.Select(x => x.Title).ToList()


            };

            _ctx.Awnsers.Add(formData);
            _ctx.SaveChanges();

            return RedirectToAction("Stats");
        
     
    }

    public IActionResult Stats()
    {

        


        var awnsers = _ctx.Awnsers.ToList();

        var test = _ctx.Flavours.ToList();



        var unicFlavs = awnsers.SelectMany(i => i.Flavours).Distinct().ToList();

        List<int> Question3 = new List<int>();

        foreach (var item in unicFlavs)
        {
            var count = awnsers.Where(i => i.Flavours.Contains(item)).Count();
            Question3.Add(count);
        }

        ViewBag.Q3Labels = JsonConvert.SerializeObject(unicFlavs);
        ViewBag.Q3DataPoints = JsonConvert.SerializeObject(Question3);


        return View(awnsers);
    }
}

