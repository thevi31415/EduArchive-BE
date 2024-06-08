using System.ComponentModel.DataAnnotations;
/*Copyright (c) 2024 Nguyen Duong The Vi*/
namespace EduArchive_BE.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? Introduction { get; set; }    

        public string? Armorial {  get; set; }

        public string? Avartar { get; set; }
        public string Password { get; set; }
        public string? Organization { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastVisit { get; set; }
        public int Staus { get; set; }
       
    }
}
