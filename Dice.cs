namespace Labb2;

class Dice
{
    private int numberOfDice;
    private int sidesPerDice;
    private int modifier;

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        this.numberOfDice = numberOfDice;
        this.sidesPerDice = sidesPerDice;
        this.modifier = modifier;
    }

    // public override string Dice()
    // {
    //     string något to string
    //     return string
    // }
    
    public static int Throw()
    {
        int result = 0;
        return result;
    }
}