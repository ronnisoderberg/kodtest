using kodtest.Models;

namespace kodTest.Services
{
    public class DbSeed
    {
        private readonly DbContext _ctx;

        public DbSeed(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Seed()
        {

            var Awnsers = new List<QuestionViewModel>()
            {
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En fantastisk dag!",
                    Flavours = {"Banan", "Chocklad"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En spännande dag med vänner",
                    Flavours = {"Banan", "Jordgubb"}
                },
                new QuestionViewModel
                {
                    IsInSweden = false,
                    GoodDayDescription = "En mysig dag framför TV:n",
                    Flavours = {"Banan"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En produktiv dag på jobbet",
                    Flavours ={"Chocklad"}
                },
                new QuestionViewModel
                {
                    IsInSweden = false,
                    GoodDayDescription = "En äventyrlig dag i naturen",
                    Flavours = {"Banan", "Vanilj","Jordgubb","Chocklad"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En fartfylld dag på sportevenemanget",
                    Flavours = {"Vanilj"}
                },
                new QuestionViewModel
                {
                    IsInSweden = false,
                    GoodDayDescription = "En festlig dag med massor av leenden",
                    Flavours = {"Banan", "Jordgubb"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En trevlig dag med familjen",
                    Flavours = {"Banan", "Jordgubb"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En romantisk dag med din partner",
                    Flavours = {"Banan", "Jordgubb"}
                },
                new QuestionViewModel
                {
                    IsInSweden = true,
                    GoodDayDescription = "En rolig dag på nöjesparken",
                    Flavours = {"Banan", "Jordgubb"}
                }

            };

        var setFlavours = new List<Flavour>()
            {
                new Flavour() { Title = "Jordgubb" },
                new Flavour() { Title = "Vanilj" },
                new Flavour() { Title = "Jordgubb" },
                new Flavour() { Title = "Chocklad" },
            };
            await _ctx.AddRangeAsync(setFlavours);
            await _ctx.AddRangeAsync(Awnsers);


            await _ctx.SaveChangesAsync();
        }


        public async Task RecreateDatabase()
        {
            await _ctx.Database.EnsureDeletedAsync();
            await _ctx.Database.EnsureCreatedAsync();
        }

        public async Task RecreateAndSeed()
        {
            await RecreateDatabase();
            await Seed();
        }

        public async Task CreateIfNotExist()
        {
            await _ctx.Database.EnsureCreatedAsync();
        }

        

    }
}
