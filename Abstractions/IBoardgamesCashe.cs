using Models;

namespace Abstractions;

public interface IBoardgamesCashe
{
    void Add(Boardgame boardgame);

    void Remove(EntityId<Boardgame> id);
}
