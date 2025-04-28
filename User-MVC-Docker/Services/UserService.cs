using Microsoft.EntityFrameworkCore;
using User_MVC_Docker.DTO;
using User_MVC_Docker.Models;
using User_MVC_Docker.Models.Context;

namespace User_MVC_Docker.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Result> CreateUser(UserDTO input)
        {
            var result = new Result();
            
            try
            {
                var user = new User()
                {
                    Id = input.Id,
                    Name = input.Name,
                    Country = input.Country,
                    Email = input.Email,
                    Age = input.Age,
                    PhoneNumber = input.PhoneNumber,
                };

                await _db.User.AddAsync(user);
                await _db.SaveChangesAsync();

                result.Success = true;
                result.Message = null;
            }
            catch(Exception ex)
            {
                result.Message = ex.Message;
                
            };
            return result;
        }

        public async Task<IQueryable<UserDTO>> GetUsers()
        {
            var userList = _db.User.AsNoTracking().Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Country = u.Country,
                Age = u.Age,
                PhoneNumber = u.PhoneNumber,
            }).AsQueryable();

            return await Task.FromResult(userList);
        }
    }
}
