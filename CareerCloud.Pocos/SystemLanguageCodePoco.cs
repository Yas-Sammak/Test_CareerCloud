using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
    public class SystemLanguageCodePoco
    {
        //Entity Framework Navigation properties
        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }


        [Key]
        [Required]
        [Column("LanguageID")] 
        public String LanguageID { get; set; }

        [Required]
        [Column("Name")] 
        public String Name { get; set; }

        [Required]
        [Column("Native_Name")] 
        public String NativeName { get; set; }



    }
}
