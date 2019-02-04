using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Administrator;
using System.Threading.Tasks;

namespace DeNew.Services.Admin
{
    public interface ILoginService
    {
         Task<User> MakeLoginAttempt(LoginViewModel loginData);

    }
}