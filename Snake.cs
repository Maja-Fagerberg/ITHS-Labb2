namespace Labb2;

class Snake : Enemy
{
    public Snake(int xPosition, int yPosition)
    : base(xPosition, yPosition, 's', 25, "snake")
    {

    }
    
    public override void Update()
    {

        Random rnd = new();
        int direction = rnd.Next(1,4);

    }
}