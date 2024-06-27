using SharedModels;

namespace Empresa_API_FINAL.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<Usuario> GetUserByUserNameAsync(string userName);
        Task<Usuario> GetUserByIdAsync(int id);
        Task<bool> ValidateUserAsync(string userName, string password);
        Task RegisterUserAsync(Usuario user, string password);
    }
}
