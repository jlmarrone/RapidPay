namespace RapidPay.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidateCredentialsExistenceAsync(string username, string password);

        Task<string> GetRoleByUserNameAsync(string username);
    }
}
