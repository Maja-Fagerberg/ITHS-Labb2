namespace Labb2;

class Player : Entity
{
    public Player(int xPosition, int yPosition)
    : base(xPosition, yPosition, '@', ConsoleColor.Green, 100) 
    {

    }

    public void Movement(ConsoleKeyInfo movementKey, LevelData levelData, Player player)
    {
        int newX = XPosition;
        int newY = YPosition;

        switch(movementKey.Key)
        {
            case ConsoleKey.UpArrow:
            newY = YPosition - 1;
            break;
            case ConsoleKey.DownArrow:
            newY = YPosition + 1;
            break;
            case ConsoleKey.LeftArrow:
            newX = XPosition - 1;
            break;
            case ConsoleKey.RightArrow:
            newX = XPosition + 1;
            break;
        }

        Enemy? enemy = levelData.IsEnemyOnSpot(newX, newY);
        if (enemy != null)
        {
            Combat(player, enemy);
        }
        else if (levelData.IsFreeSpot(newX, newY))
        {
            Console.Write(" ");
            XPosition = newX;
            YPosition = newY;
        }
    }
}