using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        //Entity Framework
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }




        //ADO .NET
        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("CompanyProfilePoco")]
        [Column("Company")] 
        public Guid Company{ get; set; }

        [Required]
        [Column("Country_Code")] 
        public String CountryCode{ get; set; }

        [Column("State_Province_Code")] 
        public String Province{ get; set; }

        [Column("Street_Address")] 
        public String Street{ get; set; }

        [Column("City_Town")] 
        public String City{ get; set; }

        [Column("Zip_Postal_Code")] 
        public String PostalCode{ get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp{ get; set; }



    }
}
