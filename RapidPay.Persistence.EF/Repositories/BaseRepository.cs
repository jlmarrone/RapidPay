using RapidPay.Persistence.EF.Persistence;

namespace RapidPay.Persistence.EF.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly RapidPayDbContext _rapidPayDbContext;

        protected BaseRepository(RapidPayDbContext rapidPayDbContext)
        {
            _rapidPayDbContext = rapidPayDbContext;
        }
    }
}
