using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
    }
}
