using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arash.Core.Model
{
    [Table("EntityBase")]
    public abstract class EntityBase
    {
        // primitive
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId
        {
            get;
            set;
        }

        [ForeignKey("EntityType")]
        public int EntityTypeId { get; set; }

        // navigation

        [ForeignKey("EntityTypeId")]
        public EntityType EntityType
        {
            get;
            set;
        }

        public EntityTypes EntityTypes
        {
            get
            {
                return (EntityTypes)EntityType.Id;
            }
            set
            {
                EntityTypeId = (int)EntityTypes;
            }
        }

        public virtual IEnumerable<Tag> Tages { get; set; }
    }
}
