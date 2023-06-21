namespace kodTest.Services
{
    public class DataHandlers
    {
        private readonly DbContext _ctx;

        public DataHandlers(DbContext ctx)
        {
            _ctx = ctx;
        }

        public List<QuestionViewModel> Awnsers()
        {
            var DbAwnsers = _ctx.Awnsers.ToList();
            return DbAwnsers;
            
        }

    }
}
