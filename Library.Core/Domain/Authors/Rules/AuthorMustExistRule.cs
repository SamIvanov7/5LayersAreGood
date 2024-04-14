using System.Threading;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;

namespace Library.Core.Domain.Authors.Rules
{
    public class AuthorMustExistRule : IBusinessRule
    {
        private readonly Guid _authorId;
        private readonly IAuthorMustExistChecker _authorMustExistChecker;

        public AuthorMustExistRule(Guid authorId, IAuthorMustExistChecker authorMustExistChecker)
        {
            _authorId = authorId;
            _authorMustExistChecker = authorMustExistChecker;
        }

        public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken)
        {
            var exists = await _authorMustExistChecker.ExistsAsync(_authorId, cancellationToken);
            return exists ? RuleResult.Success() : RuleResult.Failed($"An Author with the ID {_authorId} does not exist.");
        }
    }
}
