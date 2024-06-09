using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface IDocumentRepository
    {
        List<Document> GetAllDocument();
        Document GetDocumentById(Guid id);
        bool AddDocument(Document document);
    }
}
