using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {

        //Entity Framework
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }



        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }


        [Required]
        [ForeignKey("ApplicantProfilePoco")]
        [Column("Applicant")] 
        public Guid Applicant { get; set; }

        [Required]
        [Column("Skill")] 
        public String Skill { get; set; }

        [Required]
        [Column("Skill_Level")] 
        public String SkillLevel { get; set; }

        [Required]
        [Column("Start_Month")] 
        public Byte StartMonth { get; set; }

        [Required]
        [Column("Start_Year")] 
        public Int32 StartYear { get; set; }

        [Required]
        [Column("End_Month")] 
        public Byte EndMonth { get; set; }

        [Required]
        [Column("End_Year")] 
        public Int32 EndYear { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }




    }
}
