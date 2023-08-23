using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JijaShop.Models.Entities
{
    public abstract class BaseEntity
    {
        [Column("Id"), Required]
        public int Id { get; set; }
    }
}
