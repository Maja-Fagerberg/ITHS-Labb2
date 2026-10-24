namespace Labb2;

class Player : Entity
{
    public Player(int xPosition, int yPosition)
    : base(xPosition, yPosition, '@', ConsoleColor.Green, 100) 
    {

    }

    public void Movement(ConsoleKeyInfo movementKey, LevelData levelData)
    {
        switch (movementKey.Key)
        {
            case ConsoleKey.UpArrow:
            if (levelData.IsFreeSpot(XPosition, YPosition - 1))
            {
                Console.Write(" ");
                YPosition--;
            }
            break;
            case ConsoleKey.DownArrow:
            if (levelData.IsFreeSpot(XPosition, YPosition + 1))
            {
                Console.Write(" ");
                YPosition++;
            }
            break;
            case ConsoleKey.LeftArrow:
            if (levelData.IsFreeSpot(XPosition - 1, YPosition))
            {
                Console.Write(" ");
                XPosition--;
            }
            break;
            case ConsoleKey.RightArrow:
            if (levelData.IsFreeSpot(XPosition + 1, YPosition))
            {
                Console.Write(" ");
                XPosition++;
            }
            break;
        }
    }
}