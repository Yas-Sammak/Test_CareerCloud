using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {
        //Entity Framework Navigation properties
        public virtual ApplicantProfilePoco? ApplicantProfile { get; set; }



      

        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("ApplicantProfilepoco")]
        [Column("Applicant")] 
        public Guid Applicant { get; set; }

        [Required]
        [Column("Major")] 
        public String Major { get; set; }

        [Column("Certificate_Diploma")] 
        public String CertificateDiploma { get; set; }

        [Column("Start_Date")] 
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")] 
        public DateTime? CompletionDate { get; set; }

        [Column("Completion_Percent")] 
        public Byte? CompletionPercent { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }









    }
}
