using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EduArchive_BE.Model
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }
        public string Slug { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string NameAuthor { get; set; }

        public Guid IdAuthor { get; set; }

        public string? Image { get; set; }

        public string LinkDownload {  get; set; }

        public int? View { get; set; }

        public int Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string YearSchool {  get; set; }

        public Guid IdSubject { get; set; }

        public string NameSubject { get; set; } 

        public Guid IdChool { get; set; }
        public string NameSchool { get; set; }

        public int? Like {  get; set; }

    }
}
