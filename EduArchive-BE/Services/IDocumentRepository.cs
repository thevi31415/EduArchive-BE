using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public interface IDocumentRepository
    {
        List<Document> GetAllDocument();
        List<Document> GetDocumentByIdSubject(Guid id);
        List <Document> SearchDocument(string? searchText, string? searchType, Guid? idSubject);
        Document GetDocumentById(Guid id);
        List<Document> GetDocumentByType(string TypeDocument);
        bool AddDocument(Document document);
    }
}
