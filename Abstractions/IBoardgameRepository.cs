using Models;

namespace Abstractions;

public interface IBoardgameRepository
{
    IEnumerable<Boardgame> GetBoardgames();

    void AddOrUpdate(Boardgame boardgame);

    void Remove(Boardgame boardgame);
}
