using Abstractions;

namespace Storage;

public sealed class UnitOfWork : IUnitOfWork
{
    public IBoardgameRepository BoardgameRepository => _boardgameRepository;

    public UnitOfWork(
        DatabaseContext context,
        IBoardgameRepository boardgameRepository)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
        _boardgameRepository = boardgameRepository
            ?? throw new ArgumentNullException(nameof(boardgameRepository));
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private readonly DatabaseContext _context;
    private IBoardgameRepository _boardgameRepository;
}
