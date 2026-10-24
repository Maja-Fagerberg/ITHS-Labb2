namespace Labb2;

abstract class LevelElement
{
    public int XPosition { get; protected set; }
    public int YPosition { get; protected set; }
    public char Character { get; private set; }
    public ConsoleColor Color { get; private set; }

    //Konstruktorn. wall enemy player måste
    public LevelElement(int xPosition, int yPosition, char character, ConsoleColor color)
    {
        XPosition = xPosition;
        YPosition = yPosition;
        Character = character;
        Color = color;
    }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(XPosition, YPosition);
        Console.Write(Character);
        Console.SetCursorPosition(XPosition, YPosition);
        Console.ResetColor();
    }
}