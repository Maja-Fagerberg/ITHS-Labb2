namespace Labb2;

class Wall : LevelElement
{
    public bool IsDiscovered {get;set;} = false;

    public Wall(int xPosition, int yPosition) 
    : base(xPosition, yPosition, '#', ConsoleColor.Gray)
    {
        
    }

    public override void Draw()
    {
        if (IsDiscovered)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(Character);
            Console.SetCursorPosition(XPosition, YPosition);
            Console.ResetColor();
        }
    }
}