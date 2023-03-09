using CustomerCommands.Application.Models;
using MediatR;
using System.Text;

namespace CustomerCommands.Application.Features.Queries.SyncData
{
    public class DataSyncQuery : IRequest<string>
    {
        public DataSyncQuery() { }
    }
}
