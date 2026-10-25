namespace Labb2;

class Rat : Enemy
{
    public Rat(int xPosition, int yPosition)
    : base(xPosition, yPosition, 'r', 10, "rat")
    {

    }
    
    public override void Update(LevelData levelData, Player player)
    {
        Random rnd = new();
        int direction = rnd.Next(1,5);
        switch (direction)
        {
            case 1:
            if (levelData.IsFreeSpot(XPosition, YPosition - 1))
            {
                Console.Write(" ");
                YPosition--;
            }
            break;
            case 2:
            if (levelData.IsFreeSpot(XPosition, YPosition + 1))
            {
                Console.Write(" ");
                YPosition++;
            }
            break;
            case 3:
            if (levelData.IsFreeSpot(XPosition - 1, YPosition))
            {
                Console.Write(" ");
                XPosition--;
            }
            break;
            case 4:
            if (levelData.IsFreeSpot(XPosition + 1, YPosition))
            {
                Console.Write(" ");
                XPosition++;
            }
            break;
        }
    }
}