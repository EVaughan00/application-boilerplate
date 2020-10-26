using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Common;

namespace AuthResource.API.Commands
{
    public class ReferenceCommandHandler : CommandHandler<ReferenceCommand, bool>
    {

        public override async Task<bool> Handle(ReferenceCommand command, CancellationToken token)
        {
            await Task.CompletedTask;

            return true;
        }
    }
}