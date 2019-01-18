using DeNew.Models.Entities;
using DeNew.Models.ViewModels.Administrator;

namespace DeNew.Services.Admin
{
    public interface ILoginService
    {
        User MakeLoginAttempt(LoginViewModel loginData);
    }
}