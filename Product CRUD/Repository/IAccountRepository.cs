using Microsoft.AspNetCore.Identity;
using Product_CRUD.DB;
using Product_CRUD.Models;

namespace Product_CRUD.Repository
{
    public interface IAccountRepository
    {
        Task<User> CreateUserAsync(SignUpModel signUpModel);
        Task<User> Login(SignInModel signInModel);
        Task SignOut();
    }
}
