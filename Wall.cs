namespace Labb2;

class Wall : LevelElement
{
    public Wall(int xPosition, int yPosition) 
    : base(xPosition, yPosition, '#', ConsoleColor.Gray)
    {
        
    }
}