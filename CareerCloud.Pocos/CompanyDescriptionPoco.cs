using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Descriptions")]
    public class CompanyDescriptionPoco : IPoco
    {

        //Entity Framework Navigation properties
        public virtual CompanyProfilePoco CompanyProfile { get; set; }
        public virtual SystemLanguageCodePoco SystemLanguageCode { get; set; }


        
        
        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("CompanyProfilePoco")]
        [Column("Company")] 
        public Guid Company { get; set; }

        [Required]
        [ForeignKey("SystemLanguageCodePoco")]
        [Column("LanguageID")] 
        public String LanguageId { get; set; }

        [Required]
        [Column("Company_Name")] 
        public String CompanyName { get; set; }

        [Required]
        [Column("Company_Description")] 
        public String CompanyDescription { get; set; }

        [Required]
        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }



    }
}
