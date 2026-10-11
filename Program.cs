bool gameOn = true;
while (gameOn)
{
    
}

abstract class LevelElement
{
    private int XPosition { get; set; }
    private int YPosition { get; set; }
    public char Character { get; protected set; }
    public ConsoleColor Color { get; protected set; }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Character);
        Console.ResetColor();
    }

    //Ta bort när implementerad
    public static implicit operator LevelElement(List<LevelElement> v)
    {
        throw new NotImplementedException();
    }
}

class Wall : LevelElement
{
    private Wall()
    {
        Character = '#';
        Color = ConsoleColor.Gray;
    }
}

class Player : LevelElement
{
    private Player()
    {
        Character = '@';
        Color = ConsoleColor.Green;
    }
    public int HealthPoints = 200;
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
    private Rat()
    {
        Character = 'r';
        Name = "rat";
        HealthPoints = 70;
    }
    public override void Update()
    {
        Console.WriteLine("Här ska det uppdateras för råttan.");
    }
}

class Snake : Enemy
{
    private Snake()
    {
        Character = 's';
        Name = "snake";
        HealthPoints = 150;
    }
    public override void Update()
    {
        Console.WriteLine("Här ska det uppdateras för ormen.");
    }
}

class LevelData
{
    private readonly LevelElement elements = new List<LevelElement> {};

    public LevelElement? Elements { get; }

    //Byt filename till det som det ska vara
    private static void Load(string filename)
    {
        Console.WriteLine("Här läses data från filen man anger vid anrop in");
        Console.WriteLine("Läs igenom textfilen tecken för tecken den hittar och skapa en ny instans av den klass som motsvarar tecknet och lägger till en ny referens till instansen på elements-listan");
        Console.WriteLine("Måste även på en X Y position och spara undan startpos för spelaren när den stöter på @");
        Console.WriteLine();
    }
}

class Dice
{

}

