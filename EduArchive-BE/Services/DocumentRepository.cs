using EduArchive_BE.Data;
using EduArchive_BE.Model;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
            return _db.documents.AsNoTracking().OrderByDescending(d => d.CreateDate)
          .ToList();
        }
        public List<Document> GetDocumentByIdSubject(Guid id)
        {
            return _db.documents.AsNoTracking().Where(d => d.IdSubject == id).ToList();
        }
        public List<Document> SearchDocument(string? searchText, string? searchType, Guid? idSubject)
        {
            // Normalize searchText
          /*  searchText = NormalizeText(searchText);*/

            List<Document> query = _db.documents.ToList();

            // Apply filters based on search criteria
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(d => TitleContains(d.Title, searchText)).ToList();
            }

            if (!string.IsNullOrEmpty(searchType))
            {
                query = query.Where(d => d.TypeDocument == searchType).ToList();
            }

            if (idSubject != null)
            {

                query = query.Where(d => d.IdSubject == idSubject).ToList();

            }


            return query.ToList();
        }
        private bool TitleContains(string title, string searchText)
        {
            string titleFinal = NormalizeString(title);
            string searchFinal = NormalizeString(searchText);

            if (titleFinal.Contains(searchFinal))
            {
                return true;
            }

            char[] charArray = searchFinal.ToCharArray();
            Array.Reverse(charArray);
            string reversedSearchFinal = new string(charArray);

            if (titleFinal.Contains(reversedSearchFinal))
            {
                return true;
            }

            return false;
        }
        static string NormalizeString(string input)
        {

            // Chuyển đổi chuỗi về dạng chữ thường
            string normalized = input.ToLower();

            // Loại bỏ các dấu tiếng Việt
            normalized = RemoveVietnameseSigns(normalized);

            // Loại bỏ khoảng trắng
            normalized = normalized.Replace(" ", "");

            return normalized;
        }
        static string RemoveVietnameseSigns(string str)
        {
            // Tạo bảng chuyển đổi ký tự có dấu sang không dấu
            string[] signs = new string[] { "aàảãáạăằẳẵắặâầẩẫấậ",
                                        "oòỏõóọôồổỗốộơờởỡớợ",
                                        "eèẻẽéẹêềểễếệ",
                                        "uùủũúụưừửữứự",
                                        "iìỉĩíị",
                                        "yỳỷỹýỵ",
                                        "dđ",
                                        "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
                                        "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
                                        "EÈẺẼÉẸÊỀỂỄẾỆ",
                                        "UÙỦŨÚỤƯỪỬỮỨỰ",
                                        "IÌỈĨÍỊ",
                                        "YỲỶỸÝỴ",
                                        "DĐ"};

            // Loại bỏ dấu trong chuỗi
            for (int i = 0; i < signs.Length; i++)
            {
                foreach (char c in signs[i].Substring(1))
                {
                    str = str.Replace(c, signs[i][0]);
                }
            }

            return str;
        }
        private string NormalizeText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            // Remove accents using normalization form KD
            text = text.Normalize(NormalizationForm.FormKD);

            // Convert to lowercase
            text = text.ToLowerInvariant();

            // Remove non-alphanumeric characters (optional step)
            text = Regex.Replace(text, @"[^a-z0-9\s-]", "");

            // Remove multiple spaces and replace with single space
            text = Regex.Replace(text, @"\s+", " ").Trim();

            return text;
        }
        public Document GetDocumentById(Guid id)
        {
            return _db.documents.AsNoTracking().SingleOrDefault(u => u.Id == id);
        }
        public List<Document> GetDocumentByType(string TypeDocument)
        {
            return _db.documents.AsNoTracking()
                      .Where(u => u.TypeDocument == TypeDocument)
                      .OrderByDescending(u => u.CreateDate)
                      .ToList();
        }

        public bool AddDocument(Document document)
        {

            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            try
            {
                var user = _db.users.FirstOrDefault(u => u.Id == document.IdAuthor);
                if(user== null)
                {
                    return false;
                }
                if(user?.Role != "Admin")
                {
                    return false;
                }
                else
                {
                    document.Id = Guid.NewGuid();
                    document.CreateDate = DateTime.Now;
                    document.Status = 1;
                    _db.documents.Add(document);
                    _db.SaveChanges();
                    return true;

                }
               
            }
            catch (Exception ex)
            {
            
                return false;
            }

        }
    }
}
