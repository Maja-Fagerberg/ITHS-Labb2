namespace Labb2;

class Dice
{
    private int _numberOfDice;
    private int _sidesPerDice;
    private int _modifier;

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        _numberOfDice = numberOfDice;
        _sidesPerDice = sidesPerDice;
        _modifier = modifier;
    }

    public int Throw()
    {
        int score = 0;

        for (int i = 0; i < _numberOfDice; i++)
        {
            Random rnd = new Random();
            score += rnd.Next(1, _sidesPerDice + 1);
        }
        score += _modifier;

        return score;
    }
}