using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.DB;
using Product_CRUD.Models;

namespace Product_CRUD.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _dbContext;

        public AccountRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(SignUpModel signUpModel)
        {
            var user = new User() { 
            Email=signUpModel.Email,
            Name= signUpModel.Name,
            Password=signUpModel.Password,
            };
            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Login(SignInModel signInModel)
        {
            var userExist=await _dbContext.Users.Where(u=>u.Email==signInModel.Email && u.Password==signInModel.Password).FirstOrDefaultAsync();
            return userExist;
        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
