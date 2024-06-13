using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EduArchive_BE.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByUserName(string userName);
        bool AddUser(User user);
        User Login(string email, string password);
        User LoginGoogle(string idGoogle, string email, string userName, string Avatar);
    }
}
