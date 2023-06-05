using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {

        //Entity Framework Navigation properties
        public virtual ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<ApplicantResumePoco> ApplicantResumes { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }


        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }






        
        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("SecurityLoginPoco")]
        [Column("Login")] 
        public Guid Login { get; set; }

        [Column("Current_Salary")] 
        public Decimal? CurrentSalary { get; set; }

        [Column("Current_Rate")] 
        public Decimal? CurrentRate { get; set; }

        [Column("Currency")] 
        public String Currency { get; set; }

        [Column("Country_Code")]
        [ForeignKey("SystemCountryCodePoco")]
        public String Country { get; set; }

        [Column("State_Province_Code")] 
        public String Province { get; set; }

        [Column("Street_Address")] 
        public String Street { get; set; }

        [Column("City_Town")] 
        public String City { get; set; }

        [Column("Zip_Postal_Code")] 
        public String PostalCode { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }




    }
}
