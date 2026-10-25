namespace Labb2;

abstract class Enemy : Entity
{
    public string? Name { get; private set; }
    
    protected Enemy(int xPosition, int yPosition, char character, int healthPoints, string name)
    : base(xPosition, yPosition, character, ConsoleColor.Red , healthPoints)
    {
        Name = name;
    }

    public abstract void Update(LevelData levelData, Player player);
}