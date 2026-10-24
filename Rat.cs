namespace Labb2;

class Rat : Enemy
{
    public Rat(int xPosition, int yPosition)
    : base(xPosition, yPosition, 'r', 10, "rat")
    {

    }
    
    public override void Update()
    {
        Random rnd = new();
        int direction = rnd.Next(1,4);
    }
}