namespace Library.Core.Domain.Authors.Common
{
    public interface IAuthorMustExistChecker
    {
        Task<bool> ExistsAsync(Guid authorId, CancellationToken cancellationToken = default);
    }
}