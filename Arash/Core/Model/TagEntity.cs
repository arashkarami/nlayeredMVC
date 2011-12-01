using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arash.Core.Model
{
    [Table("TagEntity")]
    public class TagEntity
    {
        //primitives
        [Key, Column(Order = 0)]
        [ForeignKey("Tag")]
        public int TageId { get; set; }

        [Key, Column(Order = 0)]
        [ForeignKey("EntityBase")]
        public int EntityBaseId { get; set; }

        //Navigation

        [ForeignKey("TagId")]
        public Tag Tag
        {
            get;
            set;
        }

        [ForeignKey("EntityBaseId")]
        public EntityBase EntityBase
        {
            get;
            set;
        }
    }
}
