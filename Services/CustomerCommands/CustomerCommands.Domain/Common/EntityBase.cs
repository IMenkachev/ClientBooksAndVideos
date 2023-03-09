
using System.ComponentModel.DataAnnotations;

namespace CustomerCommands.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; protected set; }
    }
}
