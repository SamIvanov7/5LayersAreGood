using Library.Core.Common;
using Library.Core.Domain.Bocks.Common;

namespace Library.Core.Domain.Bocks.Rules
{
    public class BockMustExistRule : IBusinessRule
    {
        private readonly Guid _bockId;
        private readonly IBockMustExistChecker _bockMustExistChecker;

        public BockMustExistRule(Guid bockId, IBockMustExistChecker bockMustExistChecker)
        {
            _bockId = bockId;
            _bockMustExistChecker = bockMustExistChecker;
        }

        public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken)
        {
            var exists = await _bockMustExistChecker.ExistsAsync(_bockId, cancellationToken);
            return exists ? RuleResult.Success() : RuleResult.Failed($"No Bock with ID {_bockId} exists.");
        }
    }
}
