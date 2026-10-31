namespace Labb2;

abstract class LevelElement
{
    public int XPosition { get; protected set; }
    public int YPosition { get; protected set; }
    public char Character { get; private set; }
    public ConsoleColor Color { get; private set; }
    public bool InSight { get; set; } = false;

    public LevelElement(int xPosition, int yPosition, char character, ConsoleColor color)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Character = character;
        Color = color;
    }

    public virtual void Draw()
    {
        if (InSight)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(Character);
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ResetColor();
        }
        else
        {
            Console.SetCursorPosition(XPosition,YPosition);
            Console.Write(" ");
        }
    }



    public static bool IsInSightOfPlayer(LevelElement levelElement, Player player)
    {
        double distance = Math.Sqrt(Math.Pow(levelElement.XPosition - player.XPosition, 2) + Math.Pow(levelElement.YPosition - player.YPosition, 2));
        if (distance <= 5) {return true;}
        else {return false;}
    }
}