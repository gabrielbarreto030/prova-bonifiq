using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public abstract class DefaultService<T>
    {
        protected TestDbContext _ctx;

        public DefaultService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public abstract DefaultList<T> GetList(int page);
    }
}
