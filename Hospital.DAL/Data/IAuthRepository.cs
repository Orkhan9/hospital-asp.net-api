using System.Threading.Tasks;
using Hospital.DAL.Entities;

namespace Hospital.DAL
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password,int roleId);
        Task<User> Login(string userName, string password,string role);
        Task<bool> UserExists(string userName); 
    }
}