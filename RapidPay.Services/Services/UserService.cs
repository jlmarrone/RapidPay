using RapidPay.Abstractions.Repositories;
using RapidPay.Abstractions.Services;

namespace RapidPay.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetRoleByUserNameAsync(string username) =>
            await _userRepository.GetRoleByUserNameAsync(username);

        public async Task<bool> ValidateCredentialsExistenceAsync(
            string username, string password) =>
                await _userRepository.ValidateCredentialsExistenceAsync(username, password);
    }
}
