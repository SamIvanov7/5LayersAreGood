using Library.Core.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Core.Common
{
    public interface IBusinessRule
    {
        Task<RuleResult> CheckAsync(CancellationToken cancellationToken);
    }
}
