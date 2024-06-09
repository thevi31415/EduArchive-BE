using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EduArchive_BE.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User GetUserById(Guid id);
        bool AddUser(User user);
    }
}
