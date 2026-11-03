namespace Labb2;

abstract class Enemy : Entity
{
    protected Enemy(int xPosition, int yPosition, char character, ConsoleColor color, string? name, int healthPoints, Dice attackDice, Dice defenceDice)
    : base(xPosition, yPosition, character, color, name, healthPoints, attackDice, defenceDice)
    {

    }

    public abstract bool Update(LevelData levelData, Player player);
}