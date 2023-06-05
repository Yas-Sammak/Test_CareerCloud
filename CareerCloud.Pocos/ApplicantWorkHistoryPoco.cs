using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]

    public class ApplicantWorkHistoryPoco : IPoco
    {

        //Entity Framework
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }



        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }


        [Required]
        [ForeignKey("ApplicantProfilePoco")]
        [Column("Applicant")] 
        public Guid Applicant { get; set; }

        [Required]
        [Column("Company_Name")] 
        public String CompanyName { get; set; }

        [Required]
        [ForeignKey("SystemCountryCodePoco")]
        [Column("Country_Code")] 
        public String CountryCode { get; set; }

        [Required]
        [Column("Location")] 
        public String Location { get; set; }

        [Required]
        [Column("Job_Title")] 
        public String JobTitle { get; set; }

        [Required]
        [Column("Job_Description")] 
        public String JobDescription { get; set; }

        [Required]
        [Column("Start_Month")] 
        public Int16 StartMonth { get; set; }

        [Required]
        [Column("Start_Year")] 
        public Int32 StartYear { get; set; }

        [Required]
        [Column("End_Month")] 
        public Int16 EndMonth { get; set; }

        [Required]
        [Column("End_Year")] 
        public Int32 EndYear { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }



    }
}
