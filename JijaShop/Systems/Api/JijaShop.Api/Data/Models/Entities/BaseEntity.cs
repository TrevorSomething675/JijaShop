using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JijaShop.Api.Data.Models.Entities
{
    public class BaseEntity
    {
        [Column("Id"), Required]
        public int? Id { get; set; }
    }
}
