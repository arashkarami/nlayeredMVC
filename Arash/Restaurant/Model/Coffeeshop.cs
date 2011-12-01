using System;
using Arash.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace Arash.Restaurant.Model
{
    [Table("Coffeeshop")]
    public class Coffeeshop : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
