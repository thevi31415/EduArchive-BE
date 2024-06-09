using EduArchive_BE.Data;
using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _db; 
        public UserRepository(ApplicationDbContext db) {
          _db = db;
       
        }
        public List<User> GetAllUser() {
            return _db.users.ToList();
        }
        public User GetUserById(Guid id)
        {
            return _db.users.SingleOrDefault(u => u.Id == id);
        }
    }
}
