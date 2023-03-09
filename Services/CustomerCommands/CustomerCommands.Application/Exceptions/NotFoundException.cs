
namespace CustomerCommands.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Guid key) 
            : base($"Entity\"{name}\" with key {key} was not found.")
        {
        }

        public NotFoundException(string name, IEnumerable<Guid> key)
            : base($"\"{name}\" with keys {string.Join(',', key)} were not found.")
        {
        }
    }
}
