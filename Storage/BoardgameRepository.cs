using Abstractions;

namespace Storage;

public sealed class BoardgameRepository : IBoardgameRepository
{
    public BoardgameRepository(
        DatabaseContext context)
    {
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<Models.Boardgame> GetBoardgames()
    {
        return _context.Boardgames.Select(x => ConvertToDomain(x));
    }

    public void AddOrUpdate(Models.Boardgame boardgame)
    {
        ArgumentNullException.ThrowIfNull(boardgame);

        if (_context.Boardgames.Find(boardgame.Id.Value) != null)
        {
            _context.Boardgames.Update(
                ConvertToEntity(boardgame));
        }
        else
        {
            _context.Boardgames.Add(
                ConvertToEntity(boardgame));
        }
    }

    public void Remove(Models.Boardgame boardgame)
    {
        ArgumentNullException.ThrowIfNull(boardgame);

        _context.Remove(
            ConvertToEntity(boardgame));
    }

    private static Boardgame ConvertToEntity(Models.Boardgame boardgame)
    {
        return new()
        {
            Id = boardgame.Id.Value,
            Name = boardgame.Name.Value
        };
    }

    private static Models.Boardgame ConvertToDomain(Boardgame boardgame)
    {
        return new(
            new(boardgame.Id), 
            new(boardgame.Name));
    }

    private readonly DatabaseContext _context;
}
