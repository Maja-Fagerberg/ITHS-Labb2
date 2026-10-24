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

        Player player = new(x, y); // Räcker detta? Testa
        
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

                    // Spara undan XY för player separat? Koden nedan fungerar ju inte längre
                    // player.XPosition = column;
                    // player.YPosition = row;
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
        return player;
    }
}