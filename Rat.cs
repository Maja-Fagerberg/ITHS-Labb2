namespace Labb2;

class Rat : Enemy
{
    public Rat(int xPosition, int yPosition)
    : base(xPosition, yPosition, 'r', "rat", 10, new Dice(1,6,3), new Dice(1,6,1))
    {

    }
    
    public override bool Update(LevelData levelData, Player player)
    {
        bool gameOn = true;
        int newX = XPosition;
        int newY = YPosition;
        Random rnd = new();
        int direction = rnd.Next(1,5);

        switch (direction)
        {
            case 1:
                newY = YPosition + 1;
                break;
            case 2:
                newY = YPosition - 1;
                break;
            case 3:
                newX = XPosition + 1;
                break;
            case 4:
                newX = XPosition - 1;
                break;
        }

        Enemy? enemy = levelData.IsEnemyOnSpot(XPosition, YPosition)!;
        if (LevelData.IsPlayerOnSpot(newX, newY, player))
        {
            LevelElement? whoDied = Combat(player, enemy);
            if (whoDied == enemy) 
            {
                levelData.RemoveEnemyFromList(enemy);
            }
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