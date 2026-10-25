namespace Labb2;

class Snake : Enemy
{
    public Snake(int xPosition, int yPosition)
    : base(xPosition, yPosition, 's', 25, "snake")
    {

    }
    
    public override void Update(LevelData levelData, Player player)
    {
        if (!IsPlayerClose(player)) {return;}

        string direction = DirectionPickerAccordingToPlayerPosition(player);
        switch (direction)
        {
            case "up":
            
            if (levelData.IsFreeSpot(XPosition, YPosition - 1))
            {
                Console.Write(" ");
                YPosition--;
            }
            break;
            case "down":
            if (levelData.IsFreeSpot(XPosition, YPosition + 1))
            {
                Console.Write(" ");
                YPosition++;
            }
            break;
            case "left":
            if (levelData.IsFreeSpot(XPosition - 1, YPosition))
            {
                Console.Write(" ");
                XPosition--;
            }
            break;
            case "right":
            if (levelData.IsFreeSpot(XPosition + 1, YPosition))
            {
                Console.Write(" ");
                XPosition++;
            }
            break;
            case "upleft":
            if (levelData.IsFreeSpot(XPosition - 1, YPosition - 1))
            {
                Console.Write(" ");
                XPosition --;
                YPosition --;
                
            }
            break;
            case "upright":
            if (levelData.IsFreeSpot(XPosition + 1, YPosition - 1))
            {
                Console.Write(" ");
                XPosition ++;
                YPosition --;
                
            }
            break;
            case "downleft":
            if (levelData.IsFreeSpot(XPosition - 1, YPosition + 1))
            {
                Console.Write(" ");
                XPosition --;
                YPosition ++;
                
            }
            break;
            case "downright":
            if (levelData.IsFreeSpot(XPosition + 1, YPosition + 1))
            {
                Console.Write(" ");
                XPosition ++;
                YPosition ++;
            }
            break;
        }
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