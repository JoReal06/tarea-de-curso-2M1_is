using Empresa_API_FINAL.DATA;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace Empresa_API_FINAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EmpresaContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public UserRepository(EmpresaContext context,
            IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            return await _context.usuarios.FindAsync(id);
        }

        public Task<Usuario> GetUserByUserNameAsync(string userName)
        {
            return _context.usuarios.SingleOrDefaultAsync(u => u.Nombre == userName);
        }

        public async Task RegisterUserAsync(Usuario user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            _context.usuarios.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateUserAsync(string userName, string password)
        {
            var user = await GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return false;
            }
            var verificationResult =
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
