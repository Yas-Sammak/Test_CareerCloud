using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        //Entity Framework
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }


        public virtual CompanyProfilePoco CompanyProfile { get; set; }





        //ADO .NET

        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id{ get; set; }

        [Required]
        [ForeignKey("CompanyProfilePoco")]
        [Column("Company")] 
        public Guid Company{ get; set; }

        [Required]
        [Column("Profile_Created")] 
        public DateTime ProfileCreated{ get; set; }

        [Required]
        [Column("Is_Inactive")] 
        public Boolean IsInactive{ get; set; }

        [Required]
        [Column("Is_Company_Hidden")] 
        public Boolean IsCompanyHidden{ get; set; }

        
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp{ get; set; }




    }
}