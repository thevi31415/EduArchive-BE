using EduArchive_BE.Data;
using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore;

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
        public User GetUserByUserName(string userName)
        {
            return _db.users.SingleOrDefault(u => u.UserName == userName);
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
        public User Login(string email, string password)
        {
            var user = _db.users.FirstOrDefault(u => u.Email == email);

            if (user != null && user.Password == password)
            {
                // Đăng nhập thành công
                return user;
            }
            else
            {
                // Đăng nhập thất bại
                return null;
            }
        }
    }
}
