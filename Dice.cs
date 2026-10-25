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

    public override string? ToString()
    {
        return base.ToString();
    }

    public int Throw()
    {
        // player exempelvis har 2 number of dice som ska gångras med en random sidesperdice som player har 6,
        // kanske en forloop som loopar numberofdice antal gånger och tar en random sidesperdice +1?(eftersom random 1,4 ger 1-3 elr?) per gång 
        // .... och lägger till i score?
        //sen efter loopen läggs modifier (i playerns fall 2, till)
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