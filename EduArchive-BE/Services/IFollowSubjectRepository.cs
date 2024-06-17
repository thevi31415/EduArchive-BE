using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface IFollowSubjectRepository
    {
        bool AddFollowSubject(FollowSubject followSubject);
        bool CheckFollowSubject(Guid subjectId, Guid userId);
        List<FollowSubject> GetFollowSubjectsByIduser(Guid userId);
        bool RemoveFollowSubject(Guid subjectId, Guid userId);  
    }
}
