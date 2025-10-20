namespace Models;

public sealed class Boardgame   //TODO:допы будут наследником
{
    public EntityId<Boardgame> Id { get; init; }

    public EntityName Name { get; init; }

    Boardgame(
        EntityId<Boardgame> id, //TODO: посмотреть как на работе это делается
        EntityName name)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
