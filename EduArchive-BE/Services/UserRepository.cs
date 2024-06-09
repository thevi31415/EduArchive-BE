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
        public bool AddUser(User user)
        {
           
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                try
                {
                     user.Id = Guid.NewGuid();
                     user.CreatedDate = DateTime.Now;
                user.Staus = 1;
                    _db.users.Add(user);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Log exception (ex) if necessary
                    return false;
                }
            
        }
    }
}
