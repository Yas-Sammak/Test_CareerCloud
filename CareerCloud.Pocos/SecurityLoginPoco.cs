using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        //Entity Framwork
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public virtual ICollection<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }





        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [Column("Login")] 
        public String Login { get; set; }

        [Required]
        [Column("Password")] 
        public String Password { get; set; }

        [Required]
        [Column("Created_Date")] 
        public DateTime Created { get; set; }

        [Column("Password_Update_Date")] 
        public DateTime? PasswordUpdate{ get; set; }

        [Column("Agreement_Accepted_Date")] 
        public DateTime? AgreementAccepted{ get; set; }

        [Required]
        [Column("Is_Locked")] 
        public Boolean IsLocked{ get; set; }

        [Required]
        [Column("Is_Inactive")] 
        public Boolean IsInactive{ get; set; }

        [Required]
        [Column("Email_Address")] 
        public String EmailAddress{ get; set; }

        [Column("Phone_Number")] 
        public String PhoneNumber{ get; set; }

        [Column("Full_Name")] 
        public String FullName{ get; set; }

        [Required]
        [Column("Force_Change_Password")] 
        public Boolean ForceChangePassword{ get; set; }

        [Column("Prefferred_Language")] 
        public String PrefferredLanguage{ get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp{ get; set; }



    }
}
