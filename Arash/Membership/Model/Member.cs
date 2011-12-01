using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Arash.Membership.Model
{
    [Table("Member")]
    public class Member 
    {
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}
