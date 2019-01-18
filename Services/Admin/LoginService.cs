using System.Linq;
using System.Threading;
using DeNew.Models;
using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Administrator;

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


        public User MakeLoginAttempt(LoginViewModel loginData)
        {
            var passwordHash = _hashCalculator.GetHash(loginData.Password);
            var result = _dbContext.Users.FirstOrDefault(user =>
                user.Login == loginData.Login && user.PasswordHash == passwordHash);
            return result;
        }
    }
}