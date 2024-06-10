using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface IDocumentRepository
    {
        List<Document> GetAllDocument();
        Document GetDocumentById(Guid id);
        List<Document> GetDocumentByType(string TypeDocument);
        bool AddDocument(Document document);
    }
}
