using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;

namespace EduArchive_BE.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserByUserName(string userName);
        User GetUserById(Guid  id, string IdGoogle);

        bool AddUser(User user);
        User Login(string email, string password);
        User LoginGoogle(string idGoogle, string email, string userName, string Avatar);
    }
}
