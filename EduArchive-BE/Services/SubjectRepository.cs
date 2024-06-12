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
    }
}
