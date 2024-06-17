using EduArchive_BE.Data;
using EduArchive_BE.Model;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

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
        public User GetUserById(Guid id , string IdGoogle)
        {
            return _db.users.SingleOrDefault(u => u.Id == id && u.IdGoogle == IdGoogle);
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
        public User LoginGoogle(string idGoogle, string email, string userName, string Avatar)
        {
            var user = _db.users.SingleOrDefault(u => u.IdGoogle == idGoogle && u.Email == email);

            if (user == null)
            {
                // Nếu người dùng chưa tồn tại, tạo tài khoản mới
                user = new User
                {
                     Id = Guid.NewGuid(),
                     IdGoogle = idGoogle,
                     Name = userName,
                     UserName = GenerateUsername(userName),
                     Email = email,
                     Role="User",
                     Avartar = Avatar,
                     Password= "123",
                     CreatedDate = DateTime.Now,
                     LastVisit  = DateTime.Now,
                     Staus=1,
                };

                _db.users.Add(user);
                _db.SaveChanges();
            }

            // Trả về thông tin người dùng
            return user;
        }
        public static string GenerateUsername(string name)
        {
            // Bỏ dấu tiếng Việt
            string normalizedString = name.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string nameWithoutDiacritics = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            // Loại bỏ khoảng trắng và chuyển thành chữ thường
            string userName = Regex.Replace(nameWithoutDiacritics, @"\s+", "").ToLower();

            // Thêm 4 số ngẫu nhiên vào cuối
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999);
            userName += randomNumber;

            return userName;
        }

    }
}
