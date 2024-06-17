using EduArchive_BE.Data;
using EduArchive_BE.Model;
using System.Reflection.Metadata;

namespace EduArchive_BE.Services
{
    public class FollowSubjectRepository: IFollowSubjectRepository
    {
        
        private readonly ApplicationDbContext _db;
        public FollowSubjectRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public List<FollowSubject> GetFollowSubjectsByIduser(Guid userId) {
            return _db.followSubjects
                    .Where(fs => fs.idUser == userId)
                    .ToList();
        }
        

        public bool AddFollowSubject(FollowSubject followSubject) {
        try
            {
             
                _db.followSubjects.Add(followSubject);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public bool CheckFollowSubject(Guid subjectId, Guid userId) {
            return _db.followSubjects.Any(fs => fs.idSubject == subjectId && fs.idUser == userId);
        }

        public bool RemoveFollowSubject(Guid subjectId, Guid userId)
        {
            try
            {
                var followSubject = _db.followSubjects
                                   .FirstOrDefault(fs => fs.idSubject == subjectId && fs.idUser == userId);
                if (followSubject != null)
                {
                    _db.followSubjects.Remove(followSubject);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

               
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}
