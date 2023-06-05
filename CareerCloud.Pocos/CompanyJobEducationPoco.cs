using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
    public class CompanyJobEducationPoco : IPoco
    {

        //Entity Framework
        public virtual CompanyJobPoco CompanyJob { get; set; }



        //ADO .NET
        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("CompanyJobPoco")]
        [Column("Job")] 
        public Guid Job { get; set; }

        [Required]
        [Column("Major")] 
        public String Major { get; set; }

        [Required]
        [Column("Importance")] 
        public Int16 Importance { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }




    }
}
