using System.ComponentModel.DataAnnotations.Schema;
using JijaShop.Api.Data.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace JijaShop.Api.Data.Models.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Column("Id"), Required]
        public int Id { get; set; }
    }
}
