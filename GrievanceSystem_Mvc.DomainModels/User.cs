using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrievanceSystem_Mvc.DomainModels
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public int Role_ID { get; set; }

        public int Email_ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Email Email { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Role Role { get; set; }

    }
}
