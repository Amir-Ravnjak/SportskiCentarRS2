using SportskiCentarRS2.Application.Uplate.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace SportskiCentarRS2.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<(bool, string)> PayWithCard(CreateUplatuCommand command, CancellationToken cancellationToken = default);
    }
}
