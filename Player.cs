namespace Labb2;

class Player : Entity
{
    public Player(int xPosition, int yPosition)
    : base(xPosition, yPosition, '@', ConsoleColor.Green, "player", 100, new Dice(2,6,2), new Dice(2,6,0)) 
    {

    }

    public bool Movement(ConsoleKeyInfo movementKey, LevelData levelData, Player player)
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
                Console.WriteLine("GAMEOVER!!!!!!!!");
                gameOn = false; //Behöver jag verkligen skicka en bool om gameOn eller kan det skötas på annat sätt? tänk på det
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