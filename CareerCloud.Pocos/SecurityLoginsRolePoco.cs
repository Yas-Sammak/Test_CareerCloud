using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
    public class SecurityLoginsRolePoco : IPoco
    {
        //Entity Framework
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
        public virtual SecurityRolePoco SecurityRole { get; set; }

        



        [Key]
        [Required]
        [Column("Id")] 
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("SecurityLoginPoco")]
        [Column("Login")] 
        public Guid Login { get; set; }

        [Required]
        [ForeignKey("SecurityRolePoco")]
        [Column("Role")] 
        public Guid Role { get; set; }

        [Column("Time_Stamp")] 
        public Byte[] TimeStamp { get; set; }



    }
}
