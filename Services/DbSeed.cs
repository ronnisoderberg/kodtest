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

            //var Awnsers = new List<QuestionViewModel>()
            //{
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En fantastisk dag!",
            //        //FavoriteIceCream = "choklad"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = false,
            //        GoodDayDescription = "En lugn dag i solen",

            //        //FavoriteIceCream = "jordgubb"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En spännande dag med vänner",
            //        FavoriteIceCream = "banan"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = false,
            //        GoodDayDescription = "En mysig dag framför TV:n",
            //        FavoriteIceCream = "vanilj"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En produktiv dag på jobbet",
            //        FavoriteIceCream = "choklad, jordgubb"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = false,
            //        GoodDayDescription = "En äventyrlig dag i naturen",
            //        FavoriteIceCream = "choklad, banan"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En fartfylld dag på sportevenemanget",
            //        FavoriteIceCream = "choklad, jordgubb, banan"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = false,
            //        GoodDayDescription = "En festlig dag med massor av leenden",
            //        FavoriteIceCream = "choklad, jordgubb, vanilj"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En trevlig dag med familjen",
            //        FavoriteIceCream = "choklad, vanilj"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En romantisk dag med din partner",
            //        FavoriteIceCream = "jordgubb, banan"
            //    },
            //    new QuestionViewModel
            //    {
            //        IsInSweden = true,
            //        GoodDayDescription = "En rolig dag på nöjesparken",
            //        FavoriteIceCream = "jordgubb, vanilj"
            //    }

            //};
            var flavours = new List<Flavour>()
            {
                new Flavour() { Title = "Vanilj" },
                new Flavour() { Title = "Choklad" },
                new Flavour() { Title = "Päron" },
                new Flavour() { Title = "Jordgubb" },
            };
            await _ctx.AddRangeAsync(flavours);

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
