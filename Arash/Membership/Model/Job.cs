using System;
using System.ComponentModel.DataAnnotations;

namespace Arash.Membership.Model
{
    [Table("Job")]
    public class Job 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
