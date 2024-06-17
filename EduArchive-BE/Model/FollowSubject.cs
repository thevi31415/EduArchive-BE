using System.ComponentModel.DataAnnotations;

namespace EduArchive_BE.Model
{
    public class FollowSubject
    {
        [Key]
       public int id { get; set; }

      public  Guid idSubject { get; set; }

     public   Guid idUser { get; set; }

      public  int Staus {  get; set; }
    }
}
