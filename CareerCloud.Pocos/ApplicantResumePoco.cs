using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {

        //Entity Framework
        public virtual ApplicantProfilePoco? ApplicantProfile { get; set; }


        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("ApplicantProfilePoco")]
        [Column("Applicant")] 
        public Guid Applicant { get; set; }

        [Required]
        [Column("Resume")] 
        public String Resume { get; set; }

        [Column("Last_Updated")] 
        public DateTime? LastUpdated { get; set; }




    }
}
