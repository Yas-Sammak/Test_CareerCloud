using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {

        //Entity Framwork
        public virtual CompanyJobPoco CompanyJob { get; set; }



        //ADO .NET

        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id{ get; set; }

        [Required]
        [ForeignKey("CompanyJobPoco")]
        [Column("Job")] 
        public Guid Job{ get; set; }

        [Required]
        [Column("Skill")] 
        public String Skill{ get; set; }

        [Required]
        [Column("Skill_Level")] 
        public String SkillLevel{ get; set; }

        [Required]
        [Column("Importance")] 
        public Int32 Importance{ get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp{ get; set; }



    }
}
