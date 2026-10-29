namespace Labb2;

class Snake : Enemy
{
    public Snake(int xPosition, int yPosition)
    : base(xPosition, yPosition, 's', "snake", 25, new Dice(3,4,2), new Dice(1,8,5))
    {

    }
    
    public override bool Update(LevelData levelData, Player player)
    {
        bool gameOn = true;

        if (!IsPlayerClose(player)) { return gameOn; }
        int newX = XPosition;
        int newY = YPosition;

        string direction = DirectionPickerAccordingToPlayerPosition(player);
        switch (direction)
        {
            case "up":
                newY = YPosition - 1;
                break;
            case "down":
                newY = YPosition + 1;
                break;
            case "left":
                newX = XPosition - 1;
                break;
            case "right":
                newX = XPosition + 1;
                break;
            case "upleft":
                newX = XPosition - 1;
                newY = YPosition - 1;
                break;
            case "upright":
                newX = XPosition + 1;
                newY = YPosition - 1;
                break;
            case "downleft":
                newX = XPosition - 1;
                newY = YPosition + 1;
                break;
            case "downright":
                newX = XPosition + 1;
                newY = YPosition + 1;
                break;
        }

        Enemy? enemy = levelData.IsEnemyOnSpot(XPosition, YPosition)!;
        if (LevelData.IsPlayerOnSpot(newX, newY, player))
        {
            LevelElement? whoDied = Combat(player, enemy);
            if (whoDied == player)
            {
                Console.WriteLine("GAMEOVER!!!!!!!!");
                gameOn = false;
                return gameOn;
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

    //Gör om gör rätt, kanske ska ha random håll bort, inte specifikt ett håll
    //Dvs, bara skriv vilket håll player är mot, om ovanför  > kan antingen gå neråt, nerhöger eller nervänster
    //                                           om nedanför > antingen gå upp, upphöger eller uppvänster?
    //                                           osv....
    private string DirectionPickerAccordingToPlayerPosition(Player player)
    {
        string direction = "";
        if (YPosition < player.YPosition && XPosition == player.XPosition) {direction = "up";}
        else if (YPosition > player.YPosition && XPosition == player.XPosition) {direction = "down";}
        else if (XPosition < player.XPosition && YPosition == player.YPosition) {direction = "left";}
        else if (XPosition > player.XPosition && YPosition == player.YPosition) {direction = "right";}
        else if (YPosition < player.YPosition && XPosition < player.XPosition) {direction = "upleft";}
        else if (YPosition < player.YPosition && XPosition > player.XPosition) {direction = "upright";}
        else if (YPosition > player.YPosition && XPosition < player.XPosition) {direction = "downleft";}
        else if (YPosition > player.YPosition && XPosition > player.XPosition) {direction = "downright";}
        return direction;
    }

    private bool IsPlayerClose(Player player)
    {
        bool isPlayerClose = false;

        if (Math.Abs(XPosition - player.XPosition) <= 2 
        && Math.Abs(YPosition - player.YPosition) <= 2)
        {
            isPlayerClose = true;
        }

        return isPlayerClose;
    }
}