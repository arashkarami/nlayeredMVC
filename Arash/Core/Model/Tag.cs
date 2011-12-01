using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arash.Core.Model
{
    [Table("Tag")]
    public class Tag
    {
        // primitives
        public int Id { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }

        public string Name { get; set; }

        // Navigation

        [ForeignKey("ParentId")]
        public Tag Parent
        {
            get;
            set;
        }
    }
}
