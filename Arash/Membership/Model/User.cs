using System;
using System.ComponentModel.DataAnnotations;

namespace Arash.Membership.Model
{
    [Table("User")]
    public class User 
    {
        public int Id { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Job { get; set; }
    }
}
