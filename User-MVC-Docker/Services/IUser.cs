using User_MVC_Docker.DTO;

namespace User_MVC_Docker.Services
{
    public interface IUser
    {
        public Task<IQueryable<UserDTO>> GetUsers();
        public Task<Result> CreateUser(UserDTO input);
    }
}
