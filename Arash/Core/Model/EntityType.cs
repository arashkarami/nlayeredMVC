using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arash.Core.Model
{
    [Table("EntityType")]
    public class EntityType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation properties

        public virtual IEnumerable<EntityBase> EntityBase { get; set; }
    }
}
