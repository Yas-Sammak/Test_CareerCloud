﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {

        //Entity Framework Navigation properties
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }





        //ADO .NET

        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id{ get; set; }

        [Required]
        [Column("Registration_Date")] 
        public DateTime RegistrationDate{ get; set; }

        [Column("Company_Website")] 
        public String CompanyWebsite{ get; set; }

        [Required]
        [Column("Contact_Phone")] 
        public String ContactPhone{ get; set; }

        [Column("Contact_Name")] 
        public String ContactName{ get; set; }

        [Column("Company_Logo")] 
        public Byte[] CompanyLogo{ get; set; }

        [Column("Time_Stamp")] 
        public Byte[] TimeStamp{ get; set; }



    }
}
