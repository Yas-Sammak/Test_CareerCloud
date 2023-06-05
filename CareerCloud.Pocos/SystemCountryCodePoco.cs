using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
    public class SystemCountryCodePoco
    {
        //Entity Framework
        public virtual ICollection<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistorys { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations{ get; set; }





        //ADO .NET
        [Key]
        [Required]
        [Column("Code")] 
        public String Code { get; set; }

        [Required]
        [Column("Name")] 
        public String Name { get; set; }



    }
}
