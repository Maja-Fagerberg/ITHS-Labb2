namespace Labb2;

class Player : Entity
{
    public Player(int xPosition, int yPosition)
    : base(xPosition, yPosition, '@', ConsoleColor.Green, "player", 100, new Dice(2,6,2), new Dice(2,6,0)) 
    {

    }

    public bool Turn(ConsoleKeyInfo movementKey, LevelData levelData, Player player)
    {
        bool gameOn = true;
        int newX = XPosition;
        int newY = YPosition;

        switch(movementKey.Key)
        {
            case ConsoleKey.UpArrow:
                newY = YPosition-1;
                break;
            case ConsoleKey.DownArrow:
                newY = YPosition+1;
                break;
            case ConsoleKey.LeftArrow:
                newX = XPosition-1;
                break;
            case ConsoleKey.RightArrow:
                newX = XPosition+1;
                break;
        }

        Enemy? enemy = levelData.IsEnemyOnSpot(newX, newY);
        if (enemy != null)
        {
            LevelElement? whoDied = Combat(player, enemy);
            if (whoDied == player)
            {
                gameOn = false;
                return gameOn;
            }
            else if (whoDied == enemy)
            {
                levelData.RemoveEnemyFromList(enemy);
            }
        }
        else if (levelData.IsFreeSpot(newX, newY))
        {
            Console.Write(" ");
            XPosition = newX;
            YPosition = newY;
        }
        return gameOn;
    }
}