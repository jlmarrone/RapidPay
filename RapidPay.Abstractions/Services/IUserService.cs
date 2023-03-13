namespace RapidPay.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentialsExistenceAsync(string username, string password);

        Task<string> GetRoleByUserNameAsync(string username);
    }
}
