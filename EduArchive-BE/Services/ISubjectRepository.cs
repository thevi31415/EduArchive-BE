using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface ISubjectRepository
    {
        List<Subject> getAllSubject();
        bool AddSubject (Subject subject);
        Subject GetSubjectById(Guid id);
        List<Subject> GetRandomSubjects();
    }
}
