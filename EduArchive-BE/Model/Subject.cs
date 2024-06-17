using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace EduArchive_BE.Model
{
    public class Subject
    {
        [Key]
        public Guid id { get; set; }

       public string Code { get; set; }

       public string Name { get; set; }

       public  string Description { get; set; }

       public int? Document { get; set; }
        public  int? Status { get; set; }
       public int? View {  get; set; }

        public string? Avartar { get; set; }

        public string? BackGround { get; set; }
        public int? Like { get; set; }

    }
}
