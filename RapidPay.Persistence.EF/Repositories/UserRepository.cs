using Microsoft.EntityFrameworkCore;
using RapidPay.Abstractions.Repositories;
using RapidPay.Persistence.EF.Persistence;

namespace RapidPay.Persistence.EF.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(RapidPayDbContext rapidPayDbContext) : base(rapidPayDbContext)
        {
        }

        public async Task<string> GetRoleByUserNameAsync(string username)
        {
            var user = await _rapidPayDbContext.Users.FirstAsync(x => x.Username == username);

            return user.Role;
        }

        public async Task<bool> ValidateCredentialsExistenceAsync(string username, string password)
        {
            return await _rapidPayDbContext.Users
                    .AnyAsync(x => x.Username.ToLower() == username.ToLower()
                    && x.Password.ToLower() == password.ToLower());
        }
    }
}
