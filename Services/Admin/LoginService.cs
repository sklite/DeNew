using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DeNew.Models;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DeNew.Services.Admin
{
    public class LoginService : ILoginService
    {
        private IHashCalculator _hashCalculator;
        private DeContext _dbContext;

        public LoginService(IHashCalculator hashCalculator, DeContext dbContext)
        {
            _dbContext = dbContext;
            _hashCalculator = hashCalculator;
        }


        public async Task<User> MakeLoginAttempt(LoginViewModel loginData)
        {
            var passwordHash = _hashCalculator.GetHash(loginData.Password);
            var result = await _dbContext.Users.FirstOrDefaultAsync(user =>
                user.Login == loginData.Login && user.PasswordHash == passwordHash);
            return result;
        }
    }
}