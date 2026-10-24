namespace Labb2;

class LevelData
{
    private List<LevelElement> elements = new();
    public IReadOnlyList<LevelElement> Elements 
    { 
        get 
        { 
            return elements;
        } 
    }
    
    public Player Load(string filename)
    {
        using StreamReader reader = new(filename);
        int x = 0;
        int y = 0;
        int playerX = 0;
        int playerY = 0;
        
        while (!reader.EndOfStream)
        {
            char character = (char)reader.Read();

            switch(character)
            {
                case '#':
                    Wall wall = new(x, y);
                    elements.Add(wall);
                    x++;
                    break;
                case '@':
                    playerX = x;
                    playerY = y;
                    x++;
                    break;
                case 'r':
                    Rat rat = new(x, y);
                    elements.Add(rat);
                    x++;
                    break;
                case 's':
                    Snake snake = new(x, y);
                    elements.Add(snake);
                    x++;
                    break;
                case '\n':
                    y++;
                    x = 0;
                    break;
                default:
                    x++;
                    break;
            }
        }
        
        Player player = new(playerX, playerY);
        elements.Add(player);
        return player;
    }

    public bool IsFreeSpot(int x, int y)
    {
        bool isFreeSpot = !Elements.Any(e => e.XPosition == x && e.YPosition == y);
        return isFreeSpot;
    }

    //Returna en specifik enemy sen istället kanske. För att se vilken enemy man är i combat med.
    public bool IsEnemyOnSpot(int x, int y)
    {
        bool isEnemyOnSpot = Elements.Any(e => e.XPosition == x && e.YPosition == y && (e.Character == 'r' || e.Character == 's'));
        return isEnemyOnSpot;
    }

    public bool IsPlayerOnSpot(int x, int y)
    {
        bool isPlayerOnSpot = Elements.Any(e => e.XPosition == x && e.YPosition == y && (e.Character == '@'));
        //Villkor: om LevelElement.player xpos och ypos är lika med x och y ? true : false; eller?
        //ska jag skicka in playerxpos och playerypos  eller inte
        return isPlayerOnSpot;
    }
}