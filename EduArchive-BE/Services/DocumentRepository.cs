using EduArchive_BE.Data;
using EduArchive_BE.Model;

namespace EduArchive_BE.Services
{
    public class DocumentRepository: IDocumentRepository
    {
        private readonly ApplicationDbContext _db;
        public DocumentRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public List<Document> GetAllDocument()
        {
            return _db.documents.ToList();
        }
        public Document GetDocumentById(Guid id)
        {
            return _db.documents.SingleOrDefault(u => u.Id == id);
        }
        public List<Document> GetDocumentByType(string TypeDocument)
        {
            return _db.documents.Where(u => u.TypeDocument == TypeDocument).ToList();
        }
        public bool AddDocument(Document document)
        {

            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            try
            {
                document.Id = Guid.NewGuid();
                document.CreateDate = DateTime.Now;
                document.Status = 1;
                _db.documents.Add(document);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log exception (ex) if necessary
                return false;
            }

        }
    }
}
