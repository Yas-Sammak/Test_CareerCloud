using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        //Entity Framework
        public virtual SecurityLoginPoco SecurityLogin { get; set; }



        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id{ get; set; }

        [Required]
        [ForeignKey("SecurityLoginPoco")]
        [Column("Login")] 
        public Guid Login{ get; set; }

        [Required]
        [Column("Source_IP")] 
        public String SourceIP{ get; set; }

        [Required]
        [Column("Logon_Date")] 
        public DateTime LogonDate{ get; set; }

        [Required]
        [Column("Is_Succesful")] 
        public Boolean IsSuccesful{ get; set; }



    }
}
