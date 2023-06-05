using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {

        //Entity Framework
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        public virtual CompanyJobPoco CompanyJob { get; set; }


       

        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }


        [Required]
        [ForeignKey("ApplicantProfilePoco")]
        [Column("Applicant")] 
        public Guid Applicant { get; set; }


        [Required]
        [ForeignKey("CompanyJobPoco")]
        [Column("Job")]
        public Guid Job { get; set; }

        [Required]
        [Column("Application_Date")] 
        public DateTime ApplicationDate { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }




    }
}
