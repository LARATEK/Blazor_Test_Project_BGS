namespace Abstractions;

public interface IUnitOfWork : IDisposable
{
    IBoardgameRepository BoardgameRepository { get; }

    Task<int> SaveChangesAsync();
}
