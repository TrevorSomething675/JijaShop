using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JijaShop.Models
{
    public abstract class BaseEntity
    {
        [Column("Id"), Required]
        public string? Id { get; set; }
    }
}
