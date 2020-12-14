using System.Threading.Tasks;
using Hospital.BLL.DTO.User;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(UserForLoginDto userForLoginDto);
        Task<bool> UserExists(string userName); 
    }
}