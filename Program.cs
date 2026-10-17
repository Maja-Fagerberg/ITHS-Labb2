Console.Clear();
LevelData levelData = new();

Player player = levelData.Load("Level1.txt");

foreach (var levelElement in levelData.Elements)
{
    levelElement.Draw();
}

bool gameOn = true;
while (gameOn)
{
    player.Draw();
    ConsoleKeyInfo keyPressed = Console.ReadKey();
    Console.Write(" "); // Fungerar med alla förutom 
    switch (keyPressed.Key)
    {
        case ConsoleKey.UpArrow:
        player.YPosition++;
        break;
        case ConsoleKey.DownArrow:
        player.YPosition--;
        break;
        case ConsoleKey.LeftArrow:
        player.XPosition++;
        break;
        case ConsoleKey.RightArrow:
        player.XPosition--;
        break;
        case ConsoleKey.Escape:
        Console.WriteLine("Are you sure you want to quit?"); //Varför Skriver den inte ut första bokstavevn? 
        // NÅgot att göra med console readlkey?

        //Kolla fix för nullable readlien, antingen ! eller annat
        int choice = int.Parse(Console.ReadLine()!);
        gameOn = choice != 1;
        break;
    }
}

abstract class LevelElement
{
    public int XPosition { get; set; }
    public int YPosition { get; set; }

    // Kanske så man gör konstruktorn för properties?
    // public LevelElement(int Xposition, int Yposition)
    // {
    //     this.XPosition = XPosition;
    //     this.YPosition = YPosition;
    // }

    public char Character { get; protected set; }
    public ConsoleColor Color { get; protected set; }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(XPosition, YPosition);
        Console.Write(Character);
        Console.SetCursorPosition(XPosition, YPosition);
        Console.ResetColor();
    }
}

class Wall : LevelElement
{
    public Wall()
    {
        Character = '#';
        Color = ConsoleColor.Gray;
    }
}

class Player : LevelElement
{
    public Player()
    {
        Character = '@';
        Color = ConsoleColor.Green;
    }
    public int healthPoints = 100;
}

abstract class Enemy : LevelElement
{
    protected Enemy()
    {
        Color = ConsoleColor.Red;
    }
    public string? Name { get; protected set; }
    public int HealthPoints { get; set; }
    
    public abstract void Update();
}

class Rat : Enemy
{
    public Rat()
    {
        Character = 'r';
        Name = "rat";
        HealthPoints = 10;
    }
    public override void Update()
    {
        Console.WriteLine("Här ska det uppdateras för råttan.");
    }
}

class Snake : Enemy
{
    public Snake()
    {
        Character = 's';
        Name = "snake";
        HealthPoints = 25;
    }
    public override void Update()
    {
        Console.WriteLine("Här ska det uppdateras för ormen.");
    }
}

class LevelData
{
    private List<LevelElement> elements = new List<LevelElement>();
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
        int row = 0;
        int column = 0;

        Player player = new();
        
        while (!reader.EndOfStream)
        {
            char character = (char)reader.Read();

            switch(character)
            {
                case '#':
                    Wall wall = new()
                    {
                        XPosition = column,
                        YPosition = row
                    };
                    elements.Add(wall);
                    column++;
                    break;
                case '@':
                    player.XPosition = column;
                    player.YPosition = row;
                    column++;
                    break;
                case 'r':
                    Rat rat = new()
                    {
                        XPosition = column,
                        YPosition = row
                    };
                    elements.Add(rat);
                    column++;
                    break;
                case 's':
                    Snake snake = new()
                    {
                        XPosition = column,
                        YPosition = row
                    };
                    elements.Add(snake);
                    column++;
                    break;
                case '\n':
                    row++;
                    column = 0;
                    break;
                default:
                    column++;
                    break;
            }
        }
        return player;
    }
}

class Dice
{

}