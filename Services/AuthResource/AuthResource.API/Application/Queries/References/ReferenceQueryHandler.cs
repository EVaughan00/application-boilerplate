using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Common;

namespace AuthResource.API.Queries
{
    public class ReferenceQueryHandler : QueryHandler<ReferenceQuery, bool>
    {

        public override async Task<bool> Handle(ReferenceQuery query, CancellationToken token)
        {
            await Task.CompletedTask;

            return true;
        }
    }
}