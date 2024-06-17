using EduArchive_BE.Data;
using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly ApplicationDbContext _db;
        public SubjectRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public List<Subject> getAllSubject() {

            return _db.subjects.ToList();
        }
        public List<Subject> GetRandomSubjects()
        {
            // Sử dụng phương thức LINQ để lấy về 5 subject ngẫu nhiên
            return _db.subjects.OrderBy(s => Guid.NewGuid()).Take(5).ToList();
        }
        public bool AddSubject(Subject subject)
        {

            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            try
            {
                subject.id = Guid.NewGuid();
              
                subject.Status = 1;
                _db.subjects.Add(subject);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception (ex) if necessary
                return false;
            }

        }
        public Subject GetSubjectById(Guid id)
        {
            return _db.subjects.SingleOrDefault(u => u.id == id);
        }
    }
}
