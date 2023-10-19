using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JijaShop.Context.Entities
{
    public class BaseEntity
    {
        [Column("Id"), Required]
        public int Id { get; set; }
    }
}
