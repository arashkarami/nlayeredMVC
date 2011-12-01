using System;
using System.ComponentModel.DataAnnotations;

namespace Arash.Membership.Model
{
    [Table("Role")]
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
